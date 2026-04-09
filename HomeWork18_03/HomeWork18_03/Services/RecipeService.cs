public class RecipeService : IRecipeService
{
    private List<Recipe> recipes = new();

    public void SetData(List<Recipe> data) => recipes = data;

    public List<Recipe> GetAll() => recipes;

    public void Add(Recipe r) => recipes.Add(r);

    public void Remove(string name) =>
        recipes.RemoveAll(r => r.Name == name);

    public IEnumerable<Recipe> Search(string q) =>
        from r in recipes
        where r.Name.Contains(q) ||
              r.Cuisine.Contains(q) ||
              r.Ingredients.Any(i => i.Contains(q))
        select r;
}