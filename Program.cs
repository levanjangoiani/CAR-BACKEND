using Car.Data;
using Car.Repository.Implementation;
using Car.Repository.Service;
using Microsoft.EntityFrameworkCore;
using System;
// Add this using directive for Npgsql support
using Npgsql.EntityFrameworkCore.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CarsDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"),
        o => o.EnableRetryOnFailure())); // retry network glitches

builder.Services.AddScoped<ICarsService, CarRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowNetlify",
        policy => policy
            .WithOrigins("https://angular-project-with-my-back-front.netlify.app") // ???? Netlify URL
            .AllowAnyHeader()
            .AllowAnyMethod());
});




var app = builder.Build();

app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowNetlify");


app.MapControllers();

app.Run();
