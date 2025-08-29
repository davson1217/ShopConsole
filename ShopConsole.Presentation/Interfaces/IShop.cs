using ShopConsole.Presentation.Delegates;
using ShopConsole.Presentation.Model;

namespace ShopConsole.Presentation.Interfaces;

public interface IShop<T> where T : class
{
    List<T> Items { get; }

    List<T> Open(Sorter<T> sorter);
    
    public double Worth(bool isManager);

    public void AllowCustomers(List<Customer> customers);

    public int CustomerCount();

    public Customer Sell(T item, Customer customer);
}
