using Microsoft.AspNetCore.Mvc;
using TaskManager.Services;
using TaskManager.Services.Interfaces;

namespace TaskManager.Controllers;

[ApiController]
[Route("weatherforecast")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastService _service;

    public WeatherForecastController(IWeatherForecastService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var forecast = _service.GetForecasts();
        return Ok(forecast);
    }
}