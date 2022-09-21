namespace Salesman.Models;
public class City
{
    public string Name { get; set; } = "Unknown";
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public static City FromString(string input)
    {
        if(string.IsNullOrEmpty(input))
        {
            throw new ArgumentNullException();
        }

        var splits = input.Split(",");

        if(splits.Length != 5)
        {
            throw new ArgumentException("Invalid number of fields in row");
        }

        var city = new City();

        city.Name = splits[0];

        double latDeg = 0;
        if(!double.TryParse(splits[1], out latDeg))
        {
            throw new Exception("Latitude Degrees is not a number");
        }

        double latMin = 0;
        if(!double.TryParse(splits[2], out latMin))
        {
            throw new Exception("Latitude Minutes is not a number");
        } 

        double longDeg = 0;
        if(!double.TryParse(splits[3], out longDeg))
        {
            throw new Exception("Longitude Degrees is not a number");
        }

        double longMin = 0;
        if(!double.TryParse(splits[4], out longMin))
        {
            throw new Exception("Longitude Minutes is not a number");
        } 

        city.Latitude = latDeg + (latMin / 60);
        city.Longitude = longDeg + (longMin / 60);

        return city;
    }

    public double ConvertToDecimalDegrees(double degrees, double minutes)
    {
        return degrees + (minutes / 60);
    }
}
