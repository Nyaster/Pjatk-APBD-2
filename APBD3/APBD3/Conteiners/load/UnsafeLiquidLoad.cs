using APBD3.Conteiners.interfaces;

namespace APBD3.Conteiners.load;

public class UnsafeLiquidLoad : ILoad
{
    public double Load;


    public UnsafeLiquidLoad(double load)
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

        if (loadedWeight is not ContainerL)
        {
            throw new Exception("Trying to load invalid type of load");
        }

        if (loadedWeight.LoadedWeight + Load > loadedWeight.MaxWeight * 0.50)
        {
            throw new OverFillException("Trying load more than 50% of container");
        }
    }
    
}