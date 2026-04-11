using Spectre.Console;

public class LightSide : IFaction
{
    public string Name => "Світла сторона";
    public int Reputation { get; private set; }

    public void ShowLore()
    {
        AnsiConsole.MarkupLine("[green]Світло несе баланс у галактику...[/]");
    }

    public void ChangeReputation(int value)
    {
        Reputation += value;
        AnsiConsole.MarkupLine($"[green]Репутація: {Reputation}[/]");
    }
}