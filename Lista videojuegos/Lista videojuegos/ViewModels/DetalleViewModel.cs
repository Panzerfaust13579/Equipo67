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

        private string _id = string.Empty;
        private Videojuego? _videoJuego;

        public string Id
        {
            get => _id;
            set
            {
                if (SetProperty(ref _id, value))
                {
                    CargarVideojuego(value);
                }
            }
        }

        public Videojuego? VideoJuego
        {
            get => _videoJuego;
            set => SetProperty(ref _videoJuego, value);
        }

        public IRelayCommand AgregarFavoritoCommand { get; }

        public IAsyncRelayCommand EditarCommand { get; }

        public DetalleViewModel(
            VideoJuegoRepository videoJuegoRepository,
            FavoritosViewModel favoritosViewModel)
        {
            _videoJuegoRepository = videoJuegoRepository;
            _favoritosViewModel = favoritosViewModel;

            AgregarFavoritoCommand =
                new RelayCommand(AgregarFavorito);

            EditarCommand =
                new AsyncRelayCommand(EditarAsync);
        }

        private void CargarVideojuego(string id)
        {
            if (string.IsNullOrEmpty(id))
                return;

            VideoJuego =
                _videoJuegoRepository.ObtenerPorId(id);
        }

        private void AgregarFavorito()
        {
            if (VideoJuego == null)
                return;

            _favoritosViewModel.AgregarFavorito(VideoJuego);
        }

        private async Task EditarAsync()
        {
            if (VideoJuego == null)
                return;

            await Shell.Current.GoToAsync(
                $"videojuego-form?Id={VideoJuego.Id}");
        }
    }
}