using Salesman.Models.Distance;

namespace Salesman.Models.Algorithms;
public class LazyAlgorithm : IPathAlgorithm
{
    IDistance _distance;
    public LazyAlgorithm(IDistance distance)
    {
        _distance = distance;
    }
    public Solution PlanRoute(List<City> cities)
    {
        var solution = new Solution(_distance);
        
        var currentCity = cities.First();
        solution.Route.Add(currentCity);

        foreach(var city in cities.GetRange(1, cities.Count() - 1))
        {
            solution.Route.Add(city);
        }

        return solution;
    }
}