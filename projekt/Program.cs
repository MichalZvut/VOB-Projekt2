using projekt.Providers;

namespace projekt;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Weather App");

        var provider = new OpenWeatherProvider();

        var weather = await provider.GetWeatherAsync("Prague");

        Console.WriteLine($"City: {weather.City}");
        Console.WriteLine($"Temperature: {weather.Temperature} °C");
        Console.WriteLine($"Humidity: {weather.Humidity}%");
        Console.WriteLine($"Wind: {weather.WindSpeed} km/h");
    }
}