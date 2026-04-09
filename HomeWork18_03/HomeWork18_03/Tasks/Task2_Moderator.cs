using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class Task2_Moderator
{
    public static void Run()
    {
        Console.Write("Текст файл: ");
        var textPath = Console.ReadLine();

        Console.Write("Фільтр файл: ");
        var wordsPath = Console.ReadLine();

        var text = File.ReadAllText(textPath);
        var words = File.ReadAllLines(wordsPath);

        int total = 0;

        foreach (var w in words.Where(x => !string.IsNullOrWhiteSpace(x)))
        {
            var matches = Regex.Matches(text, w);
            total += matches.Count;

            text = Regex.Replace(text, w, new string('*', w.Length));
        }

        File.WriteAllText(textPath, text);

        Console.WriteLine($"Замінено слів: {total}");
    }
}