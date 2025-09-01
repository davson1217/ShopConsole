using ShopConsole.Presentation.Delegates;
using ShopConsole.Presentation.Interfaces;
using ShopConsole.Presentation.Model;

namespace TodoCLI.Events;

public class AbstractShopEvents<T>
{
    public event Sale<IProduct> OnSale;

    protected void RaiseSaleEvent(Customer c, IProduct i)
    {
        OnSale.Invoke(c, i);
    }
}