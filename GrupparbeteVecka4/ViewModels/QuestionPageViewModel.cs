using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Input;
using GrupparbeteVecka4.Commands;
using GrupparbeteVecka4.Models;
using GrupparbeteVecka4.Service;
using GrupparbeteVecka4.Views;

namespace GrupparbeteVecka4.ViewModels
{
    public class QuestionPageViewModel : INotifyPropertyChanged
    {
        // ==========================================
        // FÄLT / PRIVAT DATA
        // ==========================================

        private readonly DBService _service;
        private readonly QuizState _quizState;

        private List<Question> _quizQuestions = new();

        private Question _currentQuestion;
        private int _currentQuestionNumber;
        private DateTime _questionStartTime;
        private DateTime _quizStartTime;
        private DateTime _quizEndTime;
        private CancellationTokenSource? _timerCancellation;
        private bool _quizFinished;




        // ==========================================
        // PROPERTIES FÖR FRÅGAN
        // ==========================================

        public string QuestionText =>
            _currentQuestion?.QuestionText;

        public string CategoryName =>
            _currentQuestion?.Category?.CategoryName;

        public string CategoryImage =>
            _currentQuestion?.Category?.CategoryImageUrl;

        public Answer Answer1 =>
            _currentQuestion?.Answers[0];

        public string Answer1Text =>
            _currentQuestion?.Answers[0].AnswerText;

        public Answer Answer2 =>
            _currentQuestion?.Answers[1];

        public string Answer2Text =>
            _currentQuestion?.Answers[1].AnswerText;

        public Answer Answer3 =>
            _currentQuestion?.Answers[2];

        public string Answer3Text =>
            _currentQuestion?.Answers[2].AnswerText;

        public Answer Answer4 =>
            _currentQuestion?.Answers[3];

        public string Answer4Text =>
            _currentQuestion?.Answers[3].AnswerText;


        // ==========================================
        // PROPERTIES FÖR VISNING
        // ==========================================

        public string QuestionProgressText =>
            $"Fråga {_currentQuestionNumber + 1} av {_quizQuestions.Count}";

        public string QuizScoreText => $"Poäng: {_quizState.QuizScore}";

        private bool _isQuestionVisible = true;

        public bool IsQuestionVisible
        {
            get => _isQuestionVisible;
            set
            {
                _isQuestionVisible = value;
                OnPropertyChanged(nameof(IsQuestionVisible));
            }
        }

        private bool _isAnswerVisible = false;

        public bool IsAnswerVisible
        {
            get => _isAnswerVisible;
            set
            {
                _isAnswerVisible = value;
                OnPropertyChanged(nameof(IsAnswerVisible));
            }
        }

        private string _answerResultText;

        public string AnswerResultText
        {
            get => _answerResultText;
            set
            {
                _answerResultText = value;
                OnPropertyChanged(nameof(AnswerResultText));
            }
        }

        private string _correctAnswerText;

        public string CorrectAnswerText
        {
            get => _correctAnswerText;
            set
            {
                _correctAnswerText = value;
                OnPropertyChanged(nameof(CorrectAnswerText));
            }
        }

        private string _pointsText;

        public string PointsText
        {
            get => _pointsText;
            set
            {
                _pointsText = value;
                OnPropertyChanged(nameof(PointsText));
            }
        }

        private string _timerText;

        public string TimerText
        {
            get => _timerText;
            set
            {
                _timerText = value;
                OnPropertyChanged(nameof(TimerText));
            }
        }



        // ==========================================
        // COMMANDS
        // ==========================================

        public ICommand AnswerCommand { get; }
        public ICommand NextQuestionCommand { get; }


        // ==========================================
        // KONSTRUKTOR
        // ==========================================

        public QuestionPageViewModel(
            DBService service,
            QuizState quizState)
        {
            Debug.WriteLine("--- Följande är mottaget från QuizPage ---");
            Debug.WriteLine($"Ny session har ID: {quizState.QuizSessionId}");
            Debug.WriteLine($"Player är: {quizState.QuizPlayerId}");
            Debug.WriteLine($"Antal frågor: {quizState.QuizNumberOfQuestions}");
            Debug.WriteLine("------------------------------------------");

            _service = service;
            _quizState = quizState;

            AnswerCommand = new RelayCommand(HandleAnswer);
            NextQuestionCommand = new RelayCommand(HandleNextQuestion);

            _ = LoadQuestions();
        }


        // ==========================================
        // LADDNING AV FRÅGOR
        // ==========================================

        private async Task LoadQuestions()
        {
            _quizQuestions =
                await _service.GetRandomQuestionsAsync(
                    _quizState.QuizNumberOfQuestions);

            _currentQuestionNumber = 0;
            _currentQuestion = _quizQuestions[0];

            UpdateQuestionProperties();

            _quizStartTime = DateTime.UtcNow;

            if (_quizState.QuizTypeId == 2)
            {
                _quizEndTime = _quizStartTime.AddSeconds(
                    _quizState.QuizNumberOfSeconds);
            }

            _ = StartTimer();
        }


        // ==========================================
        // HANTERA SVAR
        // ==========================================

        private async Task HandleAnswer(object parameter)
        {
            Answer answer = (Answer)parameter;

            var responseTime =
                DateTime.UtcNow - _questionStartTime;

            var responseTimeMs =
                (int)responseTime.TotalMilliseconds;

            Debug.WriteLine($"Valt answerId: {answer.Id}");
            Debug.WriteLine($"Tid för svar: {responseTimeMs}");
            Debug.WriteLine($"Är det rätt svar: {answer.IsCorrect}");

            // --------------------------------------
            // Spara svaret
            // --------------------------------------

            var questionsInSession = new QuestionInSession
            {
                QuizSessionId = _quizState.QuizSessionId,
                QuestionId = _currentQuestion.Id,
                AnswerId = answer.Id,
                QuestionOrder = _currentQuestionNumber + 1,
                ResponseTimeMs = responseTimeMs
            };

            await _service.SaveQuestionAnswerAsync(
                questionsInSession);


            // --------------------------------------
            // Hantera resultatet
            // --------------------------------------

            if (answer.IsCorrect)
            {
                _quizState.QuizScore++;

                AnswerResultText = "Rätt svar!";
                PointsText = "+1 poäng";
            }
            else
            {
                AnswerResultText = "Fel svar";
                
                if (_quizState.QuizTypeId == 2)
                {
                    _quizEndTime = _quizEndTime.AddSeconds(-5);
                    PointsText = "0 poäng - Minus 5 sekunder på klockan också!!!";
                    Debug.WriteLine("Fel svar! 5 sekunder dras från timern.");
                } else
                {
                    PointsText = "0 poäng";
                }
            }

            CorrectAnswerText =
                $"Rätt svar: {_currentQuestion.Answers.First(a => a.IsCorrect).AnswerText}";


            // --------------------------------------
            // Visa resultatvyn
            // --------------------------------------

            IsQuestionVisible = false;
            IsAnswerVisible = true;
        }


        // ==========================================
        // NÄSTA FRÅGA
        // ==========================================

        private async Task HandleNextQuestion(object parameter)
        {
            if (_currentQuestionNumber < _quizQuestions.Count - 1)
            {
                _currentQuestionNumber++;

                _currentQuestion =
                    _quizQuestions[_currentQuestionNumber];

                UpdateQuestionProperties();

                IsQuestionVisible = true;
                IsAnswerVisible = false;
            }
            else
            {
                await FinishQuizSession();
            }
        }

        private async Task FinishQuizSession()
        {
            if (_quizFinished)
                return;

            _quizFinished = true;

            _timerCancellation?.Cancel();

            Debug.WriteLine("SLUT PÅ FRÅGOR!!!");

            await UpdateQuizSession();

            await Shell.Current.GoToAsync(
                $"{nameof(ResultPage)}" +
                $"?QuizSessionId={_quizState.QuizSessionId}" +
                $"&BackRoute=//MainPage");
        }

        // ==========================================
        // TIMER logik
        // ==========================================

        private async Task StartTimer()
        {
            _timerCancellation = new CancellationTokenSource();

            try
            {
                while (!_timerCancellation.Token.IsCancellationRequested)
                {
                    if (_quizState.QuizTypeId == 1)
                    {
                        TimeSpan elapsed =
                            DateTime.UtcNow - _quizStartTime;

                        TimerText = elapsed.ToString(@"mm\:ss");
                    }
                    else if (_quizState.QuizTypeId == 2)
                    {
                        TimeSpan remaining =
                            _quizEndTime - DateTime.UtcNow;

                        if (remaining <= TimeSpan.Zero)
                        {
                            TimerText = "00:00";

                            Debug.WriteLine("TIDEN ÄR SLUT!");

                            await FinishQuizSession();
                            return;
                        }

                        TimerText = remaining.ToString(@"mm\:ss");
                    }

                    await Task.Delay(
                        250,
                        _timerCancellation.Token);
                }
            }
            catch (OperationCanceledException)
            {
                Debug.WriteLine("Timern stoppad.");
            }
        }



        // ==========================================
        // UPPDATERA FRÅGEVYN
        // ==========================================

        private void UpdateQuestionProperties()
        {
            OnPropertyChanged(nameof(QuestionText));
            OnPropertyChanged(nameof(CategoryName));
            OnPropertyChanged(nameof(CategoryImage));

            OnPropertyChanged(nameof(Answer1));
            OnPropertyChanged(nameof(Answer1Text));

            OnPropertyChanged(nameof(Answer2));
            OnPropertyChanged(nameof(Answer2Text));

            OnPropertyChanged(nameof(Answer3));
            OnPropertyChanged(nameof(Answer3Text));

            OnPropertyChanged(nameof(Answer4));
            OnPropertyChanged(nameof(Answer4Text));

            OnPropertyChanged(nameof(QuestionProgressText));
            OnPropertyChanged(nameof(QuizScoreText));            

            _questionStartTime = DateTime.UtcNow;
        }

        // ==========================================
        // UPPDATERA QUIZSESSION I DB
        // ==========================================

        private async Task UpdateQuizSession()
        {
            Debug.WriteLine("Uppdaterar sessionen...");

            var quizSession = new QuizSession
            {
                Id = _quizState.QuizSessionId,
                EndTime = DateTime.UtcNow,
                Score = _quizState.QuizScore
            };
            await _service.UpdateFinishedQuizSessionAsync(quizSession);
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

        public event PropertyChangedEventHandler PropertyChanged;
    }
}