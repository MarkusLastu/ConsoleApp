using MauiTest_dag4.Views;

namespace MauiTest_dag4
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(InsertCatPage), typeof(InsertCatPage));
            Routing.RegisterRoute(nameof(SearchCatPage), typeof(SearchCatPage));
        }
    }
}