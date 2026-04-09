using System;

namespace HomeWork25_02
{
    public class Crocodile : Animal
    {
        private static Random rand = new Random();

        public Crocodile(string name) : base(name, "Риба", 5) { }

        protected override void RandomEvent()
        {
            int chance = rand.Next(100);

            if (chance < 40)
            {
                Sadness++;
                Scared++;
                Console.WriteLine($"{Name} лякає людей, вони засмучені та налякані!");
                Punishment = "Крокодилу заборонили спілкуватися з кенгуру 🐊🚫🦘";
            }
            else
            {
                Console.WriteLine($"{Name} день пройшов спокійно.");
            }
        }
    }
}