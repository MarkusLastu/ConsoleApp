using MauiTest_dag4.ViewModels;

namespace MauiTest_dag4.Views;

public partial class SearchCatPage : ContentPage
{
    public SearchCatPage(SearchCatViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}