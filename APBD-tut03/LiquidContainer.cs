
namespace APBD_tut03;

public class LiquidContainer: Container,IHazardNotifier 
{
    public bool IsHazardous { get; private set; }

    public LiquidContainer(bool isHazardous, double height, double weightOfContainer, double maxPayload, double depth) : base(height, weightOfContainer, maxPayload, depth, "Liquid")
    {
        IsHazardous = isHazardous;
    }

    public void Notify(string serialNumber)
    {
        Console.WriteLine($"Hazardous accident occured in container: {serialNumber}");
    }

    public override void LoadCargo(double mass)
    {
        double mxPayload = IsHazardous ? MaxPayload * 0.5 : MaxPayload * 0.9;
        if (WeightOfCargoItself + mass > mxPayload )
            throw new OverfillException($"Cannot load {mass}kg. Max payload for hazardous cargo is {mxPayload}kg.");
        WeightOfCargoItself += mass;
    }
    
    public override string ToString()
    {
        return base.ToString() + $", Hazardous: {IsHazardous}";
    }
}