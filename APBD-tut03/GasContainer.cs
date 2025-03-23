namespace APBD_tut03;

public class GasContainer: Container, IHazardNotifier
{
    public double Pressure { get; private set; }

    public GasContainer(double pressure, double height, double weightOfContainer, double maxPayload, double depth) :
        base(height, weightOfContainer, maxPayload, depth, "Gas")
    {
        Pressure = pressure;
    }
    
    public void Notify(string serialNumber)
    {
        Console.WriteLine($"Hazardous accident occured in container: {serialNumber}");
    }
    
    public override void EmptyCargo()
    {
        WeightOfCargoItself *= 0.05; 
    }

    public override string ToString()
    {
        return base.ToString() + $", Pressure: {Pressure}";
    }
}