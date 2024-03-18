namespace APBD3.Conteiners;

public class OverFillException : Exception
{
    public override string Message { get=>"Your trying to overload container"; }
}