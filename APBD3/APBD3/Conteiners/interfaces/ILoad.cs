namespace APBD3.Conteiners.interfaces;

public interface ILoad
{
    public double GetLoad();

    void CheckSafe(ContainerBase loadedWeight);
}