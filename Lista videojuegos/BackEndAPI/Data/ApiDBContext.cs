using Microsoft.EntityFrameworkCore;
using BackEndAPI.Models;

namespace BackEndAPI.Data
{
    public class ApiDBContext : DbContext
    {
        public ApiDBContext(DbContextOptions<ApiDBContext> options) : base(options)
        {
        }

        public DbSet<Videojuego> VideoGames { get; set; } = null!;
    }
}
