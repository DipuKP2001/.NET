namespace TaskManager.Services;

public interface IWeatherForecastService
{
    public IEnumerable<string> GetForecasts();
}