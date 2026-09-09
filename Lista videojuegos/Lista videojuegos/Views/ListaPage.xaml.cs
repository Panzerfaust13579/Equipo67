namespace Lista_videojuegos.Views;
using Lista_videojuegos.ViewModels;
public partial class ListaPage : ContentPage
{
    private readonly ListaViewModel _viewModel;

    public ListaPage(ListaViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _viewModel.CargarVideojuegosAsync();
    }
}