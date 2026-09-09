using Android.Telephony;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lista_videojuegos.Data;
using Lista_videojuegos.Models;
using Lista_videojuegos.Views;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lista_videojuegos.ViewModels
{
    public partial class ListaViewModel : ObservableObject
    {
        private readonly VideoJuegoRepository _videoJuegoRepository;

        [ObservableProperty]
        private ObservableCollection<Videojuego> videojuegos = new();

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private bool hasError;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        public ListaViewModel(
            VideoJuegoRepository videoJuegoRepository)
        {
            _videoJuegoRepository = videoJuegoRepository;

            Videojuegos =
                _videoJuegoRepository.ObtenerTodos();
        }

        // Método público utilizado por ListaPage.xaml.cs
        public async Task CargarVideojuegosAsync()
        {
            await CargarVideojuegos();
        }

        // READ
        [RelayCommand]
        private async Task CargarVideojuegos()
        {
            IsLoading = true;
            HasError = false;
            ErrorMessage = string.Empty;

            try
            {
                await _videoJuegoRepository
                    .CargarVideojuegosAsync();
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

        // READ - DETALLE
        [RelayCommand]
        private async Task NavigateToDetalle(
            Videojuego videojuego)
        {
            if (videojuego == null)
                return;

            await Shell.Current.GoToAsync(
                $"{nameof(DetallePage)}?Id={videojuego.Id}");
        }

        // READ - FAVORITOS
        [RelayCommand]
        private async Task NavigateToFavoritos()
        {
            await Shell.Current.GoToAsync("favoritos");
        }

        // CREATE
        [RelayCommand]
        private async Task NavigateToAgregarJuego()
        {
            await Shell.Current.GoToAsync(
                "videojuego-form");
        }

        public void RefrescarVideojuegos()
        {
            Videojuegos =
                _videoJuegoRepository.ObtenerTodos();
        }
    }
}