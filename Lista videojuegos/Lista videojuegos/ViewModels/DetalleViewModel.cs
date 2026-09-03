using Lista_videojuegos.Models;
using Lista_videojuegos.Data;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Lista_videojuegos.ViewModels
{
    [QueryProperty(nameof(Id), "Id")]
    public partial class DetalleViewModel : ObservableObject
    {
        private readonly VideoJuegoRepository _videoJuegoRepository;

        [ObservableProperty]
        private string id;

        [ObservableProperty]
        private Videojuego videoJuego;

        public DetalleViewModel(VideoJuegoRepository videoJuegoRepository)
        {
            _videoJuegoRepository = videoJuegoRepository;
        }

        partial void OnIdChanged(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                VideoJuego = _videoJuegoRepository.GetVideojuegoById(value);
            }
        }
    }
}
