using V3_Dag4_Ovn1_Intro.ViewModels;

namespace V3_Dag4_Ovn1_Intro.Views;


    public partial class SearchCatPage : ContentPage
    {
        public SearchCatPage(SearchCatViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
