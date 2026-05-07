using projekt.Interfaces;
using projekt.Models;

namespace projekt.Services;

public class WeatherService
{
    private readonly IWeatherProvider _provider;

    public WeatherService(IWeatherProvider provider)
    {
        _provider = provider;
    }

    public async Task<WeatherData> GetWeatherAsync(string city)
    {
        return await _provider.GetWeatherAsync(city);
    }
}