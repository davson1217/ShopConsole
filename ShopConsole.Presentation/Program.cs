// See https://aka.ms/new-console-template for more information

using ShopConsole.Presentation.Model;
using ShopConsole.Presentation.Repo;
using ShopConsole.Presentation.Services;

// Culture.GetCurrentCulture();

FruitShop fruitShop = new FruitShop();

fruitShop.Open(FruitsSorter.SortByPrice);

try
{
    fruitShop.Worth(true);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

