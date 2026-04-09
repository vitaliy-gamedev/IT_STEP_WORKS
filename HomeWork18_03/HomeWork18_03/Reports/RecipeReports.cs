public static class RecipeReports
{
    public static void FullStats(List<Recipe> r)
    {
        Console.WriteLine("\n=== Статистика ===");

        Console.WriteLine("\nПо кухні:");
        (from x in r group x by x.Cuisine)
        .ToList()
        .ForEach(g => Console.WriteLine($"{g.Key}: {g.Count()}"));

        Console.WriteLine("\nТоп калорій:");
        (from x in r orderby x.Calories descending select x)
        .Take(3)
        .ToList()
        .ForEach(x => Console.WriteLine($"{x.Name} {x.Calories}"));

        Console.WriteLine("\nШвидкі рецепти (<30):");
        (from x in r where x.Time < 30 select x)
        .ToList()
        .ForEach(x => Console.WriteLine(x.Name));
    }
}