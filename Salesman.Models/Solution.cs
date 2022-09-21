
using System;
using System.Text;
using Salesman.Models.Distance;

namespace Salesman.Models;
public class Solution
{
    public List<City> Route { get; set; } = new List<City>();

    IDistance _distance;

    public Solution(IDistance distance)
    {
        _distance = distance;
    }


    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var city in Route.GetRange(0, Route.Count() - 1))
        {
            sb.AppendLine(city.Name);
        }

        sb.AppendLine($"{_distance.GetRouteDistance(this.Route)} km");

        return sb.ToString();
    }
}