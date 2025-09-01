using ShopConsole.Presentation.Delegates;
using ShopConsole.Presentation.Model;

namespace ShopConsole.Presentation.Interfaces;

public interface IShop<TItem> where TItem : IProduct
{
    List<TItem> Items { get; }

    List<TItem> Open(Sorter<TItem> sorter);

    public double Worth(bool isManager);

    public void AllowCustomers(List<Customer> customers);

    public int CustomerCount();

    public Customer Sell(string itemName, Customer customer);
}