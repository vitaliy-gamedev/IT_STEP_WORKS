using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("\n1 - Числа");
            Console.WriteLine("2 - Міста");
            Console.WriteLine("3 - Студенти");
            Console.WriteLine("4 - Рядки");
            Console.WriteLine("5 - Авто");
            Console.WriteLine("0 - Вихід");

            switch (Console.ReadLine())
            {
                case "1": Task1_Numbers.Run(); break;
                case "2": Task2_Cities.Run(); break;
                case "3": Task3_Students.Run(); break;
                case "4": Task4_Strings.Run(); break;
                case "5": Task5_Cars.Run(); break;
                case "0": return;
            }
        }
    }
}