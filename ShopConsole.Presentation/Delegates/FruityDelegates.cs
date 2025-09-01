using ShopConsole.Presentation.Model;

namespace ShopConsole.Presentation.Delegates;

public delegate List<T> Sorter<T>(List<T> param);

public delegate void Sale<in T>(Customer customer, T item);