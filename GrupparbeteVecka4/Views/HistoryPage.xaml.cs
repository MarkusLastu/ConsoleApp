using GrupparbeteVecka4.Models;
using GrupparbeteVecka4.ViewModels;
using Supabase;
using static Supabase.Postgrest.Constants;
namespace GrupparbeteVecka4.Views;

[QueryProperty(nameof(PlayerId), "PlayerId")]
public partial class HistoryPage : ContentPage
{
    private readonly HistoryPageViewModel _viewModel;
    public long PlayerId { get; set; }

    // Ta emot HistoryPageViewModel i konstruktorn!
    public HistoryPage(HistoryPageViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (PlayerId > 0)
        {
            await _viewModel.LoadHistoryAsync(PlayerId);
        }
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
