using System;

namespace HomeWork25_02
{
    public class Snake : Animal
    {
        private static Random rand = new Random();

        public Snake(string name) : base(name, "Миші", 1) { }

        protected override void RandomEvent()
        {
            int chance = rand.Next(100);

            if (chance < 30)
            {
                Sadness++;
                Scared++;
                Console.WriteLine($"{Name} розмовляла з людиною і пропонувала пиво. Людина засмучена.");
                Punishment = "Змії не пускали до магазину 🛒🚫";
            }
            else
            {
                Console.WriteLine($"{Name} день пройшов спокійно.");
            }
        }
    }
}