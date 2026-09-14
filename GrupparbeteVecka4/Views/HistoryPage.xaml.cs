namespace GrupparbeteVecka4.Views;

public partial class HistoryPage : ContentPage
{
	public HistoryPage()
	{
		InitializeComponent();
	}
    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        // Visar en popup med två val och väntar på svar (true / false)
        bool answer = await DisplayAlert(
            "Avbryta?",                            // Titel
            "Är du säker på att du vill gå tillbaka?", // Meddelande
            "Ja",                                  // Bekräfta (returnerar true)
            "Nej"                                  // Avbryt (returnerar false)
        );

        // Om användaren klickade "Ja", navigera bakåt
        if (answer)
        {
            await Shell.Current.GoToAsync("..");
        }
        // Om användaren klickade "Nej" händer ingenting och de stannar kvar på sidan
    }
}
