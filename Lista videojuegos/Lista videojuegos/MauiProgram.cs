using Lista_videojuegos.ViewModels;
using Lista_videojuegos.Views;
using Microsoft.Extensions.Logging;
using Lista_videojuegos.Data;

namespace Lista_videojuegos
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

            // Register the pages and view models for dependency injection
            builder.Services.AddSingleton<ListaPage>();
            builder.Services.AddSingleton<ListaViewModel>();
            // Repository
            builder.Services.AddSingleton<VideoJuegoRepository>();
            builder.Services.AddSingleton<DetallePage>();
            builder.Services.AddSingleton<DetalleViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
