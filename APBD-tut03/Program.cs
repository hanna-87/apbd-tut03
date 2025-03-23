
namespace APBD_tut03
{
    class Program
    {
        static void Main(string[] args)
        {
            Container liquidContainer = new LiquidContainer(true, 12, 600, 2000, 21);
            //liquidContainer.LoadCargo(1401) - error
            liquidContainer.LoadCargo(200);
            Container gasContainer = new GasContainer(6, 9, 702, 1600, 30);
            Product product = new Product { ProductType = "Meat", RequiredTemperature = -17 };
            Container refrigeratedContainer = new RefrigeratedContainer(product, -21, 14, 900, 3000, 14);
            Ship ship1 = new Ship(50, 20, 10);
            
            List<Container> containers = new List<Container>();
            containers.Add(new LiquidContainer(false, 13, 600, 2000, 21));
            containers.Add(new GasContainer(4,5,20,10,2));
            
            ship1.LoadContainer(liquidContainer);
            ship1.LoadContainer(gasContainer);
            ship1.LoadContainer(refrigeratedContainer);
            ship1.LoadContainer(containers);
            ship1.PrintShipInfo();
            ship1.UnloadContainer(liquidContainer.SerialNumber);
            ship1.RemoveContainer(liquidContainer.SerialNumber);
            ship1.PrintShipInfo();

            GasContainer largeContainer = new GasContainer(3, 600, 78000, 80000, 500);
            //ship1.LoadContainer(largeContainer); - error
            Container newGasContainer = new GasContainer(11, 9, 700, 1500, 25);
            ship1.ReplaceContainer(gasContainer.SerialNumber, newGasContainer);
            ship1.PrintShipInfo();

           
            Ship ship2 = new Ship(50, 15, 15000);
            ship1.TransferOnAnotherShip(refrigeratedContainer.SerialNumber, ship2);
            
            ship1.PrintShipInfo();
            ship2.PrintShipInfo();
            
            ship1.PrintContainerInfo(newGasContainer.SerialNumber);
            
        }
    }
}