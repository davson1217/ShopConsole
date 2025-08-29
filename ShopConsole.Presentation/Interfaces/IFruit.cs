using ShopConsole.Presentation.Enums;

namespace ShopConsole.Presentation.Interfaces;

public interface IFruit
{
    public string Name { get; set; }

    public string Color { get; set; }

    public FruitSize Size { get; set; }
}