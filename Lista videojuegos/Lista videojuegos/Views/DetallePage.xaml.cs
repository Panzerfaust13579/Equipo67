using Lista_videojuegos.ViewModels;

namespace Lista_videojuegos.Views;

public partial class DetallePage : ContentPage
{
	public DetallePage(DetalleViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
