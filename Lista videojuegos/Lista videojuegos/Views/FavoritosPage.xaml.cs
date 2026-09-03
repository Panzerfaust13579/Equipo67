using Lista_videojuegos.ViewModels;

namespace Lista_videojuegos.Views;

public partial class FavoritosPage : ContentPage
{
    public FavoritosPage(FavoritosViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}