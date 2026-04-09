public class RecipeApp
{
    private readonly IRecipeService service;
    private readonly FileService file;
    private readonly ILogger logger;

    public RecipeApp(IRecipeService service, FileService file, ILogger logger)
    {
        this.service = service;
        this.file = file;
        this.logger = logger;
    }

    public void Run()
    {
        var data = file.Load("recipes.json");
        (service as RecipeService).SetData(data);

        while (true)
        {
            Console.WriteLine("\n1 Add 2 Remove 3 Search 4 Save 5 Reports 0 Exit");

            switch (Console.ReadLine())
            {
                case "1": Add(); break;
                case "2": Remove(); break;
                case "3": Search(); break;
                case "4": file.Save("recipes.json", service.GetAll()); break;
                case "5": RecipeReports.FullStats(service.GetAll()); break;
                case "0": return;
            }
        }
    }

    void Add()
    {
        try
        {
            Console.Write("Name: ");
            var name = Console.ReadLine();

            Console.Write("Cuisine: ");
            var cuisine = Console.ReadLine();

            Console.Write("Ingredients: ");
            var ing = Console.ReadLine().Split(',');

            Console.Write("Time: ");
            var time = int.Parse(Console.ReadLine());

            Console.Write("Calories: ");
            var cal = int.Parse(Console.ReadLine());

            service.Add(new Recipe(name, cuisine, new(ing), time, "", cal, ""));

            logger.Log("Рецепт додано");
        }
        catch
        {
            logger.Error("Помилка введення");
        }
    }

    void Remove()
    {
        Console.Write("Name: ");
        service.Remove(Console.ReadLine());
    }

    void Search()
    {
        Console.Write("Query: ");
        foreach (var r in service.Search(Console.ReadLine()))
            Console.WriteLine(r.Name);
    }
}