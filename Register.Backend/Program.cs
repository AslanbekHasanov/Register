using Microsoft.EntityFrameworkCore;
using Register.Backend.DataLayer;
using Register.Backend.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IService, Service>();

builder.Services.AddDbContext<RegistrDbContext>(option => 
option.UseNpgsql(builder.Configuration.GetConnectionString("RegistrConnectionString")));
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
