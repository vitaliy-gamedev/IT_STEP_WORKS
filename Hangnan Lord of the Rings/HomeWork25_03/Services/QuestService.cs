using Spectre.Console;
using Models;

namespace Services
{
    public static class QuestService
    {
        static List<Quest> quests = new()
        {
            new Quest { Name="Артефакт", Description="Знайти relic", Reward=100, Difficulty=3 },
            new Quest { Name="Бос", Description="Перемогти ворога", Reward=300, Difficulty=6 }
        };

        public static void Run()
        {
            var selected = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Квест:")
                    .AddChoices(quests.Select(q => q.Name)));

            var q = quests.First(x => x.Name == selected);

            AnsiConsole.MarkupLine($"[yellow]{q.Description}[/]");
        }
    }
}