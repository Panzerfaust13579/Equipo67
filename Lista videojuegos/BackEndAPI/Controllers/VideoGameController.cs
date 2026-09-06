using System;
using System.Linq;
using System.Threading.Tasks;
using BackEndAPI.Data;
using Microsoft.AspNetCore.Mvc;
using BackEndAPI.DTO;
using BackEndAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoGameController : ControllerBase
    {
        private readonly ApiDBContext _context;

        public VideoGameController(ApiDBContext context)
        {
            _context = context;
        }

        // GET: api/VideoGame (Muestra todos los videojuegos)
        [HttpGet("GetVideoJuegos")]
        public async Task<IActionResult> GetVideoGames()
        {
            var videoGames = await _context.VideoGames.Select(vg => new VideoGameDTO
            {
                Id = vg.Id,
                Nombre = vg.Nombre,
                Descripcion = vg.Descripcion,
                Precio = vg.Precio,
                Categoria = vg.Categoria,
                ImagenUrl = vg.ImagenUrl
            }).ToListAsync();


            return Ok(videoGames);
        }

        // GET: api/VideoGame/{id} (Busca un videojuego por su ID)
        [HttpGet("GetVideoJuego/{id}")]
        public async Task<IActionResult> GetVideoGame(string id)
        {
            var videoGame = await _context.VideoGames.FindAsync(id);
            if (videoGame == null)
            {
                return NotFound();
            }

            var videoGameDto = new VideoGameDTO
            {
                Id = videoGame.Id,
                Nombre = videoGame.Nombre,
                Descripcion = videoGame.Descripcion,
                Precio = videoGame.Precio,
                Categoria = videoGame.Categoria,
                ImagenUrl = videoGame.ImagenUrl
            };

            return Ok(videoGameDto);
        }



        // POST: api/VideoGame (Crea un nuevo videojuego)
        [HttpPost("CreateVideoJuego")]
        public async Task<IActionResult> CreateVideoGame([FromBody] VideoGameDTO videoGameDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var videoGame = new VideoGame
            {
                Id = string.IsNullOrWhiteSpace(videoGameDto.Id) ? Guid.NewGuid().ToString() : videoGameDto.Id,
                Nombre = videoGameDto.Nombre,
                Descripcion = videoGameDto.Descripcion,
                Precio = videoGameDto.Precio,
                Categoria = videoGameDto.Categoria,
                ImagenUrl = videoGameDto.ImagenUrl
            };

            _context.VideoGames.Add(videoGame);
            await _context.SaveChangesAsync();

            return Ok(videoGame);
        }

        // PUT: api/VideoGame/{id} (Actualiza un videojuego por su ID)
        [HttpPut("EditVideoJuego/{id}")]
        public async Task<IActionResult> UpdateVideoGame(string id, [FromBody] VideoGameDTO videoGameDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var videoGame = await _context.VideoGames.FindAsync(id);
            if (videoGame == null)
            {
                return NotFound();
            }

            videoGame.Nombre = videoGameDto.Nombre;
            videoGame.Descripcion = videoGameDto.Descripcion;
            videoGame.Precio = videoGameDto.Precio;
            videoGame.Categoria = videoGameDto.Categoria;
            videoGame.ImagenUrl = videoGameDto.ImagenUrl;

            _context.VideoGames.Update(videoGame);
            await _context.SaveChangesAsync();

            return Ok(videoGame);
        }

    }
}
