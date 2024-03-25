using APBD3.Conteiners.Enums;
using APBD3.Conteiners.interfaces;
using APBD3.Conteiners.load;

namespace APBD3.Conteiners;

public class ContainerL : ContainerBase, IHazardNotifier

{
    private LiquidType _liquidType = LiquidType.Safe;

    public ContainerL(double maxWeight, int height, int width, double ownWeight) : base(maxWeight, height, width,
        ownWeight, Enums.ContainerType.L)
    {
    }

    public void SendNotification(string eMessage)
    {
        Console.WriteLine(eMessage);
    }

    public override ILoad Unload(double howMuch)
    {
        if (howMuch > LoadedWeight)
        {
            Unload();
        }

        switch (_liquidType)
        {
            case LiquidType.Safe:
                var safeLiquidLoad = new SafeLiquidLoad(howMuch);
                LoadedWeight -= howMuch;
                return safeLiquidLoad;
                break;
            case LiquidType.Notsafe:
                var unsafeLiquidLoad = new UnsafeLiquidLoad(howMuch);
                LoadedWeight -= howMuch;
                return unsafeLiquidLoad;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public override ILoad Unload()
    {
        switch (_liquidType)
        {
            case LiquidType.Safe:
                var safeLiquidLoad = new SafeLiquidLoad(LoadedWeight);
                LoadedWeight = 0;
                return safeLiquidLoad;
                break;
            case LiquidType.Notsafe:
                var unsafeLiquidLoad = new UnsafeLiquidLoad(LoadedWeight);
                LoadedWeight = 0;
                return unsafeLiquidLoad;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public override void LoadWeight(ILoad weight)
    {
        try
        {
            weight.CheckSafe(this);
            if (_liquidType != LiquidType.Notsafe)
            {
                _liquidType = weight is SafeLiquidLoad ? LiquidType.Safe : LiquidType.Notsafe;
            }
        }
        catch (Exception e)
        {
            SendNotification(e.Message);
            return;
        }

        this.LoadedWeight += weight.GetLoad();
    }

    public void SendNotification()
    {
        throw new NotImplementedException();
    }
}