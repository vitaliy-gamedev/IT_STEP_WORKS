using System.Text;

namespace Game2048
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            Game game = new Game();
            game.Run();
        }
    }
}
