using APBD3.Conteiners.Enums;
using APBD3.Conteiners.interfaces;
using APBD3.Conteiners.load;

namespace APBD3.Conteiners;

public class ContainerG : ContainerBase, IHazardNotifier
{
    public double Pressure { get; }

    public ContainerG(double maxWeight, int height, int width, double ownWeight,
        double pressure) : base(maxWeight, height, width, ownWeight, ContainerType.G)
    {
        Pressure = pressure;
    }

    public override ILoad Unload(double howMuch)
    {
        if (howMuch > LoadedWeight)
        {
            return Unload();
        }

        LoadedWeight -= howMuch;
        return new GasLoad(howMuch * 0.95);
    }

    public override ILoad Unload()
    {
        return new GasLoad(LoadedWeight * 0.95);
    }

    public override void LoadWeight(ILoad weight)
    {
        try
        {
            weight.CheckSafe(this);
        }
        catch (Exception e)
        {
            SendNotification(e.Message);
            return;
        }
        this.LoadedWeight += weight.GetLoad();
    }

    public void SendNotification(string message)
    {
        Console.WriteLine(message);
    }
}