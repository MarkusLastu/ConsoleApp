

using GrupparbeteVecka4.ViewModels;

namespace GrupparbeteVecka4.Views;

public partial class SettingsPage : ContentPage
{
    public SettingsPage(SettingsPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}