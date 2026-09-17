using GrupparbeteVecka4.ViewModels;

namespace GrupparbeteVecka4.Views;

public partial class HistoryPage : ContentPage
{
    public HistoryPage(HistoryPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}