using System.Globalization;
using ShopConsole.Presentation.Delegates;
using ShopConsole.Presentation.Enums;
using ShopConsole.Presentation.Model;
using ShopConsole.Presentation.Interfaces;
using TodoCLI.Events;

namespace ShopConsole.Presentation.Repo;

public class FruitShop : AbstractShop<Fruit>
{
    public FruitShop() : base([
        new Fruit() { Color = "Red", Name = "Apple", Size = FruitSize.Medium, Price = .99 }, // target-typed
        new Fruit() { Color = "Yellow", Name = "Banana", Size = FruitSize.Medium, Price = .95 },
        new Fruit() { Color = "Green", Name = "Pawpaw", Size = FruitSize.Large, Price = 2.85 },
        new Fruit() { Color = "Green", Name = "Watermelon", Size = FruitSize.Large, Price = 1.65 },
        new Fruit() { Color = "Green", Name = "Pineapple", Size = FruitSize.Large, Price = 1.20 },
        new Fruit() { Color = "Black", Name = "Berries", Size = FruitSize.Small, Price = .65 },
        new Fruit() { Color = "Red", Name = "Strawberry", Size = FruitSize.Small, Price = 2.56 },
        new Fruit() { Color = "Green", Name = "Apple", Size = FruitSize.Medium, Price = .99 },
        new Fruit() { Color = "Green", Name = "Tangerine", Size = FruitSize.Small, Price = .69 }
    ])
    {
    }

    public override Customer Sell(string fruitName, Customer customer)
    {
        var fruit = GetFruit(fruitName);

        if (!Customers.Contains(customer)) throw new Exception($"Can't sell: {customer.Name} is not in the shop");

        if (fruit.Price > customer.Wallet) throw new Exception("You do not have enough money to buy this item");

        customer.Wallet -= fruit.Price;

        Console.WriteLine("Thanks for buying!");
        
        RaiseSaleEvent(customer, fruit);
        
        return customer;
    }

    private Fruit GetFruit(string fruitName)
    {
        Fruit fruitToBuy = new() { Name = "", Color = "", Price = .0, Size = FruitSize.Small };

        var fruits = Items.FindAll(fruit =>
            string.Equals(fruit.Name, fruitName, StringComparison.CurrentCultureIgnoreCase));

        switch (fruits.Count)
        {
            case 0:
                throw new Exception($"We don't have {fruitName} in stock");
            case 1:
                fruitToBuy = fruits.First();
                break;
            case > 1:
            {
                Console.WriteLine($"We have multiple variations of {fruitName}");
                Console.WriteLine("{0, -31}{1, -47}{2, -25}", "FRUIT", "COLOR", "PRICE");
                foreach (var fruit in fruits)
                {
                    Console.WriteLine("{0, -31}{1, -47}{2, -25}", fruit.Name, fruit.Color, fruit.Price);
                }

                Console.WriteLine($"What color of {fruitName} do you want?");

                var color = Console.ReadLine()?.ToLower();

                var f = Items.Find(fruit =>
                    string.Equals(fruit.Name, fruitName, StringComparison.CurrentCultureIgnoreCase) &&
                    string.Equals(fruit.Color, color, StringComparison.CurrentCultureIgnoreCase));

                fruitToBuy = f ?? throw new Exception("Can't continue");
                break;
            }
        }

        return fruitToBuy;
    }
}