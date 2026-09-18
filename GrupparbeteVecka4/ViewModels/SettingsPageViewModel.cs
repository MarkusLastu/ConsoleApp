using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace GrupparbeteVecka4.ViewModels;

public class SettingsPageViewModel : INotifyPropertyChanged
{
    public ICommand GlassThemeCommand { get; }
    public ICommand DarkThemeCommand { get; }
    public ICommand GreenThemeCommand { get; }
    public ICommand BackCommand { get; }

    public SettingsPageViewModel()
    {
        // Frostat glas: helsvart kantlinje (Colors.Black) och 2px tjocklek
        GlassThemeCommand = new Command(() => ApplyTheme(
            buttonColor: Color.FromArgb("#40FFFFFF"),
            textColor: Colors.Black,
            headerColor: Colors.Black,
            subHeaderColor: Color.FromArgb("#333333"),
            borderColor: Colors.Black,
            borderWidth: 2
        ));

        // Mörkt tema
        DarkThemeCommand = new Command(() => ApplyTheme(
            buttonColor: Color.FromArgb("#1E1E2E"),
            textColor: Colors.White,
            headerColor: Colors.White,
            subHeaderColor: Color.FromArgb("#0d0000"),
            borderColor: Color.FromArgb("#313244"),
            borderWidth: 1
        ));

        // Skogsgrönt tema
        GreenThemeCommand = new Command(() => ApplyTheme(
            buttonColor: Color.FromArgb("#2E7D32"),
            textColor: Colors.White,
            headerColor: Color.FromArgb("#1B4332"),
            subHeaderColor: Color.FromArgb("#40916C"),
            borderColor: Color.FromArgb("#1B4332"),
            borderWidth: 1
        ));

        BackCommand = new Command(async () => await ExecuteBackAsync());
    }

    private void ApplyTheme(Color buttonColor, Color textColor, Color headerColor, Color subHeaderColor, Color borderColor, double borderWidth)
    {
        if (Application.Current == null) return;

        MainThread.BeginInvokeOnMainThread(() =>
        {
            var resources = Application.Current.Resources;

            // Uppdaterar alla dynamiska resursnycklar för hela appen
            resources["PrimaryButtonColor"] = buttonColor;
            resources["PrimaryTextColor"] = textColor;
            resources["HeaderTextColor"] = headerColor;
            resources["SubHeaderTextColor"] = subHeaderColor;
            resources["PrimaryBorderColor"] = borderColor;
            resources["PrimaryBorderWidth"] = borderWidth;
        });
    }

    private async Task ExecuteBackAsync()
    {
        await Shell.Current.GoToAsync("..");
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}