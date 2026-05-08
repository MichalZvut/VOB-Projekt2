using System.Text.Json;
using projekt.Interfaces;
using projekt.Models;

namespace projekt.Providers;

public class OpenWeatherProvider : IWeatherProvider
{
    private readonly HttpClient _httpClient = new();

    public OpenWeatherProvider()
    {
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "WeatherApp");
    }

    public async Task<WeatherData> GetWeatherAsync(string city)
    {
        string encodedCity = Uri.EscapeDataString(city);

        string url = $"https://wttr.in/{encodedCity}?format=j1";

        var response = await _httpClient.GetStringAsync(url);

        using JsonDocument doc = JsonDocument.Parse(response);

        var current = doc.RootElement
            .GetProperty("current_condition")[0];

        return new WeatherData
        {
            City = city,
            Temperature = double.Parse(
                current.GetProperty("temp_C").GetString()
            ),
            WindSpeed = double.Parse(
                current.GetProperty("windspeedKmph").GetString()
            ),
            Humidity = int.Parse(
                current.GetProperty("humidity").GetString()
            )
        };
    }
}