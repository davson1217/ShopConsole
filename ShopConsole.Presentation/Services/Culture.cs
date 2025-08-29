using System.Globalization;

namespace ShopConsole.Presentation.Services;

public class Culture
{
    public static void GetCurrentCulture()
    {
        Console.WriteLine("Culture Code - " + CultureInfo.CurrentCulture);
        Console.WriteLine("Display Name - " + CultureInfo.CurrentCulture.DisplayName);
        Console.WriteLine("Calendar - " + CultureInfo.CurrentCulture.Calendar);
        Console.WriteLine("Culture Name - " + CultureInfo.CurrentCulture.Name);
        Console.WriteLine("Culture EnglishName - " + CultureInfo.CurrentCulture.EnglishName);
        Console.WriteLine("Culture NativeName - " + CultureInfo.CurrentCulture.NativeName);
    }
}
