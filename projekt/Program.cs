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
        var inputService = new InputService();

        while (true)
        {
            Console.Clear();

            Console.WriteLine("===== WEATHER APP =====");
            Console.WriteLine("1 - Current weather");
            Console.WriteLine("2 - Compare cities");
            Console.WriteLine("0 - Exit");

            string choice = inputService.GetMenuChoice();

            if (choice == "0")
                break;

            try
            {
                if (choice == "1")
                {
                    string city = inputService.GetCityName();

                    var weather = await weatherService.GetWeatherAsync(city);

                    PrintWeather(weather);
                }
                else if (choice == "2")
                {
                    List<WeatherData> list = new();

                    Console.WriteLine("First city:");
                    string firstCity = inputService.GetCityName();
                    list.Add(await weatherService.GetWeatherAsync(firstCity));

                    Console.WriteLine("Second city:");
                    string secondCity = inputService.GetCityName();
                    list.Add(await weatherService.GetWeatherAsync(secondCity));

                    foreach (var item in list)
                    {
                        PrintWeather(item);
                    }

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

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    static void PrintWeather(WeatherData weather)
    {
        Console.WriteLine($"City: {weather.City}");
        Console.WriteLine($"Temperature: {weather.Temperature} °C");
        Console.WriteLine($"Humidity: {weather.Humidity}%");
        Console.WriteLine($"Wind: {weather.WindSpeed} km/h");
    }
}