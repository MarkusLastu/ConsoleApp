using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace GrupparbeteVecka4.ViewModels;

public class SettingsPageViewModel
{
    public ICommand GlassThemeCommand { get; }
    public ICommand DarkThemeCommand { get; }
    public ICommand GreenThemeCommand { get; }
    public ICommand BackCommand { get; }

    public SettingsPageViewModel()
    {
        GlassThemeCommand = new Command(SetGlassTheme);
        DarkThemeCommand = new Command(SetDarkTheme);
        GreenThemeCommand = new Command(SetGreenTheme);
        BackCommand = new Command(async () => await ExecuteBackAsync());
    }

    private void SetGlassTheme()
    {
        if (Application.Current == null) return;

        Application.Current.Resources["PrimaryButtonColor"] = Color.FromArgb("#40FFFFFF");
        Application.Current.Resources["PrimaryTextColor"] = Color.FromArgb("#000000");
        Application.Current.Resources["PrimaryBorderColor"] = Color.FromArgb("#40000000");
        Application.Current.Resources["PrimaryBorderWidth"] = 1.5;
    }

    private void SetDarkTheme()
    {
        if (Application.Current == null) return;

        Application.Current.Resources["PrimaryButtonColor"] = Color.FromArgb("#27272A");
        Application.Current.Resources["PrimaryTextColor"] = Color.FromArgb("#FFFFFF");
        Application.Current.Resources["PrimaryBorderColor"] = Color.FromArgb("#27272A");
        Application.Current.Resources["PrimaryBorderWidth"] = 0.0;
    }

    private void SetGreenTheme()
    {
        if (Application.Current == null) return;

        Application.Current.Resources["PrimaryButtonColor"] = Color.FromArgb("#2E7D32");
        Application.Current.Resources["PrimaryTextColor"] = Color.FromArgb("#FFFFFF");
        Application.Current.Resources["PrimaryBorderColor"] = Color.FromArgb("#2E7D32");
        Application.Current.Resources["PrimaryBorderWidth"] = 0.0;
    }

    private async Task ExecuteBackAsync()
    {
        if (Application.Current?.MainPage == null) return;

        bool answer = await Application.Current.MainPage.DisplayAlert("Gå tillbaka?", "Vill du lämna inställningarna?", "Ja", "Nej");
        if (answer)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}