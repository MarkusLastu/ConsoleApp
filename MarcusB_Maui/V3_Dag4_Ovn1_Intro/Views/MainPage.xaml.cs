using V3_Dag4_Ovn1_Intro.ViewModels;
using V3_Dag4_Ovn1_Intro;

namespace V3_Dag4_Ovn1_Intro.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
