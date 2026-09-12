using BackEndAPI.Models;

namespace BackEndAPI.Data
{
    public static class DataSeeder
    {
        public static void Seed(ApiDBContext context)
        {
            if (context.VideoGames.Any()) return;

            var lista = new[]
            {
                new Videojuego
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "The Legend of Zelda: Breath of the Wild",
                    Descripcion = "An open-world action-adventure game set in the kingdom of Hyrule.",
                    Precio = 59.99m,
                    Categoria = "Action-Adventure",
                    ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQjpMgXIem2QtsglcBBBNAVqwbeNuLTd6CVOZ-NZqSzgg&s=10"
                },
                new Videojuego
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Super Mario Odyssey",
                    Descripcion = "A 3D platformer where Mario travels across various worlds to rescue Princess Peach.",
                    Precio = 49.99m,
                    Categoria = "Platformer",
                    ImagenUrl = "https://fotografias-neox.atresmedia.com/clipping/cmsimages02/2017/10/27/DBE87618-DD95-44DE-BDDE-C5F4B4DD420B/98.jpg?crop=1280,720,x0,y0&width=1900&height=1069&optimize=high&format=webply"
                },
                new Videojuego
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "God of War",
                    Descripcion = "An action-adventure game following Kratos and his son Atreus on a journey through Norse mythology.",
                    Precio = 39.99m,
                    Categoria = "Action",
                    ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTO3YA-Q1mQ5ISQNkxgk14j5QrqtRqbocpRdRZrq6ArfQ&s=10"
                },
                new Videojuego 
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Minecraft",
                    Descripcion = "A sandbox game that allows players to build and explore virtual worlds made of blocks.",
                    Precio = 26.95m,
                    Categoria = "Sandbox",
                    ImagenUrl = "https://store-images.s-microsoft.com/image/apps.17382.13510798885735219.9735d495-578c-4a4c-b892-3eb3a780b3a0.d3792486-cf98-40c0-a2c1-d6443f0e2b70"
                },
                new Videojuego
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Fortnite",
                    Descripcion = "A battle royale game where players fight to be the last one standing.",
                    Precio = 0.00m,
                    Categoria = "Battle Royale",
                    ImagenUrl = "https://m.media-amazon.com/images/M/MV5BMTZlMmIxM2EtN2Y4Zi00M2ZhLTk3NzgtNjJmZTU0MTQ3YjcwXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg"
                },
                new Videojuego
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "The Witcher 3: Wild Hunt",
                    Descripcion = "An open-world RPG where players control Geralt of Rivia, a monster hunter.",
                    Precio = 29.99m,
                    Categoria = "RPG",
                    ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQQVgbBO94MxvAOuG1DRzLCnkCFZX5jkn2fsXh-VMAefGbc2PaBBazvjUU&s=10"
                },
                new Videojuego
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Red Dead Redemption 2",
                    Descripcion = "An open-world action-adventure game set in the American Wild West.",
                    Precio = 59.99m,
                    Categoria = "Action-Adventure",
                    ImagenUrl = "https://store-images.s-microsoft.com/image/apps.34695.68182501197884443.ac728a87-7bc1-4a0d-8bc6-0712072da93c.25816f86-f27c-4ade-ae29-222661145f1f"
                },
                new Videojuego
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Overwatch",
                    Descripcion = "A team-based multiplayer first-person shooter with a diverse cast of heroes.",
                    Precio = 39.99m,
                    Categoria = "First-Person Shooter",
                    ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQpxCHZfaFrQBuVALdTfoXhKk_DCKvzFWWGoYLEcdBeFA&s=10"
                },
                new Videojuego
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Silksong",
                    Descripcion = " GOTY",
                    Precio = 59.99m,
                    Categoria = "Action-Adventure",
                    ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQaX_b29uICS63IOtcnK-8evvwnq6ckWIorUDO-fj9ol9Aie9ltwQg2eLev&s=10"
                },
                new Videojuego
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Hollow Knight",
                    Descripcion = "A challenging action-adventure game set in a dark, mysterious world.",
                    Precio = 14.99m,
                    Categoria = "Metroidvania",
                    ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRdQ-Vfmh2A7vrIuNOll2cLz8235_zoFmvMAJquW7-1PQ&s=10"
                }

            };
            context.VideoGames.AddRange(lista);
            context.SaveChanges();
        }
    }
}
