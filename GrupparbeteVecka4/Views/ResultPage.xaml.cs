using GrupparbeteVecka4.ViewModels;

namespace GrupparbeteVecka4.Views;

public partial class ResultPage : ContentPage
{
    public ResultPage(ResultPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}