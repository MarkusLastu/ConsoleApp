using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using GrupparbeteVecka4.Commands;
using GrupparbeteVecka4.Models;
using GrupparbeteVecka4.Service;
using GrupparbeteVecka4.Views;

namespace GrupparbeteVecka4.ViewModels
{

    public class QuizPageViewModel : INotifyPropertyChanged
    {

        private readonly DBService _service;
        private readonly QuizState _quizState;

        public long CurrentSessionId;
        public long CurrentPlayerId;


        // ------ Hämta personer ------
        // private Question currentQuestion;
        // public ICommand AnswerCommand { get; }

        // ------ Hämta personer ------
        private List<Player> _players = new();
        public List<Player> Players
        {
            get => _players;
            set
            {
                _players = value;
                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(Players)));
            }
        }
        public Player SelectedPlayer { get; set; }


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
                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(NumberOfQuestions)));
            }
        }

        private QuizSession quizSession;

        // ------ Här är konstruktorn för min ViewModel ------
        public QuizPageViewModel(DBService service, QuizState quizState)
        {
            _service = service;
            _quizState = quizState;

            _ = LoadPlayers();
            //AnswerCommand = new RelayCommand(HandleAnswer);
            StartQuizCommand = new RelayCommand(CreateQuizSession);
        }


        // ------ Databasanrop ------
        private async Task LoadPlayers()
        {
            Debug.WriteLine("Laddar players...");
            Players = await _service.GetPlayersAsync();
        }

        public ICommand StartQuizCommand { get; }

        private async Task CreateQuizSession(object parameter)
        {
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


        public event PropertyChangedEventHandler PropertyChanged;


    }
}
