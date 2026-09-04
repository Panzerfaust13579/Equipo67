using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lista_videojuegos.Data;
using Lista_videojuegos.Models;

namespace Lista_videojuegos.ViewModels
{
    [QueryProperty(nameof(Id), "Id")]
    public partial class VideojuegoFormViewModel : ObservableObject
    {
        private readonly VideoJuegoRepository _videoJuegoRepository;

        [ObservableProperty]
        private string id = string.Empty;

        [ObservableProperty]
        private bool esEdicion;

        [ObservableProperty]
        private string titulo = "Agregar juego";

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

        public VideojuegoFormViewModel(VideoJuegoRepository videoJuegoRepository)
        {
            _videoJuegoRepository = videoJuegoRepository;
        }

        partial void OnIdChanged(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                EsEdicion = false;
                Titulo = "Agregar juego";
                return;
            }

            var videojuego = _videoJuegoRepository.GetVideojuegoById(value);

            if (videojuego is null)
            {
                EsEdicion = false;
                Titulo = "Agregar juego";
                return;
            }

            EsEdicion = true;
            Titulo = "Editar juego";
            Nombre = videojuego.Nombre;
            Descripcion = videojuego.Descripcion;
            Precio = videojuego.Precio.ToString();
            Categoria = videojuego.Categoria;
            ImagenUrl = videojuego.ImagenUrl;
        }

        partial void OnErrorMessageChanged(string value)
        {
            HasError = !string.IsNullOrEmpty(value);
        }

        [RelayCommand]
        public async Task GuardarAsync()
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
                Id = EsEdicion ? Id : Guid.NewGuid().ToString(),
                Nombre = Nombre.Trim(),
                Descripcion = Descripcion.Trim(),
                Precio = precioDecimal,
                Categoria = string.IsNullOrWhiteSpace(Categoria) ? "Sin categoría" : Categoria.Trim(),
                ImagenUrl = ImagenUrl.Trim()
            };

            if (EsEdicion)
            {
                _videoJuegoRepository.UpdateVideojuego(videojuego);
            }
            else
            {
                _videoJuegoRepository.AddVideojuego(videojuego);
            }

            await Shell.Current.GoToAsync("..");
        }
    }
}
