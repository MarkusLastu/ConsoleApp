

using GrupparbeteVecka4.ViewModels;

namespace GrupparbeteVecka4.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Tvinga sidan att läsa om sina dynamiska resurser
        this.OnPropertyChanged(nameof(Background));
    }
}