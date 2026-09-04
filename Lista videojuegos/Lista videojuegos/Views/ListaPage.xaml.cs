namespace Lista_videojuegos.Views;
using Lista_videojuegos.ViewModels;
public partial class ListaPage : ContentPage
{
	private readonly ListaViewModel _viewModel;

	public ListaPage(ListaViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = viewModel;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		_viewModel.RefrescarVideojuegos();
	}
}