namespace Game2048
{
    static class Renderer
    {
        public static void Draw(Board board, int score, int best)
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== CONSOLE 2048 ===");
            Console.ResetColor();

            Console.WriteLine($"Score: {score.ToString().PadRight(10)} Best: {best}");
            Console.WriteLine("---------------------");

            var grid = board.Grid;
            // Отримуємо реальну кількість рядків та стовпців з масиву
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int val = grid[i, j];
                    SetColor(val);
                    // Використовуй PadRight(6) або більше, якщо поле велике
                    Console.Write(val == 0 ? ".".PadRight(6) : val.ToString().PadRight(6));
                    Console.ResetColor();
                }
                Console.WriteLine("\n"); // Додатковий відступ між рядками
            }

            Console.WriteLine("---------------------");
            Console.WriteLine("Керування: Стрілки | ESC: Вихід");
        }

        static void SetColor(int value)
        {
            switch (value)
            {
                case 0: Console.ForegroundColor = ConsoleColor.DarkGray; break;
                case 2: Console.ForegroundColor = ConsoleColor.White; break;
                case 4: Console.ForegroundColor = ConsoleColor.Gray; break;
                case 8: Console.ForegroundColor = ConsoleColor.Yellow; break;
                case 16: Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                case 32: Console.ForegroundColor = ConsoleColor.Red; break;
                case 64: Console.ForegroundColor = ConsoleColor.DarkRed; break;
                case 128:
                case 256: Console.ForegroundColor = ConsoleColor.Magenta; break;
                case 512:
                case 1024: Console.ForegroundColor = ConsoleColor.Green; break;
                case 2048: Console.ForegroundColor = ConsoleColor.Cyan; break;
                default: Console.ForegroundColor = ConsoleColor.Blue; break;
            }
        }
    }
}
