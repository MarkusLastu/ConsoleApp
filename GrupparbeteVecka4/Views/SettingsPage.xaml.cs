namespace GrupparbeteVecka4.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}
    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        // ".." betyder att Shell navigerar bakåt till föregående sida (MainPage)
        await Shell.Current.GoToAsync("..");
    }
}