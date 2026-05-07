using projekt.Models;
using projekt.Providers;
using projekt.Services;

namespace projekt;

class Program
{
    static async Task Main()
    {
        var provider = new OpenWeatherProvider();
        var weatherService = new WeatherService(provider);
        var statsService = new StatisticsService();

        while (true)
        {

            Console.WriteLine("===== WEATHER APP =====");
            Console.WriteLine("1 - Current weather");
            Console.WriteLine("2 - Compare cities");
            Console.WriteLine("0 - Exit");
            Console.Write("Choose option: ");

            string choice = Console.ReadLine();

            if (choice == "0")
                break;

            try
            {
                if (choice == "1")
                {
                    Console.Write("Enter city: ");
                    string city = Console.ReadLine();

                    var weather = await weatherService.GetWeatherAsync(city);

                    PrintWeather(weather);
                }
                else if (choice == "2")
                {
                    List<WeatherData> list = new();

                    Console.Write("First city: ");
                    list.Add(await weatherService.GetWeatherAsync(Console.ReadLine()));

                    Console.Write("Second city: ");
                    list.Add(await weatherService.GetWeatherAsync(Console.ReadLine()));

                    foreach (var item in list)
                    {
                        PrintWeather(item);
                    }

                    Console.WriteLine();
                    Console.WriteLine($"Average temp: {statsService.GetAverageTemperature(list):0.0} °C");
                    Console.WriteLine($"Max temp: {statsService.GetMaxTemperature(list):0.0} °C");
                    Console.WriteLine($"Min temp: {statsService.GetMinTemperature(list):0.0} °C");
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static void PrintWeather(WeatherData weather)
    {
        Console.WriteLine();
        Console.WriteLine($"City: {weather.City}");
        Console.WriteLine($"Temperature: {weather.Temperature} °C");
        Console.WriteLine($"Humidity: {weather.Humidity}%");
        Console.WriteLine($"Wind: {weather.WindSpeed} km/h");
    }
}