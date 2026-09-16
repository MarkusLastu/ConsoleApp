using GrupparbeteVecka4.Models;
using GrupparbeteVecka4.ViewModels;

namespace GrupparbeteVecka4.Views;

public partial class QuizPage : ContentPage
{
	public QuizPage()
	{
		InitializeComponent();
	}
    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        // ".." betyder att Shell navigerar bakåt till föregående sida (MainPage)
        await Shell.Current.GoToAsync("..");
    }

    private async void OnHistoryButtonClicked(object sender, EventArgs e)
    {
        if (PlayerPicker.SelectedItem is Player selectedPlayer)
        {
            // Skickar med player_id som query-parameter till HistoryPage
            await Shell.Current.GoToAsync($"{nameof(HistoryPage)}?PlayerId={selectedPlayer.PlayerId}");
        }
    }
}