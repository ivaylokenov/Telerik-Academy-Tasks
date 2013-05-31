using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_4_3D_Max_Walk
{
    class MaxWalk3D
    {
        static int width;
        static int height;
        static int depth;
        static short[, ,] cuboid;
        static bool[, ,] visited;

        static void Main()
        {
            ReadCuboid();
            long sum = CalculateWalkSum();
            Console.WriteLine(sum);
        }

        private static long CalculateWalkSum()
        {
            int w = width / 2;
            int h = height / 2;
            int d = depth / 2;
            bool finished = false;
            long sum = cuboid[w, h, d];
            visited = new bool[width, height, depth];
            while (!finished)
            {
                visited[w, h, d] = true;

                int newW, newH, newD, maxCount;
                GetNextPosition(w, h, d, out newW, out newH, out newD, out maxCount);

                if (visited[newW, newH, newD] || maxCount > 1)
                {
                    // We fall into a loop (went into already visited position)
                    finished = true;
                }
                else
                {
                    sum = sum + cuboid[newW, newH, newD];
                    w = newW;
                    h = newH;
                    d = newD;
                }
            }
            return sum;
        }

        private static void GetNextPosition(int w, int h, int d,
            out int newW, out int newH, out int newD, out int maxCount)
        {
            short maxValue = short.MinValue;
            newW = 0;
            newH = 0;
            newD = 0;
            maxCount = 0;

            short oldCurrentPositionValue = cuboid[w, h, d];
            cuboid[w, h, d] = short.MinValue;

            // Check the left / right directions
            for (int nextW = 0; nextW < width; nextW++)
            {
                short value = cuboid[nextW, h, d];
                if (value == maxValue)
                {
                    maxCount++;
                }
                if (value > maxValue)
                {
                    maxValue = value;
                    newW = nextW;
                    newH = h;
                    newD = d;
                    maxCount = 1;
                }
            }

            // Check the up / down directions
            for (int nextH = 0; nextH < height; nextH++)
            {
                short value = cuboid[w, nextH, d];
                if (value == maxValue)
                {
                    maxCount++;
                }
                if (value > maxValue)
                {
                    maxValue = value;
                    newW = w;
                    newH = nextH;
                    newD = d;
                    maxCount = 1;
                }
            }

            // Check the deeper / shallower directions
            for (int nextD = 0; nextD < depth; nextD++)
            {
                short value = cuboid[w, h, nextD];
                if (value == maxValue)
                {
                    maxCount++;
                }
                if (value > maxValue)
                {
                    maxValue = value;
                    newW = w;
                    newH = h;
                    newD = nextD;
                    maxCount = 1;
                }
            }

            cuboid[w, h, d] = oldCurrentPositionValue;
        }

        private static void ReadCuboid()
        {
            // Read the cuboid size
            string cuboidSize = Console.ReadLine();
            string[] sizes = cuboidSize.Split();
            width = int.Parse(sizes[0]);
            height = int.Parse(sizes[1]);
            depth = int.Parse(sizes[2]);

            // Read the cuboid content
            cuboid = new short[width, height, depth];
            for (int h = 0; h < height; h++)
            {
                string line = Console.ReadLine();
                string[] sequences = line.Split('|');
                for (int d = 0; d < depth; d++)
                {
                    string[] numbers = sequences[d].Split(
                        new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int w = 0; w < width; w++)
                    {
                        short cubeValue = short.Parse(numbers[w]);
                        cuboid[w, h, d] = cubeValue;
                    }
                }
            }
        }
    }
}
