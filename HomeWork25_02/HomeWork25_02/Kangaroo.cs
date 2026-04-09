using System;

namespace HomeWork25_02
{
    public class Kangaroo : Animal
    {
        private static Random rand = new Random();

        public Kangaroo(string name) : base(name, "Трава", 3) { }

        protected override void RandomEvent()
        {
            int chance = rand.Next(100);

            if (chance < 30)
            {
                Sadness++;
                Scared++;
                Console.WriteLine($"{Name} налякав людей своїми стрибками! Люди засмучені та налякані.");
                Punishment = "У кенгуру забрали рукавиці для боксу 🥊";
            }
            else
            {
                Console.WriteLine($"{Name} день пройшов спокійно.");
            }
        }
    }
}