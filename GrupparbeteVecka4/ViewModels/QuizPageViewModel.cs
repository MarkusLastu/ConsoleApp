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

namespace GrupparbeteVecka4.ViewModels
{

    public class QuizPageViewModel : INotifyPropertyChanged
    {

        private readonly DBService _service;

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

        // ------ Här är konstruktorn för min ViewModel ------
        public QuizPageViewModel(DBService service)
        {
            _service = service;

            _ = LoadPlayers();
            //AnswerCommand = new RelayCommand(HandleAnswer);
        }

        private async Task LoadPlayers()
        {
            Debug.WriteLine("Laddar players...");
            Players = await _service.GetPlayersAsync();
        }

        private async Task CreateQuizSession()
        {
            Debug.WriteLine("Ej implementerad än...");
            Players = await _service.GetPlayersAsync();
        }


        public event PropertyChangedEventHandler PropertyChanged;


    }
}
