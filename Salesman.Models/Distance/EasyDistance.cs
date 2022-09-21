using Salesman.Models;
using System;

namespace Salesman.Models.Distance;
public class EasyDistance : IDistance
{
    public double DistanceBetweenCities(City city1, City city2)
    {
        double dlon = Radians(city2.Longitude - city1.Longitude);
        double dlat = Radians(city2.Latitude - city1.Latitude);

        double a = (Math.Sin(dlat / 2) * Math.Sin(dlat / 2)) + Math.Cos(Radians(city1.Latitude)) * Math.Cos(Radians(city2.Latitude)) * (Math.Sin(dlon / 2) * Math.Sin(dlon / 2));
        double angle = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        return angle * 6371;
    }

    public double GetRouteDistance(List<City> route)
    {
        double total = 0;
        var currentCity = route[0];
        foreach (var city in route.GetRange(1, route.Count() - 1))
        {
            total += this.DistanceBetweenCities(currentCity, city);
            currentCity = city;
        }

        return Math.Round(total);
    }
    public double Radians(double x)
    {
        return x * Math.PI / 180;
    }
}