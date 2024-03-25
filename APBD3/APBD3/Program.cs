using APBD3;
using APBD3.Conteiners;
using APBD3.Conteiners.Enums;
using APBD3.Conteiners.load;

class Program
{
    public static void Main(string[] args)
    {
        var lsafe = new ContainerL(1000, 20, 20, 100);
        var lunsafe = new ContainerL(1000, 20, 20, 100);
        var gCont = new ContainerG(1000, 20, 20, 100,12);
        var cCont = new ContainerC(1000, 20, 20, 100,5);
        var foodLoad = new FoodLoad(500, "Cheese", 7.2);
        var foodLoad1 = new FoodLoad(500, "fish", 7.2);
        cCont.LoadWeight(foodLoad);
        Console.WriteLine(cCont.FoodType);
        cCont.LoadWeight(foodLoad1);
        Ship ship = new Ship(10,20);
        var containerOnShip = ship.putContainerOnShip(cCont);
        List<ContainerBase> list = new List<ContainerBase>();
        Console.WriteLine(cCont);
        ship.printAllDataAboutLoad();
        
    }
}