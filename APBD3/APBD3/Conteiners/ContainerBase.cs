using APBD3.Conteiners.Enums;
using APBD3.Conteiners.interfaces;

namespace APBD3.Conteiners;

public abstract class ContainerBase
{
    protected static int Globalindex { get; set; }

    public int Index { get; protected set; }
    public double MaxWeight { get; protected set; }
    public int Height { get; protected set; }
    public int Width { get; protected set; }
    public double OwnWeight { get; protected set; }
    public double LoadedWeight { get; protected set; }

    public double TotalWeight
    {
        get { return OwnWeight + LoadedWeight; }
    }

    protected ContainerType ContainerType { get; }

    public string ContainerName
    {
        get => "KON-" + ContainerType + "-" + Index;
    }

    protected ContainerBase(double maxWeight, int height, int width, double ownWeight, ContainerType containerType)
    {
        MaxWeight = maxWeight;
        Height = height;
        Width = width;
        ContainerType = containerType;
        OwnWeight = ownWeight;
        Index = ContainerBase.Globalindex++;
    }

    public abstract ILoad Unload(double howMuch);
    public abstract ILoad Unload();

    public override string ToString()
    {
        return $"Container Name: {ContainerName}\n" +
               $"Index: {Index}\n" +
               $"Max Weight: {MaxWeight}\n" +
               $"Height: {Height}\n" +
               $"Width: {Width}\n" +
               $"Own Weight: {OwnWeight}\n" +
               $"Loaded Weight: {LoadedWeight}\n" +
               $"Total Weight: {TotalWeight}\n" +
               $"Container Type: {ContainerType}";
    }

    public abstract void LoadWeight(ILoad weight);
}