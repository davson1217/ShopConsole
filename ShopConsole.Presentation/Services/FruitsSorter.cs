using ShopConsole.Presentation.Model;
using ShopConsole.Presentation.Interfaces;

namespace ShopConsole.Presentation.Services;

public class FruitsSorter
{
    public static List<Fruit> SortByColor(List<Fruit> fruits)
    {
        return fruits;
    }

    public static List<Fruit> SortBySize(List<Fruit> fruits)
    {
        var f = fruits.OrderByDescending(fruit => fruit.Size);
        Console.WriteLine("=== Sorting By Size ===");
        foreach (var fruit in f)
        {
            Console.WriteLine($"{fruit.Name} | {fruit.Size} | {fruit.Price}");
        }

        return fruits;
    }

    public static List<Fruit> SortByName(List<Fruit> fruits)
    {
        var f = fruits.OrderByDescending(fruit => fruit.Name).ToList();

        foreach (var fruit in f)
        {
            Console.WriteLine($"{fruit.Name}");
        }

        return f;
    }

    public static List<Fruit> SortByPrice(List<Fruit> fruits)
    {
        Console.WriteLine("== sorting by price == \n ====================");

        var f = fruits.OrderBy(fruit => fruit.Price).ToList();

        Console.WriteLine("{0, -31}{1, -47}{2, -25}", "FRUIT", "Size", "Price");

        foreach (var fruit in f)
        {
            Console.WriteLine("{0, -31}{1, -47}{2, -25}", fruit.Name, fruit.Size, fruit.Price);
        }

        Console.WriteLine("====================");

        return f;
    }
}