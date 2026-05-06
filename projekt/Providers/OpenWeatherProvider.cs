using System.Text.Json;
using projekt.Interfaces;
using projekt.Models;

namespace projekt.Providers;

public class OpenWeatherProvider : IWeatherProvider
{
    private readonly HttpClient _httpClient;

    public OpenWeatherProvider()
    {
        _httpClient = new HttpClient();
    }

    public async Task<WeatherData> GetWeatherAsync(string city)
    {
        double latitude = 50.08;
        double longitude = 14.43;

        if (city.ToLower() == "brno")
        {
            latitude = 49.19;
            longitude = 16.61;
        }

        string url =
            $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m,wind_speed_10m,relative_humidity_2m";

        var response = await _httpClient.GetStringAsync(url);

        using JsonDocument doc = JsonDocument.Parse(response);

        var current = doc.RootElement.GetProperty("current");

        return new WeatherData
        {
            City = city,
            Temperature = current.GetProperty("temperature_2m").GetDouble(),
            Humidity = current.GetProperty("relative_humidity_2m").GetInt32(),
            WindSpeed = current.GetProperty("wind_speed_10m").GetDouble()
        };
    }
}