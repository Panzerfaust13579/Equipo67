using Lista_videojuegos.ViewModels;

namespace Lista_videojuegos.Views;

public partial class WishlistFormPage : ContentPage
{
    public WishlistFormPage(WishlistFormViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
