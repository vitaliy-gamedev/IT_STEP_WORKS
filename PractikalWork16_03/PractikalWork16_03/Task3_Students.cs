using System;
using System.Linq;

public class Task3_Students
{
    public static void Run()
    {
        Student[] s =
        {
            new("Boris","Brown",20,"MIT"),
            new("Alex","Brooks",22,"Oxford"),
            new("Ivan","Ivanov",18,"KPI"),
            new("Boris","Black",21,"Oxford")
        };

        Console.WriteLine("Всі: " + string.Join(", ", from x in s select x));
        Console.WriteLine("Boris: " + string.Join(", ", from x in s where x.Name == "Boris" select x));
        Console.WriteLine("Bro: " + string.Join(", ", from x in s where x.Surname.StartsWith("Bro") select x));
        Console.WriteLine(">19: " + string.Join(", ", from x in s where x.Age > 19 select x));
        Console.WriteLine("20-23: " + string.Join(", ", from x in s where x.Age > 20 && x.Age < 23 select x));
        Console.WriteLine("MIT: " + string.Join(", ", from x in s where x.University == "MIT" select x));
        Console.WriteLine("Oxford: " + string.Join(", ", from x in s where x.University == "Oxford" && x.Age > 18 orderby x.Age descending select x));
    }
}