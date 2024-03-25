
using APBD3.Conteiners;

namespace APBD3;

public class Ship
{
    private int maxContainers;
    private int maxWeight;
    public int Speed;
    public List<ContainerBase?> ContainerPlaces { get; set; }

    public Ship(int maxWeight, int maxContainers)
    {
        this.maxWeight = maxWeight;
        this.maxContainers = maxContainers;
        ContainerPlaces = new List<ContainerBase>();
    }

    public bool putContainerOnShip(ContainerBase containerBase)
    {
        if (CalculateWeight() + containerBase.LoadedWeight > maxWeight * 1000)
        {
            Console.WriteLine("Not enought weigth for containers");
            return false;
        }

        if (ContainerPlaces.Count + 1 > maxContainers)
        {
            Console.WriteLine("Not enougth place for containers");
            return false;
        }

        ContainerPlaces.Add(containerBase);
        return true;
    }

    public bool putContainerOnShip(List<ContainerBase> containerBase)
    {
        for (var i = 0; i < containerBase.Count; i++)
        {
            if (putContainerOnShip(containerBase[i]))
            {
                Console.WriteLine("Not enought weight or place for containers");
                Console.WriteLine("Only " + i + " containers");
                return false;
            }
        }


        return true;
    }

    private double CalculateWeight()
    {
        double sum = 0;
        var d = ContainerPlaces.Sum(x => x.TotalWeight);
        return d;
    }

    public List<ContainerBase> Unload()
    {
        List<ContainerBase> containerPlaces = ContainerPlaces;
        ContainerPlaces = new List<ContainerBase>();
        return containerPlaces;
    }

    public void PrintAllDataAboutLoad()
    {
        Console.WriteLine("===========Ship Load============");
        for (var i = 0; i < ContainerPlaces.Count; i++)
        {
            Console.WriteLine(ContainerPlaces[i] + " \n Container number is: " + i);
        }
    }

    public ContainerBase? Unload(int i)
    {
        if (ContainerPlaces.Count < i)
        {
            Console.WriteLine("Error");
            return null;
        }

        var containerPlace = ContainerPlaces[i];
        ContainerPlaces.Remove(containerPlace);
        return containerPlace;
    }

    public bool ReplaceContainer(int i, ContainerBase containerBase)
    {
        if (ContainerPlaces.Count < i)
        {
            Console.WriteLine("Error");
            return false;
        }

        ContainerPlaces[i] = containerBase;
        return true;
    }
}