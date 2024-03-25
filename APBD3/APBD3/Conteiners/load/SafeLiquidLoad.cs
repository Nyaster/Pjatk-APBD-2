using APBD3.Conteiners.interfaces;

namespace APBD3.Conteiners.load;

public class SafeLiquidLoad : ILoad
{
    public double Load;

    public SafeLiquidLoad(double load)
    {
        Load = load;
    }

    public double GetLoad()
    {
        return Load;
    }

    public void CheckSafe(ContainerBase loadedWeight)
    {
        var containerL = loadedWeight as ContainerL;
        if (loadedWeight is not ContainerL)
        {
            throw new Exception("Trying to load invalid type of load");
        }

        if (loadedWeight.LoadedWeight + GetLoad() > loadedWeight.MaxWeight)
        {
            throw new Exception("Trying to overload container");
        }

        if (loadedWeight.LoadedWeight + Load > loadedWeight.MaxWeight * 0.95)
        {
            throw new OverFillException("Trying load more than 95% of container");
        }
    }
    
}