using Salesman.Models.Distance;
using Salesman.Models.Algorithms;
using Salesman.Models;
using Salesman.Tour.IO;

public class Planner
{
    IPathAlgorithm _algorithm;
    IIOHandler _io;

    public Planner(IPathAlgorithm algorithm, IIOHandler io)
    {
        _algorithm = algorithm;
        _io = io;
    }
    public void Run()
    {
        List<City> cities = _io.ReadCities();

        var solution = _algorithm.PlanRoute(cities);

        _io.WriteSolution(solution);
    }
}