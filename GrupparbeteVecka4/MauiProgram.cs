using Microsoft.Extensions.Logging;
using GrupparbeteVecka4.Service;
using GrupparbeteVecka4.ViewModels;
using GrupparbeteVecka4.Views;

namespace GrupparbeteVecka4
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<DBService>();

            builder.Services.AddTransient<QuestionPageViewModel>();
            builder.Services.AddTransient<QuestionPage>();

            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<MainPage>();

            builder.Services.AddTransient<QuizPageViewModel>();
            builder.Services.AddTransient<QuizPage>();

            builder.Services.AddTransient<HistoryPageViewModel>();
            builder.Services.AddTransient<HistoryPage>();
            builder.Services.AddSingleton<QuizState>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}