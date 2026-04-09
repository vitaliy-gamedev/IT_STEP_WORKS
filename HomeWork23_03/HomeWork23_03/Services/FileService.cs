using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class FileService
{
    ILogger log;
    public FileService(ILogger l) => log = l;

    public void Save<T>(string path, List<T> data)
    {
        File.WriteAllText(path,
            JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
        log.Log("Збережено");
    }

    public List<T> Load<T>(string path)
    {
        if (!File.Exists(path)) return new();
        log.Log("Завантажено");
        return JsonSerializer.Deserialize<List<T>>(File.ReadAllText(path));
    }
}