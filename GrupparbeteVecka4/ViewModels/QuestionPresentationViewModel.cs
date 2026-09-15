using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using GrupparbeteVecka4.Commands;
using GrupparbeteVecka4.Models;
using GrupparbeteVecka4.Service;

namespace GrupparbeteVecka4.ViewModels
{
    public class QuestionPresentationViewModel : INotifyPropertyChanged
    {
        private readonly DBService _service;

        private int numberOfQuestions = 3;
        private List<Question> QuizQuestions = new List<Question>();
        private Question currentQuestion;


        // ------ Läser in värden som ska skickas till Bindings på GUI ------
        public string QuestionText
        {
            get
            {
                return currentQuestion?.QuestionText;
            }
        }
        public string CategoryName
        {
            get
            {
                return currentQuestion?.Category.CategoryName;
            }
        }
        public string CategoryImage
        {
            get
            {
                return currentQuestion?.Category.CategoryImageUrl;
            }
        }

        public string Answer1
        {
            get
            {
                return currentQuestion?.Answers[0].AnswerText;
            }
        }
        public string Answer2
        {
            get
            {
                return currentQuestion?.Answers[1].AnswerText;
            }
        }

        public string Answer3
        {
            get
            {
                return currentQuestion?.Answers[2].AnswerText;
            }
        }

        public string Answer4
        {
            get
            {
                return currentQuestion?.Answers[3].AnswerText;
            }
        }


        public QuestionPresentationViewModel(DBService service)
        {
            _service = service;

            _ = LoadQuestions();
        }

        private async Task LoadQuestions()
        {
            QuizQuestions =
                await _service.GetRandomQuestionsAsync(numberOfQuestions);

            currentQuestion = QuizQuestions[0];

            PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(QuestionText)));

            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nameof(CategoryName)));

            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nameof(CategoryImage)));

            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nameof(Answer1)));

            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nameof(Answer2)));

            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nameof(Answer3)));

            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nameof(Answer4)));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
