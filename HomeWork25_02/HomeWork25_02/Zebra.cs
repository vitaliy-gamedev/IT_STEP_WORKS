using System;

namespace HomeWork25_02
{
    public class Zebra : Animal
    {
        private static Random rand = new Random();
        public int StripeCount { get; set; } = 0;

        public Zebra(string name) : base(name, "Трава", 4) { }

        protected override void RandomEvent()
        {
            int chance = rand.Next(100);

            if (chance < 30)
            {
                Sadness++;
                Scared++;
                StripeCount = rand.Next(30, 50);
                Console.WriteLine($"{Name} засмутилася, бо не встигає порахувати всі свої полоски і ховається.");
                Punishment = "Менше спілкуватися з кенгуру 🦓🚫🦘";
            }
            else
            {
                Console.WriteLine($"{Name} день пройшов спокійно.");
            }
        }

        public override void ShowStats()
        {
            Console.WriteLine($"{Name} | Корм з’їдено: {TotalFoodEaten} кг | Засмучення людей: {Sadness} | Люди налякані: {Scared} | Полосок пораховано: {StripeCount} | Покарання: {Punishment}");
        }
    }
}