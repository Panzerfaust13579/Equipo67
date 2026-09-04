using Lista_videojuegos.ViewModels;

namespace Lista_videojuegos.Views;

public partial class VideojuegoFormPage : ContentPage
{
    public VideojuegoFormPage(VideojuegoFormViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
