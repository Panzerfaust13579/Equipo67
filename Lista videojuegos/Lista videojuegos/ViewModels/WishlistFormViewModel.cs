using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lista_videojuegos.Models;

namespace Lista_videojuegos.ViewModels
{
    public partial class WishlistFormViewModel : ObservableObject
    {
        private readonly FavoritosViewModel _favoritosViewModel;

        [ObservableProperty]
        private string nombre = string.Empty;

        [ObservableProperty]
        private string descripcion = string.Empty;

        [ObservableProperty]
        private string precio = string.Empty;

        [ObservableProperty]
        private string categoria = string.Empty;

        [ObservableProperty]
        private string imagenUrl = string.Empty;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        [ObservableProperty]
        private bool hasError;

        public WishlistFormViewModel(FavoritosViewModel favoritosViewModel)
        {
            _favoritosViewModel = favoritosViewModel;
        }

        partial void OnErrorMessageChanged(string value)
        {
            HasError = !string.IsNullOrEmpty(value);
        }

        [RelayCommand]
        public async Task AgregarALaWishlistAsync()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                ErrorMessage = "El nombre del juego es obligatorio.";
                return;
            }

            if (!decimal.TryParse(Precio, out var precioDecimal) || precioDecimal < 0)
            {
                ErrorMessage = "Ingresa un precio válido.";
                return;
            }

            ErrorMessage = string.Empty;

            var videojuego = new Videojuego
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = Nombre.Trim(),
                Descripcion = Descripcion.Trim(),
                Precio = precioDecimal,
                Categoria = string.IsNullOrWhiteSpace(Categoria) ? "Sin categoría" : Categoria.Trim(),
                ImagenUrl = ImagenUrl.Trim()
            };

            _favoritosViewModel.AgregarFavorito(videojuego);

            Nombre = string.Empty;
            Descripcion = string.Empty;
            Precio = string.Empty;
            Categoria = string.Empty;
            ImagenUrl = string.Empty;

            await Shell.Current.GoToAsync("favoritos");
        }
    }
}
