using GrupparbeteVecka4.ViewModels;

namespace GrupparbeteVecka4.Views;

public partial class QuestionPresentation : ContentPage
{
    public QuestionPresentation(QuestionPresentationViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}