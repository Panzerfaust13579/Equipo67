using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.DTO
{
    public class UpdateVgDTO
    {
        public string Nombre { get; set; } = string.Empty;
        [Required]
        public string Descripcion { get; set; } = string.Empty;
        [Required]
        public decimal Precio { get; set; } = 0.0m;
        [Required]
        public string Categoria { get; set; } = string.Empty;
        public string ImagenUrl { get; set; } = string.Empty;
    }
}
