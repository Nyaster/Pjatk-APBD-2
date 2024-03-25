using APBD3.Conteiners.Enums;
using APBD3.Conteiners.interfaces;
using APBD3.Conteiners.load;

namespace APBD3.Conteiners;

public class ContainerC : ContainerBase
{
    public string FoodType;
    public int OwnTemperature;

    public ContainerC(double maxWeight, int height, int width, double ownWeight, int ownTemperature) : base(maxWeight,
        height, width,
        ownWeight, ContainerType.C)
    {
        OwnTemperature = ownTemperature;
    }

    public void SendNotification(string message)
    {
        Console.WriteLine(message);
    }

    public override ILoad Unload(double howMuch)
    {
        if (howMuch > LoadedWeight)
        {
            return Unload();
        }

        LoadedWeight -= howMuch;
        return new FoodLoad(howMuch, FoodType, OwnTemperature);
    }

    public override ILoad Unload()
    {
        return new FoodLoad(LoadedWeight, FoodType, OwnTemperature);
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

        var foodLoad = weight as FoodLoad;
        if (LoadedWeight == 0)
        {
            FoodType = foodLoad?.FoodType;
        }

        if (!FoodType.ToLower().Equals(foodLoad.FoodType.ToLower()))
        {
            SendNotification("Trying load wrong type of food");
            return;
        }

        this.LoadedWeight += weight.GetLoad();
    }
}