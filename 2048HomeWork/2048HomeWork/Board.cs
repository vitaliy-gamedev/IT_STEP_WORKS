using System;
using System.Collections.Generic;

namespace Game2048
{
    internal class Board
    {
        public int[,] Grid { get; private set; }
        private Random _random = new Random();
        private const int Size = 4;

        public Board() //Що б можна було змінювати розмір карти
        {
            Grid = new int[Size, Size];
            Reset();
        }

        public void Reset()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    Grid[i, j] = 0;

            AddRandomTile();
            AddRandomTile();
        }

        public void AddRandomTile()
        {
            List<int> emptyIndices = new List<int>();
            for (int i = 0; i < Size * Size; i++)
                if (Grid[i / Size, i % Size] == 0) emptyIndices.Add(i);

            if (emptyIndices.Count > 0)
            {
                int index = emptyIndices[_random.Next(emptyIndices.Count)];
                Grid[index / Size, index % Size] = _random.Next(10) < 9 ? 2 : 4;
            }
        }

        public bool Move(ConsoleKey key, out int gainedScore)
        {
            gainedScore = 0;
            // Створюємо копію масиву до ходу для порівняння
            int[,] oldGrid = (int[,])Grid.Clone();

            for (int i = 0; i < Size; i++)
            {
                int[] line = new int[Size];

                // Витягуємо лінію залежно від напрямку
                for (int j = 0; j < Size; j++)
                {
                    if (key == ConsoleKey.LeftArrow) line[j] = Grid[i, j];
                    if (key == ConsoleKey.RightArrow) line[j] = Grid[i, Size - 1 - j];
                    if (key == ConsoleKey.UpArrow) line[j] = Grid[j, i];
                    if (key == ConsoleKey.DownArrow) line[j] = Grid[Size - 1 - j, i];
                }

                // Обробка лінії (зсув та злиття)
                ProcessLine(line, ref gainedScore);

                // Повертаємо лінію в матрицю
                for (int j = 0; j < Size; j++)
                {
                    if (key == ConsoleKey.LeftArrow) Grid[i, j] = line[j];
                    if (key == ConsoleKey.RightArrow) Grid[i, Size - 1 - j] = line[j];
                    if (key == ConsoleKey.UpArrow) Grid[j, i] = line[j];
                    if (key == ConsoleKey.DownArrow) Grid[Size - 1 - j, i] = line[j];
                }
            }

            // Перевірка: чи змінилася матриця (якщо так — хід відбувся)
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (Grid[i, j] != oldGrid[i, j]) return true;

            return false;
        }

        private void ProcessLine(int[] line, ref int score)
        {
            // 1. Зсув (стискання)
            Shift(line);

            // 2. Злиття
            for (int i = 0; i < Size - 1; i++)
            {
                if (line[i] != 0 && line[i] == line[i + 1])
                {
                    line[i] *= 2;
                    score += line[i];
                    line[i + 1] = 0;
                    Shift(line); // Повторний зсув після злиття
                }
            }
        }

        private void Shift(int[] line)
        {
            int position = 0;
            for (int i = 0; i < Size; i++)
            {
                if (line[i] != 0)
                {
                    int temp = line[i];
                    line[i] = 0;
                    line[position] = temp;
                    position++;
                }
            }
        }

        public bool IsGameOver()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                {
                    if (Grid[i, j] == 0) return false;
                    if (i < Size - 1 && Grid[i, j] == Grid[i + 1, j]) return false;
                    if (j < Size - 1 && Grid[i, j] == Grid[i, j + 1]) return false;
                }
            return true;
        }
    }
}