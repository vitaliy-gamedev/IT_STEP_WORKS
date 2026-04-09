using System;
using System.Linq;
using System.Collections.Generic;

public static class RecipeReports
{
    public static void ByCuisine(List<Recipe> r) =>
        (from x in r group x by x.Cuisine)
        .ToList()
        .ForEach(g => Console.WriteLine($"{g.Key}: {g.Count()}"));

    public static void ByTime(List<Recipe> r) =>
        (from x in r orderby x.Time select x)
        .ToList()
        .ForEach(x => Console.WriteLine($"{x.Name} - {x.Time} хв"));

    public static void ByCalories(List<Recipe> r) =>
        (from x in r orderby x.Calories descending select x)
        .ToList()
        .ForEach(x => Console.WriteLine($"{x.Name} - {x.Calories}"));

    public static void ByType(List<Recipe> r) =>
        (from x in r group x by x.Type)
        .ToList()
        .ForEach(g => Console.WriteLine($"{g.Key}: {g.Count()}"));

    public static void ByIngredient(List<Recipe> r, string ing) =>
        (from x in r where x.Ingredients.Contains(ing) select x)
        .ToList()
        .ForEach(x => Console.WriteLine(x.Name));

    public static void ByName(List<Recipe> r) =>
        (from x in r orderby x.Name select x)
        .ToList()
        .ForEach(x => Console.WriteLine(x.Name));
}