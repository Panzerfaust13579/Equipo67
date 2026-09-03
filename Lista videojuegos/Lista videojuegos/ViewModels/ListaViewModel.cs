using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lista_videojuegos.Models;
using Lista_videojuegos.Data;
using Lista_videojuegos.Views;

namespace Lista_videojuegos.ViewModels
{
    public partial class ListaViewModel : ObservableObject
    {
        private readonly VideoJuegoRepository _videoJuegoRepository;

        [ObservableProperty]
        private ObservableCollection<Videojuego> videojuegos;

        public ListaViewModel(VideoJuegoRepository videoJuegoRepository)
        {
            _videoJuegoRepository = videoJuegoRepository;
            Videojuegos = new ObservableCollection<Videojuego>(_videoJuegoRepository.GetAllVideojuegos());
        }

        [RelayCommand]
        public async Task NavigateToDetalleAsync(Videojuego videojuego)
        {
            if (videojuego is null)
                return;

            await Shell.Current.GoToAsync($"/{nameof(DetallePage)}?Id={videojuego.Id}");
        }

        [RelayCommand]
        public async Task NavigateToFavoritosAsync()
        {
            await Shell.Current.GoToAsync("favoritos");
        }
    }
}