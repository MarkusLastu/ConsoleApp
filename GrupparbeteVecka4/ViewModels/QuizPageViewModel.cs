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
        private QuizSession? quizSession;

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

        // ------ QuizTypes ------
        private List<QuizType> _quizTypes = new();
        public List<QuizType> QuizTypes
        {
            get => _quizTypes;
            set
            {
                _quizTypes = value;
                OnPropertyChanged(nameof(QuizTypes));
            }
        }

        private QuizType? _selectedQuizType;
        public QuizType? SelectedQuizType
        {
            get => _selectedQuizType;
            set
            {
                _selectedQuizType = value;
                OnPropertyChanged(nameof(SelectedQuizType));

                // Uppdatera synligheten när speltyp väljs
                switch (value?.Id)
                {
                    case 1:
                        QuizTypeClassic = true;
                        QuizTypeTimed = false;
                        break;

                    case 2:
                        QuizTypeClassic = false;
                        QuizTypeTimed = true;
                        break;

                    default:
                        QuizTypeClassic = false;
                        QuizTypeTimed = false;
                        break;

                }
            }
        }

        private bool _quizTypeClassic;
        public bool QuizTypeClassic
        {
            get => _quizTypeClassic;
            set
            {
                _quizTypeClassic = value;
                OnPropertyChanged(nameof(QuizTypeClassic));
            }
        }
        private bool _quizTypeTimed;
        public bool QuizTypeTimed
        {
            get => _quizTypeTimed;
            set
            {
                _quizTypeTimed = value;
                OnPropertyChanged(nameof(QuizTypeTimed));
            }
        }

        // ------ Antal frågor ------
        public List<int> QuestionsCount { get; } = new()
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

        // ------ Antal sekunder ------
        public List<int> SecondsCount { get; } = new()
        {
            15,
            30,
            45,
            60
        };

        private int _numberOfSeconds = 30;
        public int NumberOfSeconds
        {
            get => _numberOfSeconds;
            set
            {
                _numberOfSeconds = value;
                OnPropertyChanged(nameof(NumberOfSeconds));
            }
        }



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
            _ = LoadQuizTypes();

            StartQuizCommand = new RelayCommand(CreateQuizSession);
            //HistoryCommand = new RelayCommand(ExecuteHistory); -- Används inte längre här! NL
            BackCommand = new RelayCommand(ExecuteBack);
        }

        // ------ Databasanrop & Logik ------
        private async Task LoadPlayers()
        {
            Debug.WriteLine("Laddar players...");
            Players = await _service.GetPlayersAsync();
        }

        private async Task LoadQuizTypes()
        {
            Debug.WriteLine("Laddar QuizTypes...");
            QuizTypes = await _service.GetQuizTypesAsync();
        }

        private async Task CreateQuizSession(object parameter)
        {
            if (SelectedPlayer == null || SelectedQuizType == null)
                return;

            int numberOfQuestions;
            int numberOfSeconds;

            switch (SelectedQuizType.Id)
            {
                case 1: // Classic
                    numberOfQuestions = NumberOfQuestions;
                    numberOfSeconds = 0;
                    break;

                case 2: // Timed
                    numberOfQuestions = 0;
                    numberOfSeconds = NumberOfSeconds;
                    break;

                default:
                    Debug.WriteLine("Okänd quiztyp.");
                    return;
            }

            Debug.WriteLine("Skapar ny session...");

            quizSession = new QuizSession
            {
                PlayerId = SelectedPlayer.Id,
                StartTime = DateTime.UtcNow,
                Score = 0,
                QuizTypeId = SelectedQuizType.Id,
                DurationSeconds = numberOfSeconds
            };

            quizSession = await _service.CreateQuizSessionAsync(quizSession);

            _quizState.QuizSessionId = quizSession.Id;
            _quizState.QuizPlayerId = quizSession.PlayerId;
            _quizState.QuizTypeId = SelectedQuizType.Id;
            _quizState.QuizNumberOfQuestions = numberOfQuestions;
            _quizState.QuizNumberOfSeconds = numberOfSeconds;

            Debug.WriteLine("--- Följande är skickat till _quizState ---");
            Debug.WriteLine($"QuizSessionId: {_quizState.QuizSessionId}");
            Debug.WriteLine($"QuizPlayerId: {_quizState.QuizPlayerId}");
            Debug.WriteLine($"QuizNumberOfQuestions: {_quizState.QuizNumberOfQuestions}");
            Debug.WriteLine($"QuizNumberOfSeconds: {_quizState.QuizNumberOfSeconds}");
            Debug.WriteLine($"QuizTypeId: {_quizState.QuizTypeId}");
            Debug.WriteLine("------------------------------------------");

            await Shell.Current.GoToAsync(nameof(QuestionPage));
        }

        /*private async Task ExecuteHistory(object parameter) 
        -- Vi Flyttade HistoryCommand till ProfileSelectViewModel eftersom det är mer logiskt att hantera historik därifrån. NL --
        {
            if (SelectedPlayer != null)
            {
                await Shell.Current.GoToAsync($"{nameof(HistoryPage)}?PlayerId={SelectedPlayer.Id}");
            }
        }*/

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