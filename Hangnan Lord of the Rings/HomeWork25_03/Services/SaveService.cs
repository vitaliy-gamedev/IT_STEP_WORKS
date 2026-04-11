using System.Text.Json;
using Models;

public static class SaveService
{
    static string path = "save.json";

    public static void Save(PlayerSave data)
    {
        File.WriteAllText(path, JsonSerializer.Serialize(data));
    }

    public static PlayerSave Load()
    {
        if (!File.Exists(path)) return null;
        return JsonSerializer.Deserialize<PlayerSave>(File.ReadAllText(path));
    }
}