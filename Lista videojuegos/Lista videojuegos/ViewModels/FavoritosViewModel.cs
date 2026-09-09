using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lista_videojuegos.Models;

namespace Lista_videojuegos.ViewModels
{
    public partial class FavoritosViewModel : ObservableObject
    {
        private ObservableCollection<Videojuego> _productos = new();

        public ObservableCollection<Videojuego> Productos
        {
            get => _productos;
            set => SetProperty(ref _productos, value);
        }

        public IRelayCommand<Videojuego> AgregarFavoritoCommand { get; }

        public IRelayCommand<Videojuego> EliminarFavoritoCommand { get; }

        public FavoritosViewModel()
        {
            AgregarFavoritoCommand =
                new RelayCommand<Videojuego>(AgregarFavorito);

            EliminarFavoritoCommand =
                new RelayCommand<Videojuego>(EliminarFavorito);
        }

        public void AgregarFavorito(Videojuego videojuego)
        {
            if (videojuego == null)
                return;

            if (!Productos.Any(p => p.Id == videojuego.Id))
            {
                Productos.Add(videojuego);
            }
        }

        public void EliminarFavorito(Videojuego videojuego)
        {
            if (videojuego == null)
                return;

            var favorito =
                Productos.FirstOrDefault(
                    p => p.Id == videojuego.Id);

            if (favorito != null)
            {
                Productos.Remove(favorito);
            }
        }
    }
}