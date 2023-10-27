using Microsoft.EntityFrameworkCore;
using GameStoreBeKPeter.Context;
using GameStoreBeKPeter.Repositories;
using GameStoreBeKPeter.Users;
using GameStoreBeKPeter.VideoGames;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(logging => { logging.AddConsole(); });


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ContextBasic>(opt =>
{
    opt.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GamesInventory;Trusted_Connection=True");
});

builder.Services.AddTransient < ICrud<User>, UsersRepo>();
builder.Services.AddTransient<ICrud<VideoGame>, VideoGamesRepo>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
