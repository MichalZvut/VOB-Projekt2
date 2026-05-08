namespace projekt.Services;

public class InputService
{
    public string GetCityName()
    {
        while (true)
        {
            Console.Write("Enter city: ");
            string city = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(city))
                return city;

            Console.WriteLine("City cannot be empty.");
        }
    }

    public string GetMenuChoice()
    {
        Console.Write("Choose option: ");
        return Console.ReadLine();
    }
}