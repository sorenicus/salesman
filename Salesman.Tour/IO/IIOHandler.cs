using Salesman.Models;

namespace Salesman.Tour.IO;
public interface IIOHandler
{
    List<City> ReadCities();
    void WriteSolution(Solution solution);
}