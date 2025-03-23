namespace APBD_tut03;

public class Ship
{
    public List<Container> Containers { get; set; }
    public double MaxSpeed  { get; set; }
    public int MaxNumberOfContainers { get; set; }
    public double MaxPayload { get; set; }
    
    public int ID { get; set; }

    public static int Counter { get; set; } = 1;

    public Ship(double maxSpeed, int maxNumberOfContainers, double maxPayload)
    {
      MaxSpeed = maxSpeed;
      MaxNumberOfContainers = maxNumberOfContainers;
      MaxPayload = maxPayload;
      Containers = new List<Container>();
      ID = Counter++;
    }

    public void LoadContainer(Container container)
    {
        double totalWeight = 0;
        foreach (Container c in Containers)
        {
            totalWeight += c.MassOfWholeCargo;
        }

        if (container.MassOfWholeCargo/1000 + totalWeight/1000 > MaxPayload)
        {
            throw new ShipException("The container is too large to load the ship.");
        }
        Containers.Add(container);
    }
    public void LoadContainer(List<Container> containers)
    {
        double totalWeight = 0;
        foreach (Container c in Containers)
        {
            totalWeight += c.MassOfWholeCargo;
        }

        foreach (Container c in containers)
        {
            if (c.MassOfWholeCargo/1000 + totalWeight/1000 > MaxPayload)
            {
                throw new ShipException("The container is too large to load the ship.");
            } 
            Containers.Add(c);
        }
        
    }

    public void RemoveContainer(String serialNumber)
    {
        
        var containerToRemove = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
    
        if (containerToRemove != null)
        {
            Containers.Remove(containerToRemove);
            Console.WriteLine($"Container {serialNumber} was removed from the ship.");
        }
        else
        {
            Console.WriteLine($"Container with serial number {serialNumber} not found.");
        }
    }

    public void RemoveContainer(Container container)
    {
        Containers.Remove(container);
    }

    public void UnloadContainer(String serialNumber)
    {
        foreach (var c in Containers)
        {
            if (c.SerialNumber == serialNumber)
            {
               c.EmptyCargo();
            }
        }
    }
    
    public void ReplaceContainer(String serialNumber, Container newContainer){
        var containerToReplace = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
    
        if (containerToReplace != null)
        {
            Containers.Remove(containerToReplace);
            Containers.Add(newContainer);
        }
        else
        {
            Console.WriteLine($"Container with serial number {serialNumber} not found.");
        }
    }

    public void TransferOnAnotherShip(String serialNumber, Ship ship)
    {
        var containerToTransfer = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
    
        if (containerToTransfer != null)
        {
            Containers.Remove(containerToTransfer);
            ship.LoadContainer(containerToTransfer);
        }
        else
        {
            Console.WriteLine($"Container with serial number {serialNumber} not found.");
        }
    }

    public void PrintContainerInfo(String serialNumber)
    {
        Console.WriteLine($"Container {serialNumber} Info:");
        foreach (var c in Containers)
        {
            if (c.SerialNumber == serialNumber)
            {
                Console.WriteLine(c.ToString());
            }
        }
        Console.WriteLine();
    }

    public void PrintShipInfo()
    {
        
      Console.WriteLine($"Ship{ID} Information:");  
     Console.WriteLine(ToString());
     foreach (var c in Containers)
      {
       PrintContainerInfo(c.SerialNumber);
      }
      Console.WriteLine();  
    }

    public override string ToString()
    {
      return $"Ship number: {ID},  Max Speed: {MaxSpeed},  Max Number of Containers: {MaxNumberOfContainers},  Max Payload: {MaxPayload} ";
    }
}