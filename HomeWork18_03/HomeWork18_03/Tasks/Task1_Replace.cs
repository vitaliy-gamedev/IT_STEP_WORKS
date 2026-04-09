using System;
using System.IO;
using System.Text.RegularExpressions;

public class Task1_Replace
{
    public static void Run()
    {
        Console.Write("Файл: ");
        var path = Console.ReadLine();

        Console.Write("Знайти: ");
        var find = Console.ReadLine();

        Console.Write("Замінити: ");
        var replace = Console.ReadLine();

        var text = File.ReadAllText(path);

        var matches = Regex.Matches(text, find);
        text = Regex.Replace(text, find, replace);

        File.WriteAllText(path, text);

        Console.WriteLine($"Було знайдено: {matches.Count}");
    }
}