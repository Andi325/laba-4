using System;
using System.Collections.Generic;

public class LivingOrganism
{
    public int Energy { get; set; }
    public int Age { get; set; }
    public int Size { get; set; }
}

public class Animal : LivingOrganism, IReproducible, IPredator
{
    public string Species { get; set; }

    public void Reproduce()
    {
        Console.WriteLine("Animal is reproducing.");
    }

    public void Hunt()
    {
        Console.WriteLine("Animal is hunting.");
    }
}

public class Plant : LivingOrganism, IReproducible
{
    public string TypeOfPlant { get; set; }

    public void Reproduce()
    {
        Console.WriteLine("Plant is reproducing.");
    }
}

public class Microorganism : LivingOrganism, IReproducible
{
    public string TypeOfMicroorganism { get; set; }

    public void Reproduce()
    {
        Console.WriteLine("Microorganism is reproducing.");
    }
}

public interface IReproducible
{
    void Reproduce();
}

public interface IPredator
{
    void Hunt();
}

public class Ecosystem
{
    private List<LivingOrganism> organisms = new List<LivingOrganism>();

    public void AddOrganism(LivingOrganism organism)
    {
        organisms.Add(organism);
    }

    public void RemoveOrganism(LivingOrganism organism)
    {
        organisms.Remove(organism);
    }

    public void SimulateInteractions()
    {
        foreach (LivingOrganism organism in organisms)
        {
            if (organism is Animal animal)
            {
                animal.Hunt();
            }
            else if (organism is IReproducible reproducible)
            {
                reproducible.Reproduce();
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Ecosystem ecosystem = new Ecosystem();

        Animal lion = new Animal { Species = "Lion", Energy = 100, Age = 5, Size = 3 };
        Animal gazelle = new Animal { Species = "Gazelle", Energy = 80, Age = 3, Size = 2 };
        Plant tree = new Plant { TypeOfPlant = "Oak", Energy = 50, Age = 10, Size = 10 };

        ecosystem.AddOrganism(lion);
        ecosystem.AddOrganism(gazelle);
        ecosystem.AddOrganism(tree);

        ecosystem.SimulateInteractions();
    }
}
