using MauiTest_dag4;
using MauiTest_dag4.ViewModels;
using MauiTest_dag4.Views;
using Microsoft.Extensions.Logging;

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

        // Registrera Servicar
        builder.Services.AddSingleton<CatService>();

        // Registrera ViewModels
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<InsertCatViewModel>();
        builder.Services.AddTransient<SearchCatViewModel>();

        // Registrera Views
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<InsertCatPage>();
        builder.Services.AddTransient<SearchCatPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
