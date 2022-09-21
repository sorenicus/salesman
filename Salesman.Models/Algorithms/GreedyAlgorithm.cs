using Salesman.Models.Distance;
namespace Salesman.Models.Algorithms;

public class GreedyAlgorithm : IPathAlgorithm
{
    private List<City> _remainingCities;
    private IDistance _distance;
    public GreedyAlgorithm(IDistance distance)
    {
        _distance = distance;
    }
    public Solution PlanRoute(List<City> cities)
    {
        _remainingCities = cities;

        var solution = new Solution(_distance);

        var curCity = _remainingCities.First();
        var startCity = curCity;

        _remainingCities.Remove(curCity);
        solution.Route.Add(curCity);

        while (_remainingCities.Count > 0)
        {
            double minDistance = 99999999999;
            City minCity = null;
            foreach(var city in _remainingCities)
            {
                var distance = _distance.DistanceBetweenCities(curCity, city);
                if (distance < minDistance)
                {
                    minCity = city;
                    minDistance = distance;
                }
            }

            curCity = minCity;
            solution.Route.Add(curCity);
            _remainingCities.Remove(curCity);

        }

        solution.Route.Add(startCity);
        return solution;
    }
}