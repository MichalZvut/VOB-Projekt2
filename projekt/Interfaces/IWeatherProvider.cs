using projekt.Models;

namespace projekt.Interfaces;

public interface IWeatherProvider
{
    Task<WeatherData> GetWeatherAsync(string city);
}