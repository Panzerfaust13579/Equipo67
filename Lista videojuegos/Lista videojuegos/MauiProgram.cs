using Microsoft.Extensions.Logging;
using Lista_videojuegos.Data;
using Lista_videojuegos.ViewModels;
using Lista_videojuegos.Views;

namespace Lista_videojuegos;

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

        // Repository
        builder.Services.AddSingleton<VideoJuegoRepository>();

        // ViewModels
        builder.Services.AddSingleton<FavoritosViewModel>();
        builder.Services.AddTransient<ListaViewModel>();
        builder.Services.AddTransient<DetalleViewModel>();

        // Pages
        builder.Services.AddTransient<ListaPage>();
        builder.Services.AddTransient<DetallePage>();
        builder.Services.AddTransient<FavoritosPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}