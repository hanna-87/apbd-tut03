namespace APBD_tut03;

public abstract class Container
{
  public double MassOfWholeCargo { get; set; }
  public double MaxPayload { get; set; }
  public double WeightOfContainer { get; set; }
  public double WeightOfCargoItself { get; set; } 
  public double Height { get; set; }
  public double Depth { get; set; }
  public string SerialNumber { get; set; }
  
  public static int Counter { get; private set; } = 1;

  public Container(double height,  double weightOfContainer, double maxPayload, double  depth, string type)
  {
    MaxPayload = maxPayload;
    WeightOfContainer = weightOfContainer;
    Depth = depth;
    Height = height;
    SerialNumber = GenerateSerialNumber(type);
    MassOfWholeCargo = WeightOfContainer;

  }

  public string GenerateSerialNumber(string type)
  {
    return $"KON-{type}-{Counter++}";
  }

  public virtual void EmptyCargo()
  {
    WeightOfCargoItself = 0;
  }

  public virtual void LoadCargo(double mass)
  {
    if (WeightOfCargoItself+mass > MaxPayload)
    {
      throw new OverfillException("The container cannot be overfilled, the maximum payload is exceeded");
    }
    
    WeightOfCargoItself += mass;
    MassOfWholeCargo = WeightOfCargoItself + WeightOfContainer;
  }

  public override string ToString()
  {
    return $"Serial number: {SerialNumber}, Mass of whole cargo: {MassOfWholeCargo}, Max Payload: {MaxPayload},  Weight of container,  {WeightOfContainer},  Weight of cargo {WeightOfCargoItself}, Height {Height},  Depth {Depth}";
  }
  

}