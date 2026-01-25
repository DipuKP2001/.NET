namespace TaskManager.Services.Interfaces;

public interface IWeatherForecastService
{
    public IEnumerable<string> GetForecasts();
}