using Salesman.Models;

namespace Salesman.Tour.IO;

public class STDIOHandler : IIOHandler
{
    public List<City> ReadCities()
    {
        using (var reader = Console.In)
        {
            return ParseCities(reader);
        }
    }

    private List<City> ParseCities(TextReader reader)
    {
        var cities = new List<City>();
        string? s;

        while ((s = reader.ReadLine()) != null)
        {
            cities.Add(City.FromString(s));
        }

        return cities;
    }
    public void WriteSolution(Solution solution)
    {
        var output = solution.ToString();

        using (var writer = Console.Out)
        {
            writer.Write(solution.ToString());
        }
    }
}