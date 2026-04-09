using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

// Record для користувача
record User(string FirstName, string LastName, string Phone, string Email, string Password);

class Program
{
    static string userFile = "users.json";

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        List<User> users = LoadUsers();

        while (true)
        {
            Console.WriteLine("\nВиберіть дію:");
            Console.WriteLine("1. Перегляд файлу");
            Console.WriteLine("2. Генерація чисел");
            Console.WriteLine("3. Пошук та аналітика по файлу");
            Console.WriteLine("4. Реєстрація користувача");
            Console.WriteLine("5. Авторизація");
            Console.WriteLine("6. Вихід");

            string choice = Console.ReadLine();

            if (choice == "1") ViewFile();
            else if (choice == "2") GenerateNumbers();
            else if (choice == "3") FileAnalytics();
            else if (choice == "4") RegisterUser(users);
            else if (choice == "5") LoginUser(users);
            else if (choice == "6") break;
            else Console.WriteLine("Невірний вибір!");
        }
    }

    static void ViewFile()
    {
        Console.Write("Введіть шлях до файлу: ");
        string path = Console.ReadLine() ?? "";
        if (File.Exists(path))
            Console.WriteLine(File.ReadAllText(path, Encoding.UTF8));
        else
            Console.WriteLine("Файл не існує!");
    }

    static void GenerateNumbers()
    {
        var rand = new Random();
        var even = new List<int>();
        var odd = new List<int>();

        for (int i = 0; i < 10000; i++)
        {
            int n = rand.Next(0, 100000);
            if (n % 2 == 0) even.Add(n);
            else odd.Add(n);
        }

        File.WriteAllLines("even.txt", even.Select(x => x.ToString()), Encoding.UTF8);
        File.WriteAllLines("odd.txt", odd.Select(x => x.ToString()), Encoding.UTF8);

        Console.WriteLine($"Згенеровано 10000 чисел: парні = {even.Count}, непарні = {odd.Count}");
    }

    static void FileAnalytics()
    {
        Console.Write("Введіть шлях до файлу для аналізу: ");
        string path = Console.ReadLine() ?? "";
        if (!File.Exists(path)) { Console.WriteLine("Файл не існує!"); return; }

        string text = File.ReadAllText(path, Encoding.UTF8);

        Console.Write("Введіть слово для пошуку: ");
        string word = Console.ReadLine() ?? "";

        int wordCount = text.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                            .Count(w => string.Equals(w.Trim(new char[] { '.', ',', '!', '?' }), word, StringComparison.OrdinalIgnoreCase));

        int capitalWords = text.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                               .Count(w => char.IsUpper(w[0]));

        int sentenceCount = text.Count(c => c == '.' || c == '!' || c == '?');

        Console.WriteLine($"Слово '{word}' зустрічається: {wordCount} разів");
        Console.WriteLine($"Слів з великої літери: {capitalWords}");
        Console.WriteLine($"Кількість речень: {sentenceCount}");
    }

    static void RegisterUser(List<User> users)
    {
        Console.Write("Ім'я: "); string fn = Console.ReadLine() ?? "";
        Console.Write("Прізвище: "); string ln = Console.ReadLine() ?? "";
        Console.Write("Телефон: "); string ph = Console.ReadLine() ?? "";
        Console.Write("Email: "); string em = Console.ReadLine() ?? "";
        Console.Write("Пароль: "); string pw = Console.ReadLine() ?? "";

        users.Add(new User(fn, ln, ph, em, pw));
        File.WriteAllText(userFile, JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true }), Encoding.UTF8);

        Console.WriteLine("Користувача зареєстровано!");
    }

    static void LoginUser(List<User> users)
    {
        Console.Write("Email: "); string em = Console.ReadLine() ?? "";
        Console.Write("Пароль: "); string pw = Console.ReadLine() ?? "";

        var user = users.Find(u => u.Email == em && u.Password == pw);
        if (user != null)
            Console.WriteLine($"Ласкаво просимо, {user.FirstName}!");
        else
            Console.WriteLine("Невірний email або пароль!");
    }

    static List<User> LoadUsers()
    {
        if (!File.Exists(userFile)) return new List<User>();
        return JsonSerializer.Deserialize<List<User>>(File.ReadAllText(userFile, Encoding.UTF8)) ?? new List<User>();
    }
}