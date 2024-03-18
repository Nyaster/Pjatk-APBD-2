using APBD3.Conteiners.Enums;

namespace APBD3.Conteiners;

public class ContainerBase
{
    protected static int Globalindex { get; set; }

    public int Index { get; }
    protected double MaxWeight { get; }
    protected int Height { get; }
    protected int Width { get; }
    protected double OwnWeight { get; }
    protected double LoadedWeight { get; set; }
    protected ContainerType ContainerType { get; }
    private string containerName;

    protected string ContainerName
    {
        get => "KON-" + containerName + "-" + Index;
    }

    public ContainerBase(double maxWeight, int height, int width, ContainerType containerType, double ownWeight,
        string containerName)
    {
        MaxWeight = maxWeight;
        Height = height;
        Width = width;
        ContainerType = containerType;
        OwnWeight = ownWeight;
        this.containerName = containerName;
        Index = ContainerBase.Globalindex++;
    }

    protected double Unload()
    {
        var loadedWeight = LoadedWeight;
        LoadedWeight = 0;
        return loadedWeight;
    }

    protected void LoadWeight(double weight)
    {
        if ((weight + LoadedWeight) > MaxWeight)
        {
            throw new OverFillException();
        }

        LoadedWeight += weight;
    }
}