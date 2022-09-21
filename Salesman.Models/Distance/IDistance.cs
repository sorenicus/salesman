namespace Salesman.Models.Distance;
public interface IDistance
{
    double DistanceBetweenCities(City city1, City city2);
    double GetRouteDistance(List<City> route);
    double Radians(double x);
}