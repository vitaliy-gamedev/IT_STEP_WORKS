using System;
using System.Linq;

public class Task5_Cars
{
    public static void Run()
    {
        Car[] a =
        {
            new("X5","BMW",2020),
            new("A6","Audi",2019),
            new("Model S","Tesla",2022)
        };

        Car[] b =
        {
            new("X3","BMW",2021),
            new("C","Mercedes",2020),
            new("Model 3","Tesla",2023)
        };

        Console.WriteLine("Різниця: " + string.Join(", ",
            from x in a
            where !(from y in b select y.Brand).Contains(x.Brand)
            select x.Brand));

        Console.WriteLine("Перетин: " + string.Join(", ",
            from x in a
            where (from y in b select y.Brand).Contains(x.Brand)
            select x.Brand));

        Console.WriteLine("Об’єднання: " + string.Join(", ",
            from x in a.Concat(b)
            select x.Brand));
    }
}