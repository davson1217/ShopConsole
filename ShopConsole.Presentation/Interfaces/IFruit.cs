using ShopConsole.Presentation.Enums;

namespace ShopConsole.Presentation.Interfaces;

public interface IProduct
{
    public string Name { get; set; }
    public double Price { get; set; }
    // public string Color { get; set; }
    // public FruitSize Size { get; set; }
}