using ShopConsole.Presentation.Interfaces;
using ShopConsole.Presentation.Model;

namespace TodoCLI.Events;

// subscriber class
public class Ledger
{
    public void OnSaleEvent(Customer c, IProduct p)
    {
        Console.WriteLine("Sale will be registered in ledger");
    }
}