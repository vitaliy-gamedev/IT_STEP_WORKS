using System;
using System.Linq;

public class Task1_Numbers
{
    public static void Run()
    {
        int[] a = { 1, 2, 3, 7, 8, 14, 21, 56, 13 };

        Console.WriteLine("Всі: " + string.Join(", ", from n in a select n));
        Console.WriteLine("Парні: " + string.Join(", ", from n in a where n % 2 == 0 select n));
        Console.WriteLine("Непарні: " + string.Join(", ", from n in a where n % 2 != 0 select n));
        Console.WriteLine(">10: " + string.Join(", ", from n in a where n > 10 select n));
        Console.WriteLine("5-20: " + string.Join(", ", from n in a where n >= 5 && n <= 20 select n));
        Console.WriteLine("7: " + string.Join(", ", from n in a where n % 7 == 0 orderby n select n));
        Console.WriteLine("8: " + string.Join(", ", from n in a where n % 8 == 0 orderby n descending select n));
    }
}