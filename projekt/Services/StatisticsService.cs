using projekt.Models;

namespace projekt.Services;

public class StatisticsService
{
    public double GetAverageTemperature(List<WeatherData> data)
    {
        return data.Average(x => x.Temperature);
    }

    public double GetMaxTemperature(List<WeatherData> data)
    {
        return data.Max(x => x.Temperature);
    }

    public double GetMinTemperature(List<WeatherData> data)
    {
        return data.Min(x => x.Temperature);
    }
}