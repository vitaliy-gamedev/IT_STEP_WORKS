using Spectre.Console;

public class DarkSide : IFaction
{
    public string Name => "Темна сторона";
    public int Reputation { get; private set; }

    public void ShowLore()
    {
        AnsiConsole.MarkupLine("[red]Темрява дає силу...[/]");
    }

    public void ChangeReputation(int value)
    {
        Reputation += value;
        AnsiConsole.MarkupLine($"[red]Репутація: {Reputation}[/]");
    }
}