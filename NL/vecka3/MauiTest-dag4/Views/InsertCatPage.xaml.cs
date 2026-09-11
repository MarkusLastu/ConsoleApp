using MauiTest_dag4.Models;
using MauiTest_dag4.ViewModels;

namespace MauiTest_dag4.Views;

public partial class InsertCatPage : ContentPage
{
    public InsertCatPage(InsertCatViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}
