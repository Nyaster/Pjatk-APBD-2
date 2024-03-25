using APBD3.Conteiners.interfaces;

namespace APBD3.Conteiners.load;

public class FoodLoad : ILoad
{
    public double Load;
    public string FoodType;
    public double MinimalTemperature;


    public FoodLoad(double load, string foodType, double minimalTemperature)
    {
        Load = load;
        FoodType = foodType;
        MinimalTemperature = minimalTemperature;
    }

    public double GetLoad()
    {
        return Load;
    }

    public void CheckSafe(ContainerBase loadedWeight)
    {
        if (loadedWeight.LoadedWeight + GetLoad() > loadedWeight.MaxWeight)
        {
            throw new Exception("Trying to overload container");
        }

        if (loadedWeight is not ContainerC)
        {
            throw new Exception("Trying to load invalid type of load");
        }

        var containerC = loadedWeight as ContainerC;

        if (containerC.OwnTemperature > MinimalTemperature)
        {
            throw new Exception("Temperature in container is too high");
        }

        if (string.IsNullOrWhiteSpace(containerC.FoodType))
        {
            containerC.FoodType = FoodType;
        }
    }

    public int GetTemperature()
    {
        throw new NotImplementedException();
    }
}