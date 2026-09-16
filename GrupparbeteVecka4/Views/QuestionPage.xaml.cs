using GrupparbeteVecka4.ViewModels;

namespace GrupparbeteVecka4.Views;

public partial class QuestionPage : ContentPage
{
    public QuestionPage(QuestionPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}