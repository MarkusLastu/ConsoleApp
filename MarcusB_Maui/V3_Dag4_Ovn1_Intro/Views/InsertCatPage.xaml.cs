using V3_Dag4_Ovn1_Intro.ViewModels;
using System.Diagnostics;

namespace V3_Dag4_Ovn1_Intro.Views;

public partial class InsertCatPage : ContentPage
{
    public InsertCatPage(InsertCatViewModel viewModel)
    {
        InitializeComponent();
        Debug.WriteLine("InsertCatPage skapas");
        Debug.WriteLine($"ViewModel: {viewModel.GetHashCode()}");
        BindingContext = viewModel;
        Debug.WriteLine($"BindingContext: {BindingContext.GetHashCode()}");
    }
}
