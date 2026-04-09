using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork25_02
{
    public class Zoo
    {
        private List<Animal> animals = new List<Animal>();
        private object totalFood;

        public void AddAnimal(Animal animal) => animals.Add(animal);

        public void DailyEvents()
        {
            Console.WriteLine("\n=== Події дня ===");
            foreach (var animal in animals)
            {
                animal.DailyEvent();
            }
        }

        public void ShowStatistics()
        {
            Console.WriteLine("\n=== Статистика зоопарку ===");
            foreach (var animal in animals)
                animal.ShowStats();

            int totalSad = animals.Sum(a => a.Sadness);
            int totalScared = animals.Sum(a => a.Scared);

            Console.WriteLine($"\nСума з’їденого корму: {totalFood} кг | Загальна сумність людей: {totalSad} | Загальна наляканість людей: {totalScared}");

        }
    }
}