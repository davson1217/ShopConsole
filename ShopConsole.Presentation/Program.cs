// See https://aka.ms/new-console-template for more information

using ShopConsole.Presentation.Model;
using ShopConsole.Presentation.Repo;
using ShopConsole.Presentation.Services;
using TodoCLI.Events;

// Culture.GetCurrentCulture();

var fruitShop = new FruitShop();

var ledger = new Ledger();

fruitShop.OnSale += ledger.OnSaleEvent;
// anotherShop.OnSale += ledger.OnSaleEvent;

try
{
    // Open the shop
    fruitShop.Open(FruitsSorter.SortByPrice);
    fruitShop.Worth(true);

    //---------- Let customers in --------------
    Customer jadon = new Customer() { Id = 1, Name = "Jadon", Wallet = 1.26 };
    Customer lance = new Customer() { Id = 2, Name = "Lance", Wallet = 3.89 };
    Customer jordan = new Customer() { Id = 3, Name = "Jordan", Wallet = 13.89 };

    List<Customer> customers = [jadon, lance, jordan];

    fruitShop.AllowCustomers(customers);
    fruitShop.CustomerCount();

    //--------- Sell to a customer -------------
    Console.WriteLine("wallet before sale {0}", jordan.Wallet);
    fruitShop.Sell("Watermelon", jordan);
    Console.WriteLine("wallet after sale {0}", jordan.Wallet);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}