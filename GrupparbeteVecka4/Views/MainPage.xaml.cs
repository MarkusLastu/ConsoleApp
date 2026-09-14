

namespace GrupparbeteVecka4.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnButtonClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is string pageName)
        {
            // Navigerar till den sida som skickades med i CommandParameter
            await Shell.Current.GoToAsync(pageName);
        }
    }
}

