using GrupparbeteVecka4.ViewModels;

namespace GrupparbeteVecka4.Views;

public partial class ProfileSelectPage : ContentPage
{
	public ProfileSelectPage(ProfileSelectViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}