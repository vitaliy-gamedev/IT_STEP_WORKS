using Utils;
using Models;

public static class GameSaveManager
{
    public static void SaveGame(IFaction faction)
    {
        if (faction == null)
        {
            ConsoleHelper.Error("Немає що зберігати");
            return;
        }

        SaveService.Save(new PlayerSave
        {
            Faction = faction.Name,
            Reputation = faction.Reputation
        });

        ConsoleHelper.Success("Гру збережено!");
    }

    public static void LoadGame()
    {
        var save = SaveService.Load();

        if (save == null)
        {
            ConsoleHelper.Error("Сейв не знайдено");
            return;
        }

        ConsoleHelper.Info($"Фракція: {save.Faction}");
        ConsoleHelper.Info($"Репутація: {save.Reputation}");
    }
}