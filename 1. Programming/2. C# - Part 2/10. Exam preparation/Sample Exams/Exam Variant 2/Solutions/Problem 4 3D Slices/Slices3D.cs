using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_4_3D_Slices
{
    class Slices3D
    {
        static void Main()
        {
            // Read the cuboid size
            string cuboidSize = Console.ReadLine();
            string[] sizes = cuboidSize.Split();
            int width = int.Parse(sizes[0]);
            int height = int.Parse(sizes[1]);
            int depth = int.Parse(sizes[2]);
            short[, ,] cuboid = new short[width, height, depth];

            // Read the cuboid data
            long totalSum = 0;
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
                        totalSum = totalSum + cubeValue;
                    }
                }
            }

            int splitsCount = 0;

            // Check the splits over the {height, depth} plane
            long currentSum = 0;
            for (int w = 0; w < width - 1; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    for (int d = 0; d < depth; d++)
                    {
                        currentSum = currentSum + cuboid[w, h, d];
                    }
                }
                if (currentSum * 2 == totalSum)
                {
                    splitsCount++;
                }
            }

            // Check the splits over the {width, depth} plane
            currentSum = 0;
            for (int h = 0; h < height - 1; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    for (int d = 0; d < depth; d++)
                    {
                        currentSum = currentSum + cuboid[w, h, d];
                    }
                }
                if (currentSum * 2 == totalSum)
                {
                    splitsCount++;
                }
            }

            // Check the splits over the {width, height} plane
            currentSum = 0;
            for (int d = 0; d < depth - 1; d++)
            {
                for (int w = 0; w < width; w++)
                {
                    for (int h = 0; h < height; h++)
                    {
                        currentSum = currentSum + cuboid[w, h, d];
                    }
                }
                if (currentSum * 2 == totalSum)
                {
                    splitsCount++;
                }
            }

            // Print the result
            Console.WriteLine(splitsCount);
        }
    }
}
