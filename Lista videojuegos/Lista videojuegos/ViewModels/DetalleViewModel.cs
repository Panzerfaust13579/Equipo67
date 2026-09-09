using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lista_videojuegos.Data;
using Lista_videojuegos.Models;

namespace Lista_videojuegos.ViewModels
{
    [QueryProperty(nameof(Id), "Id")]
    public partial class DetalleViewModel : ObservableObject
    {
        private readonly VideoJuegoRepository _videoJuegoRepository;
        private readonly FavoritosViewModel _favoritosViewModel;

        [ObservableProperty]
        private string id = string.Empty;

        [ObservableProperty]
        private Videojuego? videoJuego;

        public DetalleViewModel(
            VideoJuegoRepository videoJuegoRepository,
            FavoritosViewModel favoritosViewModel)
        {
            _videoJuegoRepository = videoJuegoRepository;
            _favoritosViewModel = favoritosViewModel;
        }

        partial void OnIdChanged(string value)
        {
            CargarVideojuego(value);
        }

        private void CargarVideojuego(string id)
        {
            if (string.IsNullOrEmpty(id))
                return;

            VideoJuego =
                _videoJuegoRepository.ObtenerPorId(id);
        }

        [RelayCommand]
        private void AgregarFavorito()
        {
            if (VideoJuego == null)
                return;

            _favoritosViewModel.AgregarFavorito(VideoJuego);
        }

        [RelayCommand]
        private async Task Editar()
        {
            if (VideoJuego == null)
                return;

            await Shell.Current.GoToAsync(
                $"videojuego-form?Id={VideoJuego.Id}");
        }

        [RelayCommand]
        private async Task Eliminar()
        {
            if (VideoJuego == null)
                return;

            bool confirmar =
                await Shell.Current.DisplayAlertAsync(
                    "Eliminar videojuego",
                    $"¿Estás seguro de que deseas eliminar \"{VideoJuego.Nombre}\"?",
                    "Sí",
                    "No");

            if (!confirmar)
                return;

            _videoJuegoRepository.Eliminar(VideoJuego.Id);

            await Shell.Current.GoToAsync("..");
        }
    }
}