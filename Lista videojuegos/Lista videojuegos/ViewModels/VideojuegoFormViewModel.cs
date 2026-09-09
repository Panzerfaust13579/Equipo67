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

        private string _id = string.Empty;
        private bool _esEdicion;
        private string _titulo = "Agregar juego";
        private string _nombre = string.Empty;
        private string _descripcion = string.Empty;
        private string _precio = string.Empty;
        private string _categoria = string.Empty;
        private string _imagenUrl = string.Empty;
        private string _errorMessage = string.Empty;
        private bool _hasError;

        public string Id
        {
            get => _id;
            set
            {
                if (SetProperty(ref _id, value))
                {
                    CargarDatos(value);
                }
            }
        }

        public bool EsEdicion
        {
            get => _esEdicion;
            set => SetProperty(ref _esEdicion, value);
        }

        public string Titulo
        {
            get => _titulo;
            set => SetProperty(ref _titulo, value);
        }

        public string Nombre
        {
            get => _nombre;
            set => SetProperty(ref _nombre, value);
        }

        public string Descripcion
        {
            get => _descripcion;
            set => SetProperty(ref _descripcion, value);
        }

        public string Precio
        {
            get => _precio;
            set => SetProperty(ref _precio, value);
        }

        public string Categoria
        {
            get => _categoria;
            set => SetProperty(ref _categoria, value);
        }

        public string ImagenUrl
        {
            get => _imagenUrl;
            set => SetProperty(ref _imagenUrl, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (SetProperty(ref _errorMessage, value))
                {
                    HasError = !string.IsNullOrEmpty(value);
                }
            }
        }

        public bool HasError
        {
            get => _hasError;
            set => SetProperty(ref _hasError, value);
        }

        public IAsyncRelayCommand GuardarCommand { get; }

        public VideojuegoFormViewModel(
            VideoJuegoRepository videoJuegoRepository)
        {
            _videoJuegoRepository = videoJuegoRepository;

            GuardarCommand =
                new AsyncRelayCommand(GuardarAsync);
        }

        private void CargarDatos(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                EsEdicion = false;
                Titulo = "Agregar juego";

                Nombre = string.Empty;
                Descripcion = string.Empty;
                Precio = string.Empty;
                Categoria = string.Empty;
                ImagenUrl = string.Empty;

                return;
            }

            var videojuego =
                _videoJuegoRepository.ObtenerPorId(value);

            if (videojuego == null)
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

        private async Task GuardarAsync()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                ErrorMessage =
                    "El nombre del juego es obligatorio.";

                return;
            }

            if (!decimal.TryParse(
                    Precio,
                    out var precioDecimal) ||
                precioDecimal < 0)
            {
                ErrorMessage =
                    "Ingresa un precio válido.";

                return;
            }

            ErrorMessage = string.Empty;

            var videojuego = new Videojuego
            {
                Id = EsEdicion
                    ? Id
                    : Guid.NewGuid().ToString(),

                Nombre = Nombre.Trim(),

                Descripcion =
                    Descripcion.Trim(),

                Precio = precioDecimal,

                Categoria =
                    string.IsNullOrWhiteSpace(Categoria)
                        ? "Sin categoría"
                        : Categoria.Trim(),

                ImagenUrl =
                    ImagenUrl.Trim()
            };

            if (EsEdicion)
            {
                _videoJuegoRepository.Actualizar(
                    videojuego);
            }
            else
            {
                _videoJuegoRepository.Agregar(
                    videojuego);
            }

            await Shell.Current.GoToAsync("..");
        }
    }
}