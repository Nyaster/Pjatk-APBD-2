using APBD3.Conteiners.interfaces;

namespace APBD3.Conteiners.load;

public class GasLoad : ILoad
{
    public double Load;


    public GasLoad(double load)
    {
        Load = load;
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
        if (loadedWeight is not ContainerG)
        {
            throw new Exception("Trying to load invalid type of load");
        }

        if (loadedWeight.LoadedWeight + Load > loadedWeight.MaxWeight * 0.95)
        {
            throw new OverFillException("Trying load more than 50% of container");
        }
    }
    

    public int GetTemperature()
    {
        throw new NotImplementedException();
    }
}