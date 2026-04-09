using System.Collections.Generic;

public record Recipe(
    string Name,
    string Cuisine,
    List<string> Ingredients,
    int Time,
    string Desc,
    int Calories,
    string Type
);