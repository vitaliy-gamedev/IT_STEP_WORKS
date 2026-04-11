using Spectre.Console;
using Utils;

public static class LoreQuest
{
    public static void Run(IFaction faction)
    {
        if (faction == null)
        {
            ConsoleHelper.Error("Спочатку обери сторону!");
            return;
        }

        ConsoleHelper.ShowTitle("КВЕСТ");

        faction.ShowLore();

        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Що зробиш?")
                .AddChoices("Допомогти", "Захопити силою"));

        if (choice == "Допомогти")
        {
            faction.ChangeReputation(+10);
            ConsoleHelper.Success("Ти допоміг людям");
        }
        else
        {
            faction.ChangeReputation(-10);
            ConsoleHelper.Error("Ти обрав темний шлях");
        }

        ConsoleHelper.Pause();
    }
}