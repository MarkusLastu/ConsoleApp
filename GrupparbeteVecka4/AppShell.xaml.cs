using GrupparbeteVecka4.Views;

namespace GrupparbeteVecka4
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {

        InitializeComponent();

        // Registrera undersidor för Shell-navigering
        Routing.RegisterRoute(nameof(QuizPage), typeof(QuizPage));
        Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
        Routing.RegisterRoute(nameof(HistoryPage), typeof(HistoryPage));
        Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
        Routing.RegisterRoute(nameof(QuestionPage), typeof(QuestionPage));
        Routing.RegisterRoute(nameof(ProfileSelectPage), typeof(ProfileSelectPage));
        Routing.RegisterRoute(nameof(ResultPage), typeof(ResultPage));
        }
    }
}