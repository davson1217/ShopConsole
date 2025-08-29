using System.Globalization;
using ShopConsole.Presentation.Delegates;
using ShopConsole.Presentation.Enums;
using ShopConsole.Presentation.Model;
using ShopConsole.Presentation.Interfaces;

namespace ShopConsole.Presentation.Repo;

public class FruitShop : IShop<Fruit>
{
    public List<Fruit> Items { get; } =
    [
        new() { Color = "Red", Name = "Apple", Size = FruitSize.Medium, Price = .99 }, // target-typed
        new() { Color = "Yellow", Name = "Banana", Size = FruitSize.Medium, Price = .95 },
        new Fruit() { Color = "Green", Name = "Pawpaw", Size = FruitSize.Large, Price = 2.85 },
        new Fruit() { Color = "Green", Name = "Watermelon", Size = FruitSize.Large, Price = 1.65 },
        new Fruit() { Color = "Green", Name = "Pineapple", Size = FruitSize.Large, Price = 1.20 },
        new Fruit() { Color = "Black", Name = "Berries", Size = FruitSize.Small, Price = .65 },
        new Fruit() { Color = "Red", Name = "Strawberry", Size = FruitSize.Small, Price = 2.56 },
        new Fruit() { Color = "Green", Name = "Apple", Size = FruitSize.Medium, Price = .99 },
        new Fruit() { Color = "Green", Name = "Tangerine", Size = FruitSize.Small, Price = .69 },
    ];

    private List<Customer> _customers = new List<Customer>();

    public List<Fruit> Open(Sorter<Fruit> sorter) => sorter(Items);

    public double Worth(bool isManager)
    {
        if (!isManager)
        {
            throw new UnauthorizedAccessException("You are not allowed access to such information");
        }

        double worth = Items.Aggregate(.0, (acca, fruit) => acca + fruit.Price);

        Console.WriteLine(
            $" -> You have {worth.ToString("C", CultureInfo.CreateSpecificCulture("da-DK"))} worth of items in your shop"
        );

        return worth;
    }

    public void AllowCustomers(List<Customer> customers)
    {
        List<Customer> temp = [];

        foreach (Customer customer in customers)
        {
            var skip = _customers.Contains(customer) || _customers.Any(cus => cus.Id == customer.Id);

            if (skip) continue;

            temp.Add(customer);
        }

        _customers = temp;
    }

    public int CustomerCount()
    {
        var count = _customers.Count;

        Console.WriteLine("There are {0} customer{1} in the shop", count.ToString(), count > 1 ? "s" : string.Empty);

        return count;
    }

    public Customer Sell(Fruit fruit, Customer customer)
    {
        if (fruit.Price > customer.Wallet) throw new Exception("You do not have enough money to buy this item");

        customer.Wallet -= fruit.Price;

        Console.WriteLine("Thanks for buying!");

        return customer;
    }
}
