namespace APBD_tut03;

public class RefrigeratedContainer: Container
{
  public Product Product { get; set; }
  public double Temperature { get; set; }

  public RefrigeratedContainer(Product product, double temperature, double height, double weightOfContainer,
    double maxPayload, double depth) : base(height, weightOfContainer, maxPayload, depth, "Refrigerated")
  {
    Temperature = temperature;
    if (Temperature > product.RequiredTemperature)
    {
      throw new ProductException("The temperature is too high for this product.");
    }
    Product = product;
  }
  public override string ToString()
  {
    return base.ToString() + $", Product: {Product.ProductType}, Temp: {Temperature}°C";
  }
}