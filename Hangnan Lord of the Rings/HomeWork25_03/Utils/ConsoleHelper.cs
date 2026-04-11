using Spectre.Console;

namespace Utils
{
    public static class ConsoleHelper
    {
        public static void Clear()
        {
            AnsiConsole.Clear();
        }

        public static void Pause(string message = "Натисніть будь-яку клавішу...")
        {
            AnsiConsole.MarkupLine($"[grey]{message}[/]");
            Console.ReadKey(true);
        }

        public static void ShowTitle(string title)
        {
            AnsiConsole.Write(
                new Rule($"[yellow]{title}[/]")
                .RuleStyle("grey")
                .Centered());
        }

        public static void SlowText(string text, int delay = 20)
        {
            foreach (var ch in text)
            {
                Console.Write(ch);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        public static void Info(string text)
        {
            AnsiConsole.MarkupLine($"[blue]{text}[/]");
        }

        public static void Success(string text)
        {
            AnsiConsole.MarkupLine($"[green]{text}[/]");
        }

        public static void Error(string text)
        {
            AnsiConsole.MarkupLine($"[red]{text}[/]");
        }
    }
}