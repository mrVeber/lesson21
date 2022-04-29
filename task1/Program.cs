using System;
using System.Threading;

namespace task1
{
    class Program
    {
        const int x = 5;
        const int y = 5;
        static int[,] garden = new int[x, y]
        {
            {1,6,6,5,9 },
            {2,6,9,4,5 },
            {6,9,5,7,8 },
            {2,6,9,8,5 },
            {9,5,4,7,8 }
        };
        Random rnd = new Random();

        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(Gardener1);
            Thread thread = new Thread(Gardener1);
            thread.Start();

            Gardener2();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write($"{garden[i,j]} ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        static void Gardener1()
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (garden[i,j] >= 0)
                    {
                        int delay = garden[i, j];
                        garden[i, j] = -1;
                        Thread.Sleep(delay);
                    }
                }

            }
        }
        static void Gardener2()
        {
            for (int i = x-1; i >= 0; i--)
            {
                for (int j = y-1; j >= 0; j--)
                {
                    if (garden[i, j] >= 0)
                    {
                        int delay = garden[i, j];
                        garden[i, j] = -2;
                        Thread.Sleep(delay);
                    }
                }

            }
        }
    }
}
