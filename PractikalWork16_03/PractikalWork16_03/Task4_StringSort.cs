using System;
using System.Linq;

public class Task4_Strings
{
    public static void Run()
    {
        string[] s = { "cat", "elephant", "dog", "tiger" };

        Console.WriteLine("ASC: " + string.Join(", ", from x in s orderby x.Length select x));
        Console.WriteLine("DESC: " + string.Join(", ", from x in s orderby x.Length descending select x));
    }
}