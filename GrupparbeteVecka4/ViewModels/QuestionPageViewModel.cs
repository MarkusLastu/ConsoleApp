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
    public class QuestionPageViewModel : INotifyPropertyChanged
    {

        private readonly DBService _service;


        private List<Question> QuizQuestions = new List<Question>();
        private int numberOfQuestions = 3;

        // ------ Parametrar för aktuell fråga ------
        private Question currentQuestion;
        private int currentQuestionNumber = 0;
        private DateTime questionStartTime;
        public ICommand AnswerCommand { get; }
        bool isAnsweredCorrect = false;


        // ------ Läser in värden som ska skickas till Bindings på GUI ------

        public string QuestionText => currentQuestion?.QuestionText;
        public string CategoryName => currentQuestion?.Category.CategoryName;
        public string CategoryImage => currentQuestion?.Category.CategoryImageUrl;

        public Answer Answer1 => currentQuestion?.Answers[0];
        public string Answer1Text => currentQuestion?.Answers[0].AnswerText;
        
        public Answer Answer2 => currentQuestion?.Answers[1];
        public string Answer2Text => currentQuestion?.Answers[1].AnswerText;
        
        public Answer Answer3 => currentQuestion?.Answers[2];
        public string Answer3Text => currentQuestion?.Answers[2].AnswerText;
        
        public Answer Answer4 => currentQuestion?.Answers[3];
        public string Answer4Text => currentQuestion?.Answers[3].AnswerText;
        

        // ------ Här är konstruktorn för min ViewModel ------
        public QuestionPageViewModel(DBService service)
        {
            _service = service;

            _ = LoadQuestions();
            AnswerCommand = new RelayCommand(HandleAnswer);
        }

        // ------ Här är metoder som kan anropas ------
        private async Task LoadQuestions()
        {
            QuizQuestions =
                await _service.GetRandomQuestionsAsync(numberOfQuestions);

            currentQuestion = QuizQuestions[0];
            UpdateQuestionProperties();
        }

        private async Task HandleAnswer(object parameter)
        {
            Answer answer = (Answer)parameter;

            // long answerId = Convert.ToInt64(parameter);

            var responseTime = DateTime.UtcNow - questionStartTime;
            var responseTimeMs = (int)responseTime.TotalMilliseconds;

            isAnsweredCorrect = answer.IsCorrect;

            Debug.WriteLine($"Valt answerId: {answer.Id}");
            Debug.WriteLine($"Tid för svar: {responseTimeMs}");
            Debug.WriteLine($"Är det rätt svar: {isAnsweredCorrect}");

            // Bygger ett objekt att skicka till DB
            var questionsInSession = new QuestionInSession
            {
                QuizSessionId = 2,
                QuestionId = currentQuestion.Id,
                AnswerId = answer.Id,
                QuestionOrder = currentQuestionNumber + 1,
                ResponseTimeMs = responseTimeMs
            };

            await _service.SaveQuestionAnswerAsync(questionsInSession);



            if (currentQuestionNumber < QuizQuestions.Count - 1)
            {
                currentQuestionNumber++;
                currentQuestion = QuizQuestions[currentQuestionNumber];
                UpdateQuestionProperties();
            }
            else
            {
                Debug.WriteLine("SLUT PÅ FRÅGOR!!!");
            }



        }
        private void UpdateQuestionProperties()
        {
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuestionText)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CategoryName)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CategoryImage)));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Answer1)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Answer1Text)));
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Answer2)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Answer2Text)));
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Answer3)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Answer3Text)));
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Answer4)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Answer4Text)));
            
            questionStartTime = DateTime.UtcNow;
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
