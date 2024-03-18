using APBD3.Conteiners;
using APBD3.Conteiners.Enums;

class Program
{
    public static void Main(string[] args)
    {
        var containerBase = new ContainerBase(10,1,2,ContainerType.C,100,"Hello");
        var containerBase1 = new ContainerBase(10,1,2,ContainerType.C,100,"Hello");
        var containerBase2 = new ContainerBase(10,1,2,ContainerType.C,100,"Hello");
        Console.WriteLine(containerBase.Index);
        Console.WriteLine(containerBase1.Index);
        Console.WriteLine(containerBase2.Index);
    }
}