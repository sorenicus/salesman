using Salesman.Models.Distance;

namespace Salesman.Models.Algorithms;

public class OptimalAlgorithm : IPathAlgorithm
{
    private List<City> _cities;
    IDistance _distance;

    public OptimalAlgorithm(IDistance distance)
    {
        _distance = distance;
    }
    public Solution PlanRoute(List<City> cities)
    {
        _cities = cities;

        var solution = Recurse(cities[0], new List<City>());

        return solution;
    }

    private Solution Recurse(City currentCity, List<City> visitedCities)
    {
        var newVisitedCities = visitedCities.GetRange(0, visitedCities.Count);
        newVisitedCities.Add(currentCity);

        var unvisitedCities = _cities.Except(newVisitedCities);

        if(unvisitedCities.Count() == 0)
        {
            var solution = new Solution(_distance) { Route = newVisitedCities };
            solution.Route.Add(_cities[0]);
            var distance = _distance.GetRouteDistance(solution.Route);
            return solution;
        }

        double minDistance = 999999999999999;
        Solution minSolution = null;

        foreach (var city in unvisitedCities)
        {
            var solution = this.Recurse(city, newVisitedCities);

            var solutionDistance = _distance.GetRouteDistance(solution.Route);
            if (solutionDistance < minDistance)
            {
                minSolution = solution;
                minDistance = solutionDistance;
            }
        }

        return minSolution;
    }
}