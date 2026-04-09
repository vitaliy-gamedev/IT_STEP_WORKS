using System;
using System.Linq;

public class Task2_Cities
{
    public static void Run()
    {
        string[] c = { "London", "Amsterdam", "NewYork", "Berlin", "Naples", "Newark" };

        Console.WriteLine("Всі: " + string.Join(", ", from x in c select x));
        Console.WriteLine("Довжина 6: " + string.Join(", ", from x in c where x.Length == 6 select x));
        Console.WriteLine("A: " + string.Join(", ", from x in c where x.StartsWith("A") select x));
        Console.WriteLine("M: " + string.Join(", ", from x in c where x.EndsWith("m") select x));
        Console.WriteLine("N..K: " + string.Join(", ", from x in c where x.StartsWith("N") && x.EndsWith("k") select x));
        Console.WriteLine("Ne: " + string.Join(", ", from x in c where x.StartsWith("Ne") orderby x descending select x));
    }
}