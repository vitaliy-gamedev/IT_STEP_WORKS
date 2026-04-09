public interface IRecipeService
{
    void Add(Recipe r);
    void Remove(string name);
    IEnumerable<Recipe> Search(string q);
    List<Recipe> GetAll();
}