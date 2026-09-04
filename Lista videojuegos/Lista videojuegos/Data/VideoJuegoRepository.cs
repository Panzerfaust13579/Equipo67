using System;
using Lista_videojuegos.Models;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lista_videojuegos.Data
{
    public class VideoJuegoRepository
    {
        private readonly List<Videojuego> _videojuegos =
            [
                new(){ Id = "1", Nombre = "Silksong", Descripcion = "Mejor juego del año y GOTY", Categoria ="Metroidvania", Precio = 227.99m, ImagenUrl = "https://example.com/silksong.jpg" },
                new(){ Id = "2", Nombre = "Hollow Knight", Descripcion = "Juego de plataformas y acción en 2D", Categoria ="Metroidvania", Precio = 19.99m, ImagenUrl = "https://example.com/hollowknight.jpg" },
                new(){ Id = "3", Nombre = "Celeste", Descripcion = "Juego de plataformas y aventura", Categoria ="Plataformas", Precio = 19.99m, ImagenUrl = "https://example.com/celeste.jpg" },
                new(){ Id = "4", Nombre = "The Legend of Zelda: Breath of the Wild", Descripcion = "Juego de acción y aventura en mundo abierto", Categoria ="Aventura", Precio = 59.99m, ImagenUrl = "https://example.com/breathofthewild.jpg" },
                new(){ Id = "5", Nombre = "Super Mario Odyssey", Descripcion = "Juego de plataformas y aventura en 3D", Categoria ="Plataformas", Precio = 59.99m, ImagenUrl = "https://example.com/supermarioodyssey.jpg" },
                new(){ Id = "6", Nombre = "Hades", Descripcion = "Juego de acción y rol con elementos roguelike", Categoria ="Roguelike", Precio = 24.99m, ImagenUrl = "https://example.com/hades.jpg" },
                new(){ Id = "7", Nombre = "Stardew Valley", Descripcion = "Juego de simulación y rol en el que gestionas una granja", Categoria ="Simulación", Precio = 14.99m, ImagenUrl = "https://example.com/stardewvalley.jpg" },
                new(){ Id = "8", Nombre = "Minecraft", Descripcion = "Juego de construcción y supervivencia en un mundo abierto", Categoria ="Sandbox", Precio = 26.95m, ImagenUrl = "https://example.com/minecraft.jpg" },
                new(){ Id = "9", Nombre = "The Witcher 3: Wild Hunt", Descripcion = "Juego de rol y acción en un mundo abierto", Categoria ="RPG", Precio = 39.99m, ImagenUrl = "https://example.com/witcher3.jpg" },
                new(){ Id = "10", Nombre = "Dark Souls III", Descripcion = "Juego de rol y acción con un alto nivel de dificultad", Categoria ="RPG", Precio = 59.99m, ImagenUrl = "https://example.com/darksouls3.jpg" }
            ];

        public List<Videojuego> GetAllVideojuegos() => _videojuegos;

        public Videojuego GetVideojuegoById(string id) => _videojuegos.FirstOrDefault(v => v.Id == id);

        public void AddVideojuego(Videojuego videojuego)
        {
            _videojuegos.Add(videojuego);
        }

        public void UpdateVideojuego(Videojuego videojuego)
        {
            var index = _videojuegos.FindIndex(v => v.Id == videojuego.Id);

            if (index >= 0)
            {
                _videojuegos[index] = videojuego;
            }
        }
    }
}