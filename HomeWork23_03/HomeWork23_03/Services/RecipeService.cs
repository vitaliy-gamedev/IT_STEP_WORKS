using System.Collections.Generic;
using System.Linq;

public class RecipeService : IService<Recipe>
{
    public List<Recipe> Data { get; set; } = new();

    // Отримати всі
    public List<Recipe> GetAll() => Data;

    // Додати рецепт
    public void Add(Recipe r) => Data.Add(r);

    // Видалити рецепт
    public void Remove(string name) =>
        Data.RemoveAll(r => r.Name == name);

    // Оновити рецепт
    public void Update(string oldName, string newName)
    {
        var r = Data.FirstOrDefault(x => x.Name == oldName);
        if (r != null)
            Data[Data.IndexOf(r)] = r with { Name = newName };
    }

    // Пошук (по всім полям)
    public IEnumerable<Recipe> Search(string q) =>
        from r in Data
        where r.Name.Contains(q)
           || r.Cuisine.Contains(q)
           || r.Type.Contains(q)
           || r.Ingredients.Any(i => i.Contains(q))
        select r;
}