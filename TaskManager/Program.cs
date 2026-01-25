using TaskManager.Middleware;
using TaskManager.Repositories;
using TaskManager.Repositories.Interfaces;
using TaskManager.Services;
using TaskManager.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
// builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddTransient<IWeatherForecastService, WeatherForecastService>();

builder.Services.AddSingleton<ITaskRepository, TaskRepository>();
builder.Services.AddSingleton<ITaskService, TaskService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseMiddleware<RequestTimingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();

