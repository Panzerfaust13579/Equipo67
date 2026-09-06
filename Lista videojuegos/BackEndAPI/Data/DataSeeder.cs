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
                    ImagenUrl = "https://example.com/zelda.jpg"
                },
                new Videojuego
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Super Mario Odyssey",
                    Descripcion = "A 3D platformer where Mario travels across various worlds to rescue Princess Peach.",
                    Precio = 49.99m,
                    Categoria = "Platformer",
                    ImagenUrl = "https://example.com/mario.jpg"
                },
                new Videojuego
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "God of War",
                    Descripcion = "An action-adventure game following Kratos and his son Atreus on a journey through Norse mythology.",
                    Precio = 39.99m,
                    Categoria = "Action",
                    ImagenUrl = "https://example.com/godofwar.jpg"
                },
                new Videojuego 
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Minecraft",
                    Descripcion = "A sandbox game that allows players to build and explore virtual worlds made of blocks.",
                    Precio = 26.95m,
                    Categoria = "Sandbox",
                    ImagenUrl = "https://example.com/minecraft.jpg"
                },
                new Videojuego
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Fortnite",
                    Descripcion = "A battle royale game where players fight to be the last one standing.",
                    Precio = 0.00m,
                    Categoria = "Battle Royale",
                    ImagenUrl = "https://example.com/fortnite.jpg"
                },
                new Videojuego
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "The Witcher 3: Wild Hunt",
                    Descripcion = "An open-world RPG where players control Geralt of Rivia, a monster hunter.",
                    Precio = 29.99m,
                    Categoria = "RPG",
                    ImagenUrl = "https://example.com/witcher3.jpg"
                },
                new Videojuego
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Red Dead Redemption 2",
                    Descripcion = "An open-world action-adventure game set in the American Wild West.",
                    Precio = 59.99m,
                    Categoria = "Action-Adventure",
                    ImagenUrl = "https://example.com/rdr2.jpg"
                },
                new Videojuego
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Overwatch",
                    Descripcion = "A team-based multiplayer first-person shooter with a diverse cast of heroes.",
                    Precio = 39.99m,
                    Categoria = "First-Person Shooter",
                    ImagenUrl = "https://example.com/overwatch.jpg"
                },
                new Videojuego
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Silksong",
                    Descripcion = " GOTY",
                    Precio = 59.99m,
                    Categoria = "Action-Adventure",
                    ImagenUrl = "https://example.com/silksong.jpg"
                },
                new Videojuego
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Hollow Knight",
                    Descripcion = "A challenging action-adventure game set in a dark, mysterious world.",
                    Precio = 14.99m,
                    Categoria = "Metroidvania",
                    ImagenUrl = "https://example.com/hollowknight.jpg"
                }

            };
            context.VideoGames.AddRange(lista);
            context.SaveChanges();
        }
    }
}
