using ShopConsole.Presentation.Enums;
using ShopConsole.Presentation.Interfaces;

namespace ShopConsole.Presentation.Model;

public class Fruit : IFruit
{
    public required string Color { get; set; }
    public required FruitSize Size { get; set; }
    public required string Name { get; set; }
    public required double Price { get; set; }
}
