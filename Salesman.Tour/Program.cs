// See https://aka.ms/new-console-template for more information
using Salesman.Models;
using Salesman.Models.Algorithms;
using Salesman.Models.Distance;
using Salesman.Tour.IO;

IIOHandler io = new STDIOHandler();
IDistance distance = new EasyDistance();
IPathAlgorithm algorithm= new GreedyAlgorithm(distance);

var planner = new Planner(algorithm, io);
planner.Run();

