using System;

namespace HomeWork25_02
{
    public class Tiger : Animal
    {
        private static Random rand = new Random();

        public Tiger(string name) : base(name, "М'ясо", 8) { }

        protected override void RandomEvent()
        {
            int chance = rand.Next(100);

            if (chance < 50)
            {
                Sadness++;
                Scared++;
                Console.WriteLine($"{Name} налякав людей своїм риком! Люди засмучені та налякані.");
                Punishment = "Тигру натягли бантика 🎀";
            }
            else
            {
                Console.WriteLine($"{Name} день пройшов спокійно.");
            }
        }
    }
}