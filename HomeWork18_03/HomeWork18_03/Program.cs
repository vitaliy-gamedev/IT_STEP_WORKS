using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        ILogger logger = new ConsoleLogger();
        var service = new RecipeService();
        var file = new FileService(logger);

        var app = new RecipeApp(service, file, logger);

        app.Run();
    }
}