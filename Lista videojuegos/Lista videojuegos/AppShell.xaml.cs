using Lista_videojuegos.Views;

namespace Lista_videojuegos
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(DetallePage), typeof(DetallePage));
            Routing.RegisterRoute("favoritos", typeof(FavoritosPage));
        }
    }
}