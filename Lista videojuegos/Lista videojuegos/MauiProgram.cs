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
                fonts.AddFont(
                    "OpenSans-Regular.ttf",
                    "OpenSansRegular");

                fonts.AddFont(
                    "OpenSans-Semibold.ttf",
                    "OpenSansSemibold");
            });

        // ==========================================
        // REPOSITORY
        // ==========================================

        // Singleton:
        // conserva la misma colección de videojuegos
        // durante toda la ejecución de la aplicación.
        builder.Services.AddSingleton<
            VideoJuegoRepository>();

        // ==========================================
        // VIEWMODELS
        // ==========================================

        // Singleton:
        // permite conservar los favoritos entre
        // las diferentes navegaciones.
        builder.Services.AddSingleton<
            FavoritosViewModel>();

        // Transient:
        // se crea una instancia nueva cuando se necesita.
        builder.Services.AddTransient<
            ListaViewModel>();

        builder.Services.AddTransient<
            DetalleViewModel>();

        builder.Services.AddTransient<
            VideojuegoFormViewModel>();

        // ==========================================
        // PAGES
        // ==========================================

        builder.Services.AddTransient<
            ListaPage>();

        builder.Services.AddTransient<
            DetallePage>();

        builder.Services.AddTransient<
            FavoritosPage>();

        builder.Services.AddTransient<
            VideojuegoFormPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}