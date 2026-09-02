using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lista_videojuegos.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace Lista_videojuegos.ViewModels
{
    public partial class FavoritosViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Videojuego> productos = new();

        [RelayCommand]
        public void AgregarFavorito(Videojuego videojuego)
        {
            if (videojuego == null)
                return;

            if (!Productos.Any(p => p.Id == videojuego.Id))
            {
                Productos.Add(videojuego);
            }
        }

        [RelayCommand]
        public void EliminarFavorito(Videojuego videojuego)
        {
            if (videojuego == null)
                return;

            Productos.Remove(videojuego);
        }
    }
}