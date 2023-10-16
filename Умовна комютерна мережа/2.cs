using System;
using System.Collections.Generic;

public class Computer
{
    public string IPAddress { get; set; }
    public int Power { get; set; }
    public string OS { get; set; }
}

public class Server : Computer
{
    public int StorageCapacity { get; set; }
}

public class Workstation : Computer
{
    public int RAMSize { get; set; }
}

public class Router : Computer
{
    public int Bandwidth { get; set; }
}

public interface IConnectable
{
    void Connect(Computer device);
    void Disconnect(Computer device);
    void SendData(Computer device, string data);
    string ReceiveData(Computer device);
}

public class Network : IConnectable
{
    private Dictionary<string, Computer> devices = new Dictionary<string, Computer>();

    public void Connect(Computer device)
    {
        devices.Add(device.IPAddress, device);
        Console.WriteLine($"Connected: {device.IPAddress}");
    }

    public void Disconnect(Computer device)
    {
        devices.Remove(device.IPAddress);
        Console.WriteLine($"Disconnected: {device.IPAddress}");
    }

    public void SendData(Computer device, string data)
    {
        if (devices.ContainsKey(device.IPAddress))
        {
            Console.WriteLine($"Sent data to {device.IPAddress}: {data}");
        }
        else
        {
            Console.WriteLine($"Error: {device.IPAddress} not found in the network.");
        }
    }

    public string ReceiveData(Computer device)
    {
        if (devices.ContainsKey(device.IPAddress))
        {
            return $"Received data from {device.IPAddress}";
        }
        else
        {
            return $"Error: {device.IPAddress} not found in the network.";
        }
    }
}

class NetworkSimulation
{
    static void Main()
    {
        Network network = new Network();

        Server server = new Server { IPAddress = "192.168.1.1", Power = 100, OS = "Windows", StorageCapacity = 1000 };
        Workstation workstation = new Workstation { IPAddress = "192.168.1.2", Power = 50, OS = "Linux", RAMSize = 16 };
        Router router = new Router { IPAddress = "192.168.1.3", Power = 80, OS = "RouterOS", Bandwidth = 100 };

        network.Connect(server);
        network.Connect(workstation);
        network.Connect(router);

        network.SendData(workstation, "Hello, server!");
        network.SendData(router, "Routing data...");

        string receivedData = network.ReceiveData(server);
        Console.WriteLine(receivedData);

        network.Disconnect(router);

        receivedData = network.ReceiveData(router);
        Console.WriteLine(receivedData);
    }
}


