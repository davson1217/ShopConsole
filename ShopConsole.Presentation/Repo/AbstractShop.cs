using System.Globalization;
using ShopConsole.Presentation.Delegates;
using ShopConsole.Presentation.Interfaces;
using ShopConsole.Presentation.Model;
using TodoCLI.Events;

namespace ShopConsole.Presentation.Repo;

public abstract class AbstractShop<TProduct>(List<TProduct> items)
    : AbstractShopEvents<TProduct>, IShop<TProduct> where TProduct : IProduct
{
    protected List<Customer> Customers = [];
    public List<TProduct> Items { get; } = items;

    public List<TProduct> Open(Sorter<TProduct> sorter)
    {
        return sorter(Items);
    }

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
        List<Customer> temp = Customers;

        foreach (Customer customer in customers)
        {
            var skip = temp.Any(cus => cus.Id == customer.Id);

            if (skip) continue;

            temp.Add(customer);
        }

        Customers = temp;
    }

    public int CustomerCount()
    {
        var count = Customers.Count;

        Console.WriteLine("There are {0} customer{1} in the shop", count.ToString(), count > 1 ? "s" : string.Empty);

        return count;
    }

    public abstract Customer Sell(string itemName, Customer customer);
}
