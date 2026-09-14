

namespace GrupparbeteVecka4.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnButtonClicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            switch (button.Text)
            {
                case "Starta Quiz":
                    await DisplayAlert("Meny", "Startar Quiz...", "OK");
                    break;

                case "Profil":
                    await DisplayAlert("Meny", "Öppnar Profil...", "OK");
                    break;

                case "Historik":
                    await DisplayAlert("Meny", "Öppnar Historik...", "OK");
                    break;

                case "Inställningar":
                    await DisplayAlert("Meny", "Öppnar Inställningar...", "OK");
                    break;
            }
        }
    }
}
