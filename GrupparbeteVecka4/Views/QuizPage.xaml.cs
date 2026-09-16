using GrupparbeteVecka4.ViewModels;

namespace GrupparbeteVecka4.Views;

public partial class QuizPage : ContentPage
{
	public QuizPage(QuizPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        // ".." betyder att Shell navigerar bakåt till föregående sida (MainPage)
        await Shell.Current.GoToAsync("..");
    }
    private void OnPlayerPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        // Visar knappen så fort ett giltigt val har gjorts i Pickern
        StartGameButton.IsVisible = picker.SelectedIndex != -1;
    }
}