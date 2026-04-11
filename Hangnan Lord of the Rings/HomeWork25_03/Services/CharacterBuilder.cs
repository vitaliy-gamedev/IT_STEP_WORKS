using Spectre.Console;
using Models;
using Utils;

namespace Services
{
    public static class CharacterBuilder
    {
        public static void Run()
        {
            ConsoleHelper.Clear();
            ConsoleHelper.ShowTitle("КОНСТРУКТОР ПЕРСОНАЖА");

            var character = new Character();

            character.Name = AnsiConsole.Prompt(
                new TextPrompt<string>("Ім’я персонажа:"));

            character.Type = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Тип:")
                    .AddChoices("Воїн", "Маг", "Лучник"));

            character.Skills = AnsiConsole.Prompt(
                new MultiSelectionPrompt<string>()
                    .Title("Навички:")
                    .AddChoices("Сила", "Магія", "Стрільба", "Стелс"));

            var table = new Table();
            table.AddColumn("Поле");
            table.AddColumn("Значення");

            table.AddRow("Ім’я", character.Name);
            table.AddRow("Тип", character.Type);
            table.AddRow("Навички", string.Join(", ", character.Skills));

            AnsiConsole.Write(
                new Panel(table)
                    .Header("Герой")
                    .BorderColor(Color.Green));

            ConsoleHelper.Pause();
        }
    }
}