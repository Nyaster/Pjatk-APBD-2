namespace APBD3.Conteiners;

public class OverFillException : Exception
{
    public OverFillException(string? message) : base(message)
    {
    }
}