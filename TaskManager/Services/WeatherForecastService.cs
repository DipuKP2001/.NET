using TaskManager.Services.Interfaces;

namespace TaskManager.Services;

public class WeatherForecastService : IWeatherForecastService
{
    Guid _guid = Guid.NewGuid();
    
    private static readonly string[] Forecasts = new[]
    {
        "Sunny", "Cloudy", "Rainy", "Windy", "Stormy"
    };
    
    public IEnumerable<string> GetForecasts()
    {
        Console.WriteLine($"[WeatherForecastService] Instance ID: {GetHashCode()} GUID: {_guid}");
        return Forecasts;
    }
}