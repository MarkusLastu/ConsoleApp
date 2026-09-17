using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace GrupparbeteVecka4.ViewModels;

public class MainPageViewModel
{
    public ICommand NavigateCommand { get; }
    public ICommand ExitCommand { get; }

    public MainPageViewModel()
    {
        NavigateCommand = new Command<string>(async (pageName) =>
        {
            if (!string.IsNullOrWhiteSpace(pageName))
            {
                await Shell.Current.GoToAsync(pageName);
            }
        });

        ExitCommand = new Command(async () => await ExecuteExitAsync());
    }

    private async Task ExecuteExitAsync()
    {
        if (Application.Current?.MainPage == null) return;

        bool answer = await Application.Current.MainPage.DisplayAlert(
            "Avsluta appen?",
            "Är du säker på att du vill stänga spelet?",
            "Ja",
            "Nej");

        if (answer)
        {
            Application.Current.CloseWindow(Application.Current.MainPage.Window);
        }
    }
}