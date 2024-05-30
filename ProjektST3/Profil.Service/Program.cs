using Microsoft.EntityFrameworkCore;
using Profil.Api.Extensions;
using Profil.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProfileServices();
var constring = "server=localhost;database=Profile;User=root;Password=root;";
builder.Services.AddDbContext<ProfilDbContext>(options => options.UseMySql(constring, ServerVersion.AutoDetect(constring)));
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
