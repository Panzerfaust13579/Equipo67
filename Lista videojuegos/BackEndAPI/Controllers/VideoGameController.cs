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



        // POST: api/VideoGame
        [HttpPost("GuardarVideoJuego")]
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

    }
}
