using Microsoft.Extensions.Logging;
using V3_Dag4_Ovn1_Intro.ViewModels;
using V3_Dag4_Ovn1_Intro.Views;
using V3_Dag4_Ovn1_Intro.Service;

namespace V3_Dag4_Ovn1_Intro
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

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<InsertCatPage>();
            builder.Services.AddTransient<InsertCatViewModel>();
            builder.Services.AddTransient<SearchCatPage>();
            builder.Services.AddTransient<SearchCatViewModel>();

            builder.Services.AddSingleton<CatService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}