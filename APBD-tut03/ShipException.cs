namespace APBD_tut03;

public class ShipException:Exception
{
    public ShipException(string message) : base(message)
    {
        
    }

    public ShipException(string message, Exception innerException) : base(message, innerException)
    {
        
    }
}