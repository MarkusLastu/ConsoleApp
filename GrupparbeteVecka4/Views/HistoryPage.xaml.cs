using GrupparbeteVecka4.Models;
using Supabase;
namespace GrupparbeteVecka4.Views;

[QueryProperty(nameof(PlayerId), "PlayerId")]
public partial class HistoryPage : ContentPage
{
    private readonly Client _supabaseClient; // Inskjuten eller hämtad från DI/App
    public long PlayerId { get; set; }

    public HistoryPage(Client supabaseClient)
    {
        InitializeComponent();
        _supabaseClient = supabaseClient;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (PlayerId > 0)
        {
            await LoadHistoryAsync(PlayerId);
        }
    }

    private async Task LoadHistoryAsync(long playerId)
    {
        try
        {
            // 1. Hämta de 4 senaste sessionerna för spelaren från 'quiz_sessions'
            var sessionResponse = await _supabaseClient
                .From<QuizSession>()
                .Where(x => x.PlayerId == playerId)
                .Order(x => x.StartTime, Postgrest.Constants.Ordering.Descending)
                .Limit(4)
                .Get();

            var sessions = sessionResponse.Models;
            var historyList = new List<QuizHistory>();

            // 2. Räkna frågor per session från 'questions_in_session'
            foreach (var session in sessions)
            {
                var questionResponse = await _supabaseClient
                    .From<QuestionsInSession>()
                    .Where(x => x.QuizSessionId == session.QuizSessionId)
                    .Get();

                historyList.Add(new QuizHistory
                {
                    QuizSessionId = session.QuizSessionId,
                    Score = session.Score ?? 0,
                    StartTime = session.StartTime,
                    TotalQuestions = questionResponse.Models.Count
                });
            }

            // 3. Bind till din CollectionView
            HistoryCollectionView.ItemsSource = historyList;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Fel", "Kunde inte hämta historik: " + ex.Message, "OK");
        }
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}

