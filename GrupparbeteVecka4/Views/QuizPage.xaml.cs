using GrupparbeteVecka4.Models;
using GrupparbeteVecka4.ViewModels;

namespace GrupparbeteVecka4.Views;

public partial class QuizPage : ContentPage
{
	public QuizPage(QuizPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
    private void OnPlayerSelectedIndexChanged(object sender, EventArgs e)
    {
        bool hasPlayer = PlayerPicker.SelectedIndex != -1;

        // Visa båda knapparna när en spelare har valts
        StartGameButton.IsVisible = hasPlayer;
        HistoryButton.IsVisible = hasPlayer;
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnHistoryButtonClicked(object sender, EventArgs e)
    {
        if (PlayerPicker.SelectedItem is Player selectedPlayer)
        {
            // Skickar med player_id som query-parameter till HistoryPage
            await Shell.Current.GoToAsync($"{nameof(HistoryPage)}?PlayerId={selectedPlayer.Id}");
        }
    }
}