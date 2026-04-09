using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        ILogger log = new ConsoleLogger();
        var file = new FileService(log);

        var albumMenu = new AlbumMenu(new AlbumService(), file);
        var recipeMenu = new RecipeMenu(new RecipeService(), file);

        while (true)
        {
            Console.WriteLine("\n1 Albums 2 Recipes 0 Exit");

            switch (Console.ReadLine())
            {
                case "1": albumMenu.Run(); break;
                case "2": recipeMenu.Run(); break;
                case "0": return;
            }
        }
    }
}