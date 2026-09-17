using GrupparbeteVecka4.ViewModels;

namespace GrupparbeteVecka4.Views;

public partial class QuizPage : ContentPage
{
    public QuizPage(QuizPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}