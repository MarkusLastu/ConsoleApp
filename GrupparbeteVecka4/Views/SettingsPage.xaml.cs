namespace GrupparbeteVecka4.Views;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
    }

    // 1. Frostat Glas-Tema
    private void OnGlassThemeClicked(object sender, EventArgs e)
    {
        Application.Current.Resources["PrimaryButtonColor"] = Color.FromArgb("#40FFFFFF"); // Halvtransparent vit
        Application.Current.Resources["PrimaryTextColor"] = Color.FromArgb("#000000");
        Application.Current.Resources["PrimaryBorderColor"] = Color.FromArgb("#40000000");
        Application.Current.Resources["PrimaryBorderWidth"] = 1.5;
    }

    // 2. Mörka Knappar
    private void OnDarkThemeClicked(object sender, EventArgs e)
    {
        Application.Current.Resources["PrimaryButtonColor"] = Color.FromArgb("#27272A");
        Application.Current.Resources["PrimaryTextColor"] = Color.FromArgb("#FFFFFF");
        Application.Current.Resources["PrimaryBorderColor"] = Color.FromArgb("#27272A");
        Application.Current.Resources["PrimaryBorderWidth"] = 0.0;
    }

    // 3. Skogsgröna Knappar
    private void OnGreenThemeClicked(object sender, EventArgs e)
    {
        Application.Current.Resources["PrimaryButtonColor"] = Color.FromArgb("#2E7D32");
        Application.Current.Resources["PrimaryTextColor"] = Color.FromArgb("#FFFFFF");
        Application.Current.Resources["PrimaryBorderColor"] = Color.FromArgb("#2E7D32");
        Application.Current.Resources["PrimaryBorderWidth"] = 0.0;
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Gå tillbaka?", "Vill du lämna inställningarna?", "Ja", "Nej");
        if (answer)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}