using System.Collections.Generic;

public record Recipe(
    string Name,
    string Cuisine,
    List<string> Ingredients,
    int Time,
    string Description,
    int Calories,
    string Type
);