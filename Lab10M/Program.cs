using System;
using System.IO;
using System.Diagnostics;

namespace Lab10M
{
    class Program
    {
        static int x = 0, y = 4;
        static bool health;
        static void Main(string[] args)
        {
            var watch = Stopwatch.StartNew();
            int iter = 1;
            string maze = File.ReadAllText("C:\\Users\\kosti\\Desktop\\maze.txt");
            string[] mazemass = maze.Split(Environment.NewLine);
            char[,] mazecharmass = new char[mazemass.Length, mazemass[0].Length];
            for (int i = 0; i < mazecharmass.GetLength(0); i++)
            {
                for (int j = 0; j < mazecharmass.GetLength(1); j++)
                {
                    mazecharmass[i, j] = mazemass[i][j];
                    if (x == i && j == y)
                        Console.Write(1);
                    else
                        Console.Write(mazecharmass);
                }
                Console.WriteLine();
            }

            ConsoleKeyInfo player = new ConsoleKeyInfo();
            while (true)
            {
                Maze(mazecharmass, iter);
                player = Console.ReadKey(intercept: true);
                switch (player.Key)
                {
                    case ConsoleKey.S:
                        if (x < mazecharmass.GetLength(0) - 1)
                        {
                            if (mazecharmass[x + 1, y] == '#')
                            {
                                break;
                            }
                            x += 1;
                            iter += 1;
                        }
                        break;
                    case ConsoleKey.D:
                        if (y < mazecharmass.GetLength(1) - 1)
                        {
                            if (mazecharmass[x, y + 1] == '#')
                            {
                                break;
                            }
                            y += 1;
                            iter += 1;
                        }
                        break;
                    case ConsoleKey.A:
                        if (0 < y)
                        {
                            if (mazecharmass[x, y - 1] == '#')
                            {
                                break;
                            }
                            y -= 1;
                            iter += 1;
                        }
                        break;
                    case ConsoleKey.W:
                        if (x > 0)
                        {
                            if (mazecharmass[x - 1, y] == '#')
                            {
                                break;
                            }
                            x -= 1;
                            iter += 1;
                        }
                        break;
                }
                if (mazecharmass[x, y] == 'F')
                {
                    break;
                }

                if (mazecharmass[x, y] == 'X')
                {
                    health = false;
                    LoseOrWin(health);
                }
            }

            string maze2 = File.ReadAllText("C:\\Users\\kosti\\Desktop\\maze2.txt");
            string[] maze2mass = maze2.Split(Environment.NewLine);
            char[,] maze2masschar = new char[maze2mass.Length, maze2mass[0].Length];

            for (int i = 0; i < maze2masschar.GetLength(0); i++)
            {
                for (int j = 0; j < maze2masschar.GetLength(1); j++)
                {
                    maze2masschar[i, j] = maze2mass[i][j];
                    if (x == i && j == y)
                        Console.Write(1);
                    else
                        Console.Write(maze2masschar);
                }
                Console.WriteLine();
            }


            x = 0;
            y = 7;
            ConsoleKeyInfo player2 = new ConsoleKeyInfo();
            while (true)
            {
                Maze2(maze2masschar, iter);
                player2 = Console.ReadKey(intercept: true);
                switch (player2.Key)
                {
                    case ConsoleKey.S:
                        if (x < maze2masschar.GetLength(0) - 1)
                        {
                            if (maze2masschar[x + 1, y] == '#')
                            {
                                break;
                            }
                            x += 1;

                        }
                        iter += 1;
                        break;
                    case ConsoleKey.D:
                        if (y < maze2masschar.GetLength(1) - 1)
                        {
                            if (maze2masschar[x, y + 1] == '#')
                            {
                                break;
                            }
                            y += 1;
                        }
                        iter += 1;
                        break;
                    case ConsoleKey.A:
                        if (0 < y)
                        {
                            if (maze2masschar[x, y - 1] == '#')
                            {
                                break;
                            }
                            y -= 1;
                            iter += 1;
                        }
                        iter += 1;
                        break;
                    case ConsoleKey.W:
                        if (x > 0)
                        {
                            if (maze2masschar[x - 1, y] == '#')
                            {
                                break;
                            }
                            x -= 1;
                        }
                        iter += 1;
                        break;
                }
                if (maze2masschar[x, y] == 'F')
                {
                    health = true;
                    LoseOrWin(health);
                    break;
                }
                if (maze2masschar[x, y] == 'X')
                {
                    health = false;
                    LoseOrWin(health);
                    break;
                }
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            string PathToRecord = @"C:\\Users\\kosti\\Desktop\\Records.txt";
            FiksiruemPribyl(PathToRecord, elapsedMs);
            string records = File.ReadAllText(@"C:\\Users\\kosti\\Desktop\\Records.txt");
            Console.WriteLine(records);
        }





        static void Maze(char[,] mazen, int iteration)
        {
            Console.Clear();
            for (int i = 0; i < mazen.GetLength(0); i++)
            {
                for (int j = 0; j < mazen.GetLength(1); j++)
                {
                    if (x == i && y == j)
                        Console.Write(1);
                    else
                        Console.Write(mazen[i, j]);
                    if (iteration % 2 == 1)
                    {
                        mazen[1, 2] = ' ';
                        mazen[2, 6] = 'X';
                        mazen[3, 5] = ' ';
                    }
                    else
                    {
                        mazen[1, 2] = 'X';
                        mazen[2, 6] = ' ';
                        mazen[3, 5] = 'X';
                    }
                }
                Console.WriteLine();
            }
        }





        static void Maze2(char[,] mazen, int iteration)
        {
            Console.Clear();

            for (int i = 0; i < mazen.GetLength(0); i++)
            {
                for (int j = 0; j < mazen.GetLength(1); j++)
                {
                    if (x == i && y == j)
                        Console.Write(1);
                    else
                        Console.Write(mazen[i, j]);
                    if (iteration % 2 == 1)
                    {
                        mazen[1, 4] = ' ';
                        mazen[2, 11] = 'X';
                        mazen[3, 7] = ' ';
                        mazen[5, 7] = 'X';
                        mazen[6, 9] = ' ';
                    }
                    else
                    {
                        mazen[1, 4] = 'X';
                        mazen[2, 11] = ' ';
                        mazen[3, 7] = 'X';
                        mazen[5, 7] = ' ';
                        mazen[6, 9] = 'X';
                    }
                }
                Console.WriteLine();
            }
        }





        static void LoseOrWin(bool hp)
        {
            Console.Clear();
            if (hp == false)
            {
                Console.WriteLine("You died.");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("You won!");
            }
        }





        static void FiksiruemPribyl(string Pokupaem, long time)
        {
            StreamWriter Dokupaem = new StreamWriter(Pokupaem, true);
            Dokupaem.WriteLine(time);
            Dokupaem.Close();
        }
    }
}