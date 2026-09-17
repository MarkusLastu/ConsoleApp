using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;
using GrupparbeteVecka4.Converters;
using GrupparbeteVecka4.Models;
using GrupparbeteVecka4.Service;
using GrupparbeteVecka4.Views;

namespace GrupparbeteVecka4.ViewModels
{
    public class HistoryPageViewModel : INotifyPropertyChanged, IQueryAttributable
    {
        private readonly DBService _service;

        // ==========================================
        // HISTORIK
        // ==========================================

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


        // ==========================================
        // COMMANDS
        // ==========================================

        public ICommand BackCommand { get; }
        public ICommand SelectQuizCommand { get; }


        // ==========================================
        // KONSTRUKTOR
        // ==========================================

        public HistoryPageViewModel(DBService service)
        {
            _service = service;

            BackCommand = new Command(
                async () => await Shell.Current.GoToAsync(".."));

            SelectQuizCommand = new Command<QuizHistory>(
                async selectedQuiz => await ExecuteSelectQuiz(selectedQuiz));
        }


        // ==========================================
        // NAVIGATION PARAMETER
        // ==========================================

        public async void ApplyQueryAttributes(
            IDictionary<string, object> query)
        {
            if (query.TryGetValue("PlayerId", out var playerIdObj))
            {
                if (long.TryParse(
                    playerIdObj?.ToString(),
                    out long playerId) &&
                    playerId > 0)
                {
                    await LoadHistoryAsync(playerId);
                }
            }
        }


        // ==========================================
        // HÄMTA HISTORIK
        // ==========================================

        public async Task LoadHistoryAsync(long playerId)
        {
            try
            {
                var result =
                    await _service.GetPlayerHistoryAsync(
                        playerId,
                        4);

                if (result == null ||
                    string.IsNullOrWhiteSpace(result.Content))
                {
                    QuizHistories = new List<QuizHistory>();
                    return;
                }

                string json = result.Content;

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                options.Converters.Add(
                    new FlexibleIntConverter());

                var rawHistoryList =
                    JsonSerializer.Deserialize<List<QuizHistory>>(
                        json,
                        options)
                    ?? new List<QuizHistory>();


                // Gruppera efter unik QuizSessionId

                QuizHistories = rawHistoryList
                    .GroupBy(h => h.QuizSessionId)
                    .Select(g =>
                    {
                        var first = g.First();

                        return new QuizHistory
                        {
                            QuizSessionId = g.Key,
                            StartTime = first.StartTime,
                            Score = first.Score,

                            // Antal besvarade frågor
                            TotalQuestions = g.Count(),

                            // Hämtas nu från quiz_types
                            QuizTypeText = first.QuizTypeText
                        };
                    })
                    .OrderByDescending(h => h.StartTime)
                    .ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    $"Fel vid inläsning av historik: {ex}");
            }
        }


        // ==========================================
        // VÄLJ EN SESSION
        // ==========================================

        private async Task ExecuteSelectQuiz(
            QuizHistory selectedQuiz)
        {
            if (selectedQuiz == null)
                return;

            Debug.WriteLine(
                $"Valde QuizSession: {selectedQuiz.QuizSessionId}");

            await Shell.Current.GoToAsync(
                $"{nameof(ResultPage)}" +
                $"?QuizSessionId={selectedQuiz.QuizSessionId}" +
                $"&BackRoute=..");
        }


        // ==========================================
        // PROPERTYCHANGED
        // ==========================================

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}