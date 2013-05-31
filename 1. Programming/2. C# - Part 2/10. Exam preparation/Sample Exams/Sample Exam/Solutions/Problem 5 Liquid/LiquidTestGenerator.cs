using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_5_Liquid
{
    public class LiquidTestGenerator
    {
        static readonly int width = 15;
        static readonly int height = 15;
        static readonly int depth = 15;
        static readonly int pathsCount = 2000;
        static readonly int noiseCount = 1000;

        static readonly int[, ,] cuboid = new int[width, height, depth];
        static bool[, ,] visited;
        static readonly Random rnd = new Random();

        static void Main()
        {
            // Generate paths in the cuboid
            for (int i = 0; i < pathsCount; i++)
            {
                GeneratePath();
            }

            // Generate random noise
            for (int i = 0; i < noiseCount; i++)
            {
                GenerateNoise();
            }

            PrintCuboid();
        }

        private static void GeneratePath()
        {
            visited = new bool[width, height, depth];
            int w = rnd.Next(width);
            int h = rnd.Next(height);
            int d = 0;
            while (d < depth)
            {
                cuboid[w, h, d]++;
                visited[w, h, d] = true;
                int newW, newH, newD;
                while (true)
                {
                    FindNextRandomPosition(w, h, d, out newW, out newH, out newD);
                    if (ValidPosition(newW, newH, newD))
                    {
                        // New position found
                        break;
                    }
                }
                w = newW;
                h = newH;
                d = newD;
            }
        }

        private static void GenerateNoise()
        {
            int w = rnd.Next(width);
            int h = rnd.Next(height);
            int d = rnd.Next(depth);
            if (cuboid[w, h, d] < 100)
            {
                cuboid[w, h, d]++;
            }
        }

        private static bool ValidPosition(int w, int h, int d)
        {
            return
                (w >= 0) && (w < width) &&
                (h >= 0) && (h < height) &&
                (d >= 0) && (d <= depth) &&
                (d == depth || !visited[w, h, d]);
        }

        private static void FindNextRandomPosition(int w, int h, int d,
            out int newW, out int newH, out int newD)
        {
            newW = w;
            newH = h;
            newD = d;
            if ((d == 0) || (d == depth - 1))
            {
                // The first and the last step are always "down"
                newD++;
                return;
            }

            int direction = rnd.Next(9);
            if (direction <= 1)
            {
                newW++;
            }
            else if (direction <= 3)
            {
                newW--;
            }
            else if (direction <= 5)
            {
                newH++;
            }
            else if (direction <= 7)
            {
                newH--;
            }
            else if (direction == 8)
            {
                newD++;
            }
        }

        private static void PrintCuboid()
        {
            Console.WriteLine("{0} {1} {2}", width, height, depth);
            for (int hhh = 0; hhh < height; hhh++)
            {
                for (int ddd = 0; ddd < depth; ddd++)
                {
                    for (int www = 0; www < width; www++)
                    {
                        Console.Write(cuboid[www, hhh, ddd]);
                        if (www < width - 1)
                        {
                            Console.Write(' ');
                        }
                    }
                    if (ddd < depth - 1)
                    {
                        Console.Write(" | ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
