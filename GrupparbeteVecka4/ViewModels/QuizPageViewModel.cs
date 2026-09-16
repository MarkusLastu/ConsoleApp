using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using GrupparbeteVecka4.Commands;
using GrupparbeteVecka4.Models;
using GrupparbeteVecka4.Service;
using GrupparbeteVecka4.Views;
using Microsoft.Maui.Controls;

namespace GrupparbeteVecka4.ViewModels
{
    public class QuizPageViewModel : INotifyPropertyChanged
    {
        private readonly DBService _service;
        private readonly QuizState _quizState;

        public long CurrentSessionId;
        public long CurrentPlayerId;

        // ------ Spelare ------
        private List<Player> _players = new();
        public List<Player> Players
        {
            get => _players;
            set
            {
                _players = value;
                OnPropertyChanged(nameof(Players));
            }
        }

        private Player? _selectedPlayer;
        public Player? SelectedPlayer
        {
            get => _selectedPlayer;
            set
            {
                _selectedPlayer = value;
                OnPropertyChanged(nameof(SelectedPlayer));

                // Uppdatera synligheten för knappar när en spelare väljs
                IsPlayerSelected = _selectedPlayer != null;
            }
        }

        private bool _isPlayerSelected;
        public bool IsPlayerSelected
        {
            get => _isPlayerSelected;
            set
            {
                _isPlayerSelected = value;
                OnPropertyChanged(nameof(IsPlayerSelected));
            }
        }

        // ------ Antal frågor ------
        public List<int> QuestionCounts { get; } = new()
        {
            5,
            10,
            15,
            20,
            25,
            50
        };

        private int _numberOfQuestions = 10;
        public int NumberOfQuestions
        {
            get => _numberOfQuestions;
            set
            {
                _numberOfQuestions = value;
                OnPropertyChanged(nameof(NumberOfQuestions));
            }
        }

        private QuizSession? quizSession;

        // ------ Kommandon ------
        public ICommand StartQuizCommand { get; }
        public ICommand HistoryCommand { get; }
        public ICommand BackCommand { get; }

        // ------ Konstruktor ------
        public QuizPageViewModel(DBService service, QuizState quizState)
        {
            _service = service;
            _quizState = quizState;

            _ = LoadPlayers();

            StartQuizCommand = new RelayCommand(CreateQuizSession);
            HistoryCommand = new RelayCommand(ExecuteHistory);
            BackCommand = new RelayCommand(ExecuteBack);
        }

        // ------ Databasanrop & Logik ------
        private async Task LoadPlayers()
        {
            Debug.WriteLine("Laddar players...");
            Players = await _service.GetPlayersAsync();
        }

        private async Task CreateQuizSession(object parameter)
        {
            if (SelectedPlayer == null) return;

            Debug.WriteLine("Skapar ny session...");

            quizSession = new QuizSession
            {
                PlayerId = SelectedPlayer.Id,
                StartTime = DateTime.UtcNow,
                Score = 0
            };
            quizSession = await _service.CreateQuizSessionAsync(quizSession);

            Debug.WriteLine($"Player är: {SelectedPlayer.PlayerName}");
            Debug.WriteLine($"StartTime är: {quizSession.StartTime}");
            Debug.WriteLine($"--- Följande skickas till QuestionPage ---");
            Debug.WriteLine($"sessionID: {quizSession.Id}");
            Debug.WriteLine($"playerID: {SelectedPlayer.Id}");
            Debug.WriteLine($"numberOfQuestions: {NumberOfQuestions}");
            Debug.WriteLine($"------------------------------------------");

            _quizState.QuizSessionId = quizSession.Id;
            _quizState.QuizPlayerId = quizSession.PlayerId;
            _quizState.QuizNumberOfQuestions = NumberOfQuestions;

            await Shell.Current.GoToAsync(nameof(QuestionPage));
        }

        private async Task ExecuteHistory(object parameter)
        {
            if (SelectedPlayer != null)
            {
                await Shell.Current.GoToAsync($"{nameof(HistoryPage)}?PlayerId={SelectedPlayer.Id}");
            }
        }

        private async Task ExecuteBack(object parameter)
        {
            await Shell.Current.GoToAsync("..");
        }
        // ------ INotifyPropertyChanged ------
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}