using System;

namespace Labirynth_2._0
{
    public struct Vector2
    {
        public int y;
        public int x;
    }
    internal class Program
    {
        private static Random random = new Random();

        private static int fieldDimensionX = 20;
        private static int fieldDimensionY = fieldDimensionX * 2;

        private static Vector2 player = new Vector2();
        private static Vector2 finish = new Vector2();
        private static char[,] field = new char[fieldDimensionY, fieldDimensionX];

        private static char playerChar = '@';
        private static char wallChar = 'O';
        private static char airChar = ' ';
        private static char finishChar = 'F';

        private static double wallFrequency = 0.3;

        private static bool isGameRunning = true;

        static void Main(string[] args)
        {
            InitPositions();
            InitField();
            while (isGameRunning)
            {
                TryToMovePlayer();
            }
            Console.ReadKey();
        }

        static void InitPositions()
        {
            player.y = random.Next(0, fieldDimensionX);
            player.x = random.Next(0, fieldDimensionY);

            finish.y = random.Next(0, fieldDimensionX);
            finish.x = random.Next(0, fieldDimensionY);
        }

        static void InitField()
        {
            Console.Clear();

            for (int i = 0; i < fieldDimensionX; i++)
            {
                for (int j = 0; j < fieldDimensionY; j++)
                {
                    field[j, i] = GetChar();
                    field[player.x, player.y] = playerChar;
                    field[finish.x, finish.y] = finishChar;
                    Console.Write(field[j, i]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("player y: " + player.y);
            Console.WriteLine("player x: " + player.x);
            Console.WriteLine();
            Console.WriteLine("finish y:" + finish.y);
            Console.WriteLine("finish x:" + finish.x);
        }

        static void TryToMovePlayer()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:

                    if (field[player.x, player.y - 1] == ' ')
                    {
                        player.y -= 1;
                        field[player.x, player.y + 1] = ' ';

                        DrawField();
                    }
                    else if (field[player.x, player.y - 1] == 'F')
                    {
                        Win();
                    }

                    break;
                case ConsoleKey.DownArrow:

                    if (field[player.x, player.y + 1] == ' ')
                    {
                        player.y += 1;
                        field[player.x, player.y - 1] = ' ';

                        DrawField();
                    }
                    else if (field[player.x, player.y + 1] == 'F')
                    {
                        Win();
                    }

                    break;
                case ConsoleKey.LeftArrow:

                    if (field[player.x - 1, player.y] == ' ')
                    {
                        player.x -= 1;
                        field[player.x + 1, player.y] = ' ';

                        DrawField();
                    }
                    else if (field[player.x - 1, player.y] == 'F')
                    {
                        Win();
                    }

                    break;
                case ConsoleKey.RightArrow:

                    if (field[player.x + 1, player.y] == ' ')
                    {
                        player.x += 1;
                        field[player.x - 1, player.y] = ' ';

                        DrawField();
                    }
                    else if (field[player.x + 1, player.y] == 'F')
                    {
                        Win();
                    }

                    break;
            }
        }

        static void DrawField()
        {
            Console.Clear();

            for (int i = 0; i < fieldDimensionX; i++)
            {
                for (int j = 0; j < fieldDimensionY; j++)
                {
                    field[player.x, player.y] = playerChar;
                    Console.Write(field[j, i]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("player y: " + player.y);
            Console.WriteLine("player x: " + player.x);
            Console.WriteLine();
            Console.WriteLine("finish y:" + finish.y);
            Console.WriteLine("finish x:" + finish.x);
        }
        static char GetChar()
        {
            if (random.NextDouble() <= wallFrequency)
            {
                return wallChar;
            }
            return airChar;
        }

        static void Win()
        {
            Console.Clear();
            Console.WriteLine("YOU WIN!");
            isGameRunning = false;
        }
    }
}