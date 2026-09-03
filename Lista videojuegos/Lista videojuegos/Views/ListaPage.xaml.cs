namespace Lista_videojuegos.Views;
using Lista_videojuegos.ViewModels;
public partial class ListaPage : ContentPage
{
	public ListaPage(ListaViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}