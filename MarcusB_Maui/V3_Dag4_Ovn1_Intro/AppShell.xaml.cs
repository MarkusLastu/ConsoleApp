using V3_Dag4_Ovn1_Intro.Views;

namespace V3_Dag4_Ovn1_Intro

{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(
                nameof(InsertCatPage),
                typeof(InsertCatPage));

            Routing.RegisterRoute(
                nameof(SearchCatPage),
                typeof(SearchCatPage));
        }
    }
}


