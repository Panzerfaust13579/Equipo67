using BackEndAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configurar el contexto de la base de datos con PostgreSQL
builder.Services.AddDbContext<ApiDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("MyDB")));


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApiDBContext>();

    // Aplica las migraciones pendientes automáticamente al iniciar
    db.Database.Migrate();

    // Seed the database with initial data
    DataSeeder.Seed(db);
    
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Evitar 404 en la raíz: redirige a /videogame, que es un endpoint útil para la API
app.MapGet("/", () => Results.Redirect("/swagger"));

// Endpoint de estado
app.MapGet("/health", () => Results.Ok(new { status = "OK" }));

app.Run();
