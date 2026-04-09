using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

public class RecipeMenu
{
    RecipeService s;
    FileService f;

    public RecipeMenu(RecipeService s, FileService f)
    {
        this.s = s;
        this.f = f;
    }

    public void Run()
    {
        s.Data = f.Load<Recipe>("recipes.json");

        while (true)
        {
            try
            {
                Console.WriteLine("\n1 Додати рецепт");
                Console.WriteLine("2 Видалити рецепт");
                Console.WriteLine("3 Редагувати");
                Console.WriteLine("4 Пошук");
                Console.WriteLine("5 Зберегти");
                Console.WriteLine("6 Звіти");
                Console.WriteLine("0 Назад");

                switch (Console.ReadLine())
                {
                    // ➕ ДОДАТИ
                    case "1":
                        Console.Write("Назва: ");
                        string name = Console.ReadLine();

                        Console.Write("Кухня: ");
                        string cuisine = Console.ReadLine();

                        Console.Write("Інгредієнти (через кому): ");
                        List<string> ing = Console.ReadLine().Split(',').ToList();

                        Console.Write("Час (хв): ");
                        int time = int.Parse(Console.ReadLine());

                        Console.Write("Опис: ");
                        string desc = Console.ReadLine();

                        Console.Write("Калорії: ");
                        int cal = int.Parse(Console.ReadLine());

                        Console.Write("Тип (салат/перше/друге/...): ");
                        string type = Console.ReadLine();

                        s.Add(new Recipe(name, cuisine, ing, time, desc, cal, type));
                        break;

                    // ❌ ВИДАЛИТИ
                    case "2":
                        Console.Write("Назва: ");
                        s.Remove(Console.ReadLine());
                        break;

                    // ✏️ UPDATE
                    case "3":
                        Console.Write("Стара назва: ");
                        string oldName = Console.ReadLine();

                        Console.Write("Нова назва: ");
                        string newName = Console.ReadLine();

                        s.Update(oldName, newName);
                        break;

                    // 🔍 ПОШУК
                    case "4":
                        Console.Write("Пошук: ");
                        string q = Console.ReadLine();

                        foreach (var r in s.Search(q))
                            Console.WriteLine($"{r.Name} ({r.Cuisine})");
                        break;

                    // 💾 SAVE
                    case "5":
                        f.Save("recipes.json", s.Data);
                        break;

                    // 📊 REPORTS
                    case "6":
                        Console.WriteLine("\n1 Кухня 2 Час 3 Калорії 4 Тип 5 Інгредієнт 6 Назва");

                        switch (Console.ReadLine())
                        {
                            case "1":
                                RecipeReports.ByCuisine(s.Data);
                                break;

                            case "2":
                                RecipeReports.ByTime(s.Data);
                                break;

                            case "3":
                                RecipeReports.ByCalories(s.Data);
                                break;

                            case "4":
                                RecipeReports.ByType(s.Data);
                                break;

                            case "5":
                                Console.Write("Інгредієнт: ");
                                RecipeReports.ByIngredient(s.Data, Console.ReadLine());
                                break;

                            case "6":
                                RecipeReports.ByName(s.Data);
                                break;
                        }
                        break;

                    case "0":
                        return;
                }
            }
            catch
            {
                Console.WriteLine("Помилка вводу!");
            }
        }
    }
}