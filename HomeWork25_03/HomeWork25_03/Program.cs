using System;
using System.Threading;
using Spectre.Console;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.Clear();
            AnsiConsole.Write(
                new FigletText("STAR GAME")
                    .Centered()
                    .Color(Color.Yellow));

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green]Вибери дію:[/]")
                    .PageSize(10)
                    .AddChoices(new[] {
                        "[blue]Інтро Star Wars[/]",
                        "[magenta]Конструктор персонажа[/]",
                        "[cyan]Симуляція корабля[/]",
                        "[red]Вихід[/]"
                    }));

            switch (choice)
            {
                case "[blue]Інтро Star Wars[/]":
                    StarWarsIntro.Play();
                    break;

                case "[magenta]Конструктор персонажа[/]":
                    CharacterBuilder.Run();
                    break;

                case "[cyan]Симуляція корабля[/]":
                    ShipSimulation.Run();
                    break;

                case "[red]Вихід[/]":
                    MusicService.Stop();
                    return;
            }
        }
    }
}

static class CharacterBuilder
{
    public static void Run()
    {
        Console.Clear();
        AnsiConsole.MarkupLine("[yellow]=== КОНСТРУКТОР ПЕРСОНАЖА ===[/]");

        AnsiConsole.Markup("Введи [green]ім'я[/] персонажа: ");
        var name = Console.ReadLine();

        var type = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Оберіть [blue]тип персонажа[/]:")
                .AddChoices("Воїн", "Маг", "Лучник"));

        var skills = AnsiConsole.Prompt(
            new MultiSelectionPrompt<string>()
                .Title("Обери навички:")
                .NotRequired()
                .AddChoices("Сила", "Магія", "Стрільба", "Швидкість", "Схованка"));

        var table = new Table();
        table.AddColumn("Ім'я");
        table.AddColumn("Тип");
        table.AddColumn("Навички");
        table.AddRow(name, type, string.Join(", ", skills));

        AnsiConsole.Write(new Panel(table)
            .Header("[green]Картка героя[/]")
            .BorderColor(Color.Aqua));

        AnsiConsole.MarkupLine("\n[grey]Натисни будь-яку клавішу...[/]");
        Console.ReadKey(true);
    }
}

static class ShipSimulation
{
    public static void Run()
    {
        Console.Clear();
        AnsiConsole.MarkupLine("[yellow]=== ЗАВАНТАЖЕННЯ КОРАБЛЯ ===[/]");

        AnsiConsole.Progress()
            .Columns(new ProgressColumn[]
            {
                new TaskDescriptionColumn(),
                new ProgressBarColumn(),
                new PercentageColumn()
            })
            .Start(ctx =>
            {
                var fuel = ctx.AddTask("[green]Паливо[/]");
                var oxygen = ctx.AddTask("[blue]Кисень[/]");

                while (!ctx.IsFinished)
                {
                    fuel.Increment(2);
                    oxygen.Increment(1);
                    Thread.Sleep(100);
                }
            });

        AnsiConsole.Write(
            new Panel("[green]Системи в нормі![/]")
                .BorderColor(Color.Yellow)

            );
                

        AnsiConsole.MarkupLine("\n[grey]Натисни будь-яку клавішу...[/]");
        Console.ReadKey(true);
    }
}