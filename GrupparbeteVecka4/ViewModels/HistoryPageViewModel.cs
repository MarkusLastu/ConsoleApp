using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Input;
using GrupparbeteVecka4.Converters;
using GrupparbeteVecka4.Models;
using GrupparbeteVecka4.Service;
using Microsoft.Maui.Controls;

namespace GrupparbeteVecka4.ViewModels
{
    public class HistoryPageViewModel : INotifyPropertyChanged, IQueryAttributable
    {
        private readonly DBService _service;

        private List<QuizHistory> _quizHistories = new();
        public List<QuizHistory> QuizHistories
        {
            get => _quizHistories;
            set
            {
                _quizHistories = value;
                OnPropertyChanged();
            }
        }

        public ICommand BackCommand { get; }

        public HistoryPageViewModel(DBService service)
        {
            _service = service;
            BackCommand = new Command(async () => await Shell.Current.GoToAsync(".."));
        }

        // Fångar upp parametern "PlayerId" när Shell navigerar hit
        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("PlayerId", out var playerIdObj))
            {
                if (long.TryParse(playerIdObj?.ToString(), out long playerId) && playerId > 0)
                {
                    await LoadHistoryAsync(playerId);
                }
            }
        }

        public async Task LoadHistoryAsync(long playerId)
        {
            try
            {
                var result = await _service.GetPlayerHistoryAsync(playerId, 4);

                if (result != null && result.Content != null)
                {
                    string json = result.Content;

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    options.Converters.Add(new FlexibleIntConverter());

                    var rawHistoryList = JsonSerializer.Deserialize<List<QuizHistory>>(json, options) ?? new List<QuizHistory>();

                    QuizHistories = rawHistoryList
                        .GroupBy(h => h.QuizSessionId)
                        .Select(g => new QuizHistory
                        {
                            QuizSessionId = g.Key,
                            StartTime = g.First().StartTime,
                            Score = g.First().Score,
                            TotalQuestions = g.Count()
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Fel vid inläsning av historik: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}