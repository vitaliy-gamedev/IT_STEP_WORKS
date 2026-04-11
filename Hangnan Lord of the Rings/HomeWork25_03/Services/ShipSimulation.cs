using Spectre.Console;
using Utils;

namespace Services
{
    public static class ShipSimulation
    {
        public static void Run()
        {
            ConsoleHelper.Clear();
            ConsoleHelper.ShowTitle("КОСМІЧНИЙ КОРАБЕЛЬ");

            AnsiConsole.Status()
                .Start("Ініціалізація...", ctx =>
                {
                    Thread.Sleep(2000);
                });

            AnsiConsole.Progress()
                .Start(ctx =>
                {
                    var fuel = ctx.AddTask("Паливо");
                    var oxygen = ctx.AddTask("Кисень");

                    while (!ctx.IsFinished)
                    {
                        fuel.Increment(5);
                        oxygen.Increment(3);
                        Thread.Sleep(200);
                    }
                });

            ConsoleHelper.Success("Системи завантажено");

            ConsoleHelper.Pause();
        }
    }
}