namespace Game2048
{
    class Game
    {
        private Board board = new Board();
        private int score = 0;
        private int highScore = 0;

        public void Run()
        {
            while (true)
            {
                StartNewGame();
                GameLoop();

                Console.SetCursorPosition(0, 15);
                Console.WriteLine("R — нова гра, інша клавіша — вихід");
                if (Console.ReadKey(true).Key != ConsoleKey.R)
                    break;
            }
        }

        void StartNewGame()
        {
            board.Reset();
            score = 0;
        }

        void GameLoop()
        {
            while (true)
            {
                Renderer.Draw(board, score, highScore);

                if (board.IsGameOver())
                {
                    Console.SetCursorPosition(0, 13);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ГРА ЗАКІНЧЕНА!");
                    Console.ResetColor();
                    break;
                }

                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Escape) break;

                if (board.Move(key, out int gained))
                {
                    score += gained;
                    highScore = Math.Max(highScore, score);
                    board.AddRandomTile();
                }
            }
        }
    }
}
