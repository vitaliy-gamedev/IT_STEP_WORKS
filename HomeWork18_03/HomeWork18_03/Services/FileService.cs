using System.Text.Json;

public class FileService
{
    private readonly ILogger logger;

    public FileService(ILogger logger)
    {
        this.logger = logger;
    }

    public void Save(string path, List<Recipe> data)
    {
        try
        {
            File.WriteAllText(path,
                JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));

            logger.Log("Файл збережено");
        }
        catch
        {
            logger.Error("Помилка збереження");
        }
    }

    public List<Recipe> Load(string path)
    {
        try
        {
            if (!File.Exists(path))
                return new List<Recipe>();

            var data = JsonSerializer.Deserialize<List<Recipe>>(File.ReadAllText(path));

            logger.Log("Файл завантажено");
            return data;
        }
        catch
        {
            logger.Error("Помилка читання");
            return new List<Recipe>();
        }
    }
}