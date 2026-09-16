

using GrupparbeteVecka4.ViewModels;

namespace GrupparbeteVecka4.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}