using projekt.Providers;
using projekt.Services;

namespace projekt;

class Program
{
    static async Task Main()
    {
        try
        {
            Console.WriteLine("Weather App");
            Console.Write("Enter city: ");

            string city = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(city))
            {
                Console.WriteLine("City cannot be empty.");
                return;
            }

            var provider = new OpenWeatherProvider();
            var service = new WeatherService(provider);

            var weather = await service.GetWeatherAsync(city);

            Console.WriteLine();
            Console.WriteLine($"City: {weather.City}");
            Console.WriteLine($"Temperature: {weather.Temperature} °C");
            Console.WriteLine($"Humidity: {weather.Humidity}%");
            Console.WriteLine($"Wind: {weather.WindSpeed} km/h");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}