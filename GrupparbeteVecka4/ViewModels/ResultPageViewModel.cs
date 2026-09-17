using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using GrupparbeteVecka4.Commands;
using GrupparbeteVecka4.Models;
using GrupparbeteVecka4.Service;

namespace GrupparbeteVecka4.ViewModels
{
    public class ResultPageViewModel : INotifyPropertyChanged, IQueryAttributable
    {
        // ==========================================
        // FÄLT / PRIVAT DATA
        // ==========================================

        private readonly DBService _service;

        private long _quizSessionId;
        private string _backRoute;

        private string _playerName;
        private string _quizTypeText;
        private string _quizDurationText;
        private int _score;

        private List<QuizSessionResult> _sessionResults = new();


        // ==========================================
        // PROPERTIES
        // ==========================================

        public long QuizSessionId
        {
            get => _quizSessionId;
            set
            {
                _quizSessionId = value;
                OnPropertyChanged(nameof(QuizSessionId));
            }
        }

        public string BackRoute
        {
            get => _backRoute;
            set
            {
                _backRoute = value;
                OnPropertyChanged(nameof(BackRoute));
            }
        }

        public string PlayerName
        {
            get => _playerName;
            set
            {
                _playerName = value;
                OnPropertyChanged(nameof(PlayerName));
            }
        }

        public string QuizTypeText
        {
            get => _quizTypeText;
            set
            {
                _quizTypeText = value;
                OnPropertyChanged(nameof(QuizTypeText));
            }
        }

        public string QuizDurationText
        {
            get => _quizDurationText;
            set
            {
                _quizDurationText = value;
                OnPropertyChanged(nameof(QuizDurationText));
            }
        }

        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                OnPropertyChanged(nameof(Score));
            }
        }

        public List<QuizSessionResult> SessionResults
        {
            get => _sessionResults;
            set
            {
                _sessionResults = value;
                OnPropertyChanged(nameof(SessionResults));
            }
        }


        // ==========================================
        // COMMANDS
        // ==========================================

        public ICommand BackCommand { get; }


        // ==========================================
        // KONSTRUKTOR
        // ==========================================

        public ResultPageViewModel(DBService service)
        {
            _service = service;

            BackCommand = new RelayCommand(ExecuteBack);
        }


        // ==========================================
        // NAVIGATION PARAMETRAR
        // ==========================================

        public void ApplyQueryAttributes(
            IDictionary<string, object> query)
        {
            // QuizSessionId
            if (query.TryGetValue("QuizSessionId", out var sessionValue))
            {
                QuizSessionId = Convert.ToInt64(sessionValue);

                Debug.WriteLine(
                    $"ResultPage: QuizSessionId = {QuizSessionId}");

                _ = LoadResults();
            }
            else
            {
                Debug.WriteLine(
                    "ResultPage: QuizSessionId saknas.");
            }

            // BackRoute
            if (query.TryGetValue("BackRoute", out var backValue))
            {
                BackRoute = Uri.UnescapeDataString(
                    backValue?.ToString() ?? string.Empty);

                Debug.WriteLine(
                    $"ResultPage: BackRoute = {BackRoute}");
            }
            else
            {
                Debug.WriteLine(
                    "ResultPage: BackRoute saknas.");
            }
        }


        // ==========================================
        // HÄMTA RESULTAT
        // ==========================================

        private async Task LoadResults()
        {
            try
            {
                Debug.WriteLine(
                    $"Hämtar resultat för session {QuizSessionId}...");

                var results =
                    await _service.GetSessionResultsAsync(
                        QuizSessionId);

                if (results.Count == 0)
                {
                    Debug.WriteLine(
                        "Inget resultat hittades.");

                    return;
                }

                SessionResults = results;

                // Header-informationen är samma
                // på alla rader i resultatet.

                var first = results[0];

                PlayerName = first.PlayerName;
                Score = first.Score ?? 0;

                if(first.QuizTypeId == 2)
                {
                    QuizTypeText = $"{first.QuizTypeText} - ner från {first.DurationSeconds} sek";
                }
                else
                {
                    QuizTypeText = first.QuizTypeText;
                }

                if (first.EndTime.HasValue)
                {
                    var duration =
                        first.EndTime.Value - first.StartTime;

                    QuizDurationText =
                        duration.ToString(@"mm\:ss");
                }
                else
                {
                    QuizDurationText = "--:--";
                }

                Debug.WriteLine(
                    $"Resultat hämtat: {results.Count} frågor.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "========== RESULT ERROR ==========");

                Debug.WriteLine(ex.ToString());

                Debug.WriteLine(
                    "==================================");
            }
        }


        // ==========================================
        // TILLBAKA
        // ==========================================

        private async Task ExecuteBack(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(BackRoute))
            {
                await Shell.Current.GoToAsync(BackRoute);
            }
            else
            {
                await Shell.Current.GoToAsync("..");
            }
        }


        // ==========================================
        // PROPERTYCHANGED
        // ==========================================

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}