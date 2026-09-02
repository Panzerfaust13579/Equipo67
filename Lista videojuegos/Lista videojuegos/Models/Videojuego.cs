using System;
using System.Collections.Generic;
using System.Text;

namespace Lista_videojuegos.Models
{
    public class Videojuego
    {
        public string Id { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public string ImagenUrl { get; set; } = string.Empty;
    }
}
