using System.Threading.Tasks;
using Lista_videojuegos.Models;
using Lista_videojuegos.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Lista_videojuegos.ViewModels
{
    [QueryProperty(nameof(Id), "Id")]
    public partial class DetalleViewModel : ObservableObject
    {
        private readonly VideoJuegoRepository _videoJuegoRepository;
        private readonly FavoritosViewModel _favoritosViewModel;

        [ObservableProperty]
        private string id;

        [ObservableProperty]
        private Videojuego videoJuego;

        public DetalleViewModel(
            VideoJuegoRepository videoJuegoRepository,
            FavoritosViewModel favoritosViewModel)
        {
            _videoJuegoRepository = videoJuegoRepository;
            _favoritosViewModel = favoritosViewModel;
        }

        partial void OnIdChanged(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                VideoJuego = _videoJuegoRepository.GetVideojuegoById(value);
            }
        }

        [RelayCommand]
        public void AgregarFavorito()
        {
            if (VideoJuego == null)
                return;

            _favoritosViewModel.AgregarFavorito(VideoJuego);
        }

        [RelayCommand]
        public async Task EditarAsync()
        {
            if (VideoJuego == null)
                return;

            await Shell.Current.GoToAsync($"videojuego-form?Id={VideoJuego.Id}");
        }
    }
}