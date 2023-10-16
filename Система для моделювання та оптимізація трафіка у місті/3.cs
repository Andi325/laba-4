using System;
using System.Collections.Generic;

public class Road
{
    public double Length { get; set; }
    public double Width { get; set; }
    public int NumberOfLanes { get; set; }
    public int TrafficLevel { get; set; }
}

public class Vehicle : IDriveable
{
    public string Type { get; set; }
    public double Speed { get; set; }
    public double Size { get; set; }

    public void Move()
    {
        Console.WriteLine($"The {Type} is moving at a speed of {Speed} km/h.");
    }

    public void Stop()
    {
        Console.WriteLine($"The {Type} has stopped.");
    }
}

public interface IDriveable
{
    void Move();
    void Stop();
}

public class TrafficSimulation
{
    public static void SimulateTraffic(Road road, List<Vehicle> vehicles)
    {
        Console.WriteLine($"Simulating traffic on a {road.Length} km road with {road.NumberOfLanes} lanes...");

        foreach (var vehicle in vehicles)
        {
            vehicle.Move();
        }

        Console.WriteLine($"Traffic level: {road.TrafficLevel}");
    }
}

class Program
{
    static void Main()
    {
        Road road = new Road
        {
            Length = 10,
            Width = 3.5,
            NumberOfLanes = 2,
            TrafficLevel = 3
        };

        List<Vehicle> vehicles = new List<Vehicle>
        {
            new Vehicle { Type = "Car", Speed = 60, Size = 4 },
            new Vehicle { Type = "Truck", Speed = 50, Size = 8 },
            new Vehicle { Type = "Bus", Speed = 55, Size = 12 }
        };

        TrafficSimulation.SimulateTraffic(road, vehicles);
    }
}