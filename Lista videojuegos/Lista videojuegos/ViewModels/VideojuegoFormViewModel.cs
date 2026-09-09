using Android.Telephony;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lista_videojuegos.Data;
using Lista_videojuegos.Models;
using System;
using System.Threading.Tasks;
using static Android.Icu.Text.CaseMap;
using static Android.Util.EventLogTags;

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

        public VideojuegoFormViewModel(
            VideoJuegoRepository videoJuegoRepository)
        {
            _videoJuegoRepository =
                videoJuegoRepository;
        }

        partial void OnIdChanged(string value)
        {
            CargarDatos(value);
        }

        partial void OnErrorMessageChanged(string value)
        {
            HasError =
                !string.IsNullOrEmpty(value);
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

        // CREATE / UPDATE
        [RelayCommand]
        private async Task Guardar()
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