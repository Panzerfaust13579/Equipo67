using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lista_videojuegos.Data;
using Lista_videojuegos.Models;
using Lista_videojuegos.Views;

namespace Lista_videojuegos.ViewModels
{
    public partial class ListaViewModel : ObservableObject
    {
        private readonly VideoJuegoRepository _videoJuegoRepository;

        private ObservableCollection<Videojuego> _videojuegos = new();

        private bool _isLoading;
        private bool _hasError;
        private string _errorMessage = string.Empty;

        public ObservableCollection<Videojuego> Videojuegos
        {
            get => _videojuegos;
            set => SetProperty(ref _videojuegos, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public bool HasError
        {
            get => _hasError;
            set => SetProperty(ref _hasError, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public IAsyncRelayCommand<Videojuego> NavigateToDetalleCommand { get; }

        public IAsyncRelayCommand NavigateToFavoritosCommand { get; }

        public IAsyncRelayCommand NavigateToAgregarJuegoCommand { get; }

        public IAsyncRelayCommand CargarVideojuegosCommand { get; }

        public ListaViewModel(VideoJuegoRepository videoJuegoRepository)
        {
            _videoJuegoRepository = videoJuegoRepository;

            Videojuegos = _videoJuegoRepository.ObtenerTodos();

            NavigateToDetalleCommand =
                new AsyncRelayCommand<Videojuego>(
                    NavigateToDetalleAsync);

            NavigateToFavoritosCommand =
                new AsyncRelayCommand(
                    NavigateToFavoritosAsync);

            NavigateToAgregarJuegoCommand =
                new AsyncRelayCommand(
                    NavigateToAgregarJuegoAsync);

            CargarVideojuegosCommand =
                new AsyncRelayCommand(
                    CargarVideojuegosAsync);

            _ = CargarVideojuegosAsync();
        }

        public async Task CargarVideojuegosAsync()
        {
            IsLoading = true;
            HasError = false;
            ErrorMessage = string.Empty;

            try
            {
                await _videoJuegoRepository.CargarVideojuegosAsync();
            }
            catch (TaskCanceledException)
            {
                HasError = true;
                ErrorMessage =
                    "La carga de videojuegos fue cancelada o tardó demasiado.";
            }
            catch (HttpRequestException)
            {
                HasError = true;
                ErrorMessage =
                    "No se pudo conectar con la API.";
            }
            catch (JsonException)
            {
                HasError = true;
                ErrorMessage =
                    "Los datos recibidos de la API no tienen un formato válido.";
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task NavigateToDetalleAsync(
            Videojuego videojuego)
        {
            if (videojuego == null)
                return;

            await Shell.Current.GoToAsync(
                $"/{nameof(DetallePage)}?Id={videojuego.Id}");
        }

        private async Task NavigateToFavoritosAsync()
        {
            await Shell.Current.GoToAsync("favoritos");
        }

        private async Task NavigateToAgregarJuegoAsync()
        {
            await Shell.Current.GoToAsync("videojuego-form");
        }

        public void RefrescarVideojuegos()
        {
            Videojuegos = _videoJuegoRepository.ObtenerTodos();
        }
    }
}