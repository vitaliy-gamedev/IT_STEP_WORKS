using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class FlappyBird
{
    
    static int width = 50;
    static int height = 20;

    
    static double birdY;
    static double velocity;
    static int score;
    static bool isGameOver;
    static List<int[]> pipes;

   
    static double gravity = 0.45;
    static double jump = -1.4;
    static Random random = new Random();

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;

        while (true) 
        {
            ShowMenu();
            ResetGame();
            PlayGame();
        }
    }

    static void ResetGame()
    {
        birdY = 10;
        velocity = 0;
        score = 0;
        isGameOver = false;
        pipes = new List<int[]>();
        pipes.Add(new int[] { width, random.Next(6, height - 6) });
    }

    static void ShowMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n\n   === FLAPPY BIRD C# ===\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("      [SPACE]  - Стрибок");
        Console.WriteLine("      [P]      - Пауза");
        Console.WriteLine("      [ESC]    - Вихід\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("   Натисніть SPACE, щоб почати!");

        while (true)
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Spacebar) return;
            if (key == ConsoleKey.Escape) Environment.Exit(0);
        }
    }

    static void PlayGame()
    {
        while (!isGameOver)
        {
            
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Spacebar) velocity = jump;
                if (key == ConsoleKey.P) PauseMenu();
                if (key == ConsoleKey.Escape) return;
            }

           
            velocity += gravity;
            birdY += velocity;

          
            if (pipes.Count > 0 && pipes[0][0] < 0) pipes.RemoveAt(0);
            if (pipes.Last()[0] < width - 20) pipes.Add(new int[] { width, random.Next(6, height - 6) });

            for (int i = 0; i < pipes.Count; i++)
            {
                pipes[i][0]--;
                if (pipes[i][0] == 8) 
                {
                    if (birdY < pipes[i][1] - 2 || birdY > pipes[i][1] + 2) isGameOver = true;
                    else score++;
                }
            }

            if (birdY <= 0 || birdY >= height) isGameOver = true;

            
            Draw();
            Thread.Sleep(60);
        }

        
        Console.Beep(200, 300); 
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(width / 4, height / 2);
        Console.Write(" ГРА ЗАКІНЧЕНА! Score: " + score + " ");
        Console.SetCursorPosition(width / 4, (height / 2) + 1);
        Console.Write(" Натисніть клавішу для меню... ");
        Console.ResetColor();
        Console.ReadKey(true);
    }

    static void PauseMenu()
    {
        Console.SetCursorPosition(width / 3, height / 2);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(" || ПАУЗА (Space - продовжити) ");
        while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }
        Console.ResetColor();
    }

    static void Draw()
    {
        Console.SetCursorPosition(0, 0);

        ConsoleColor pipeColor = (score < 5) ? ConsoleColor.Green :
                                (score < 15) ? ConsoleColor.Yellow : ConsoleColor.Red;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (x == 8 && y == (int)Math.Round(birdY))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("►"); 
                }
                else
                {
                    bool isPipe = pipes.Any(p => x == p[0] && (y < p[1] - 2 || y > p[1] + 2));
                    if (isPipe)
                    {
                        Console.ForegroundColor = pipeColor;
                        Console.Write("█");
                    }
                    else Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"\n  Score: {score}  |  P - Pause");
    }
}