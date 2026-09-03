namespace Lista_videojuegos
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.DetallePage), typeof(Views.DetallePage));
        }
    }
}
