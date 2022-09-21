namespace Salesman.Models.Algorithms;

public interface IPathAlgorithm
{
    Solution PlanRoute(List<City> cities);
}