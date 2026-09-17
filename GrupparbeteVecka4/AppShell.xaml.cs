using GrupparbeteVecka4.Views;

namespace GrupparbeteVecka4
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ProfileSelectPage), typeof(ProfileSelectPage));
        }
    }
}
