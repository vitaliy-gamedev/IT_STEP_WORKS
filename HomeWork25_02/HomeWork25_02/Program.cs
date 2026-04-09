using System;
using System.Text;

namespace HomeWork25_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Zoo zoo = new Zoo();

            zoo.AddAnimal(new Tiger("Шерхан"));
            zoo.AddAnimal(new Crocodile("Гена"));
            zoo.AddAnimal(new Kangaroo("Джек"));
            zoo.AddAnimal(new Snake("Слінк"));
            zoo.AddAnimal(new Zebra("Марті"));

            int day = 1;
            while (true)
            {
                Console.WriteLine($"\n=== День {day} ===");
                zoo.DailyEvents();

                Console.WriteLine("\nНатисніть Enter для наступного дня, або Q щоб вийти...");
                string input = Console.ReadLine();
                if (input?.ToUpper() == "Q") break;

                day++;
            }

            zoo.ShowStatistics();
        }
    }
}