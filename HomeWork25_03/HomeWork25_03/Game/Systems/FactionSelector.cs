using Spectre.Console;

public static class FactionSelector
{
    public static IFaction Choose()
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Обери сторону:")
                .AddChoices("Світла сторона", "Темна сторона"));

        return choice == "Світла сторона"
            ? new LightSide()
            : new DarkSide();
    }
}