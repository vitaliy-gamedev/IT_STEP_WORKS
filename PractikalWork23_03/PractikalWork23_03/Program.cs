using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;


record User(string FirstName, string LastName, string Phone, string Email, string Password);

class Program
{
    static string filePath = "users.json";
    static string key = "MySuperSecretKey";

    static void Main()
    {
        var users = LoadUsers();
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("\nВиберіть дію:");
            Console.WriteLine("1. Реєстрація");
            Console.WriteLine("2. Авторизація");
            Console.WriteLine("3. Вихід");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Ім'я: "); var fn = Console.ReadLine();
                Console.Write("Прізвище: "); var ln = Console.ReadLine();
                Console.Write("Телефон: "); var ph = Console.ReadLine();
                Console.Write("Email: "); var em = Console.ReadLine();
                Console.Write("Пароль: "); var pw = Encrypt(Console.ReadLine() ?? "");

                users.Add(new User(fn!, ln!, ph!, em!, pw));
                File.WriteAllText(filePath, JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true }), Encoding.UTF8);

                Console.WriteLine("Користувача зареєстровано!");
            }
            else if (choice == "2")
            {
                Console.Write("Email: "); var em = Console.ReadLine();
                Console.Write("Пароль: "); var pw = Console.ReadLine();

                var user = users.Find(u => u.Email == em);
                if (user != null && Decrypt(user.Password) == pw)
                    Console.WriteLine($"Ласкаво просимо, {user.FirstName}!");
                else
                    Console.WriteLine("Невірний email або пароль!");
            }
            else if (choice == "3")
            {
                Console.WriteLine("Вихід з програми...");
                break;
            }
            else
            {
                Console.WriteLine("Невірний вибір! Спробуйте ще раз.");
            }
        }
    }

    static List<User> LoadUsers()
    {
        if (!File.Exists(filePath)) return new List<User>();
        return JsonSerializer.Deserialize<List<User>>(File.ReadAllText(filePath, Encoding.UTF8)) ?? new List<User>();
    }

    static string Encrypt(string plainText)
    {
        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32));
        aes.IV = new byte[16];
        using var ms = new MemoryStream();
        using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
        using (var sw = new StreamWriter(cs, Encoding.UTF8)) sw.Write(plainText);
        return Convert.ToBase64String(ms.ToArray());
    }

    static string Decrypt(string cipherText)
    {
        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32));
        aes.IV = new byte[16];
        using var ms = new MemoryStream(Convert.FromBase64String(cipherText));
        using var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
        using var sr = new StreamReader(cs, Encoding.UTF8);
        return sr.ReadToEnd();
    }
}