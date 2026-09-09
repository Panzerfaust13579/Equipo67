using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Lista_videojuegos.Models;

namespace Lista_videojuegos.Data
{
    public class VideoJuegoRepository
    {
        private readonly HttpClient _httpClient;

        private readonly ObservableCollection<Videojuego> _videojuegos =
            new();

        public VideoJuegoRepository()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7159/")
            };
        }

        // Carga inicial desde el API
        public async Task CargarVideojuegosAsync()
        {
            var response = await _httpClient.GetAsync(
                "api/VideoGame/GetVideoJuegos");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var videojuegos =
                JsonSerializer.Deserialize<List<Videojuego>>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            if (videojuegos == null)
                return;

            _videojuegos.Clear();

            foreach (var videojuego in videojuegos)
            {
                _videojuegos.Add(videojuego);
            }
        }

        // READ
        public ObservableCollection<Videojuego> ObtenerTodos()
        {
            return _videojuegos;
        }

        // READ BY ID
        public Videojuego? ObtenerPorId(string id)
        {
            foreach (var videojuego in _videojuegos)
            {
                if (videojuego.Id == id)
                    return videojuego;
            }

            return null;
        }

        // CREATE
        public void Agregar(Videojuego videojuego)
        {
            if (videojuego == null)
                return;

            _videojuegos.Add(videojuego);
        }

        // UPDATE
        public void Actualizar(Videojuego videojuego)
        {
            if (videojuego == null)
                return;

            var existente = ObtenerPorId(videojuego.Id);

            if (existente == null)
                return;

            var indice = _videojuegos.IndexOf(existente);

            if (indice >= 0)
            {
                _videojuegos[indice] = videojuego;
            }
        }

        // DELETE
        public void Eliminar(string id)
        {
            var videojuego = ObtenerPorId(id);

            if (videojuego != null)
            {
                _videojuegos.Remove(videojuego);
            }
        }
    }
}