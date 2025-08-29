namespace ShopConsole.Presentation.Interfaces;

public interface ICustomer
{
    public int Id { get; set; }

    public string Name { get; set; }

    public double Wallet { get; set; }

    public void Buy();
}