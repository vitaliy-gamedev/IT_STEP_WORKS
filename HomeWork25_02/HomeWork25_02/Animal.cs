using System;

namespace HomeWork25_02
{
    public abstract class Animal
    {
        private static Random rand = new Random();

        public string Name { get; set; }
        public string FoodType { get; set; }
        public double FoodPerDayKg { get; set; }

        // Статистика емоцій людей
        public int Sadness { get; protected set; } = 0;
        public int Scared { get; protected set; } = 0;

        // Кумедне покарання
        public string Punishment { get; protected set; } = "Немає";

        // Облік з’їденого корму
        public double TotalFoodEaten { get; private set; } = 0;

        protected Animal(string name, string foodType, double foodPerDayKg)
        {
            Name = name;
            FoodType = foodType;
            FoodPerDayKg = foodPerDayKg;
        }

        // Щоденні події
        public void DailyEvent()
        {
            EatFood();
            RandomEvent();
        }

        public void EatFood()
        {
            TotalFoodEaten += FoodPerDayKg;
            Console.WriteLine($"{Name} з’їв {FoodPerDayKg} кг {FoodType}.");
        }

        protected virtual void RandomEvent()
        {
            int chance = rand.Next(100);

            if (chance < 50)
            {
                Console.WriteLine($"{Name} день пройшов спокійно.");
            }
        }

        public virtual void ShowStats()
        {
            Console.WriteLine($"{Name} | Корм з’їдено: {TotalFoodEaten} кг | Засмучення людей: {Sadness} | Люди налякані: {Scared} | Покарання: {Punishment}");
        }

        public override string ToString()
        {
            return $"{GetType().Name} | {Name} | Корм: {FoodType} | {FoodPerDayKg} кг/день | З’їдено корму: {TotalFoodEaten} кг | Засмучення: {Sadness} | Налякані: {Scared} | Покарання: {Punishment}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Animal other)
                return Name == other.Name &&
                       FoodType == other.FoodType &&
                       FoodPerDayKg == other.FoodPerDayKg &&
                       GetType() == other.GetType();
            return false;
        }

        public override int GetHashCode()
        {
            return (Name, FoodType, FoodPerDayKg, GetType()).GetHashCode();
        }
    }
}