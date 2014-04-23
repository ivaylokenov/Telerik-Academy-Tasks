using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_4_3D_Slices
{
    public class TestGenerator
    {
        static void Main2()
        {
            int width = 100;
            int height = 100;
            int depth = 100;
            int[, ,] cuboid = new int[width, height, depth];

            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    for (int d = 0; d < depth; d++)
                    {
                        cuboid[w, h, d] = 1000;
                    }
                }
            }


            // Generate
            Random rnd = new Random();
            for (int counter = 0; counter < 3; counter++)
            {
                int w = rnd.Next(width);
                int h = rnd.Next(height);
                int d = rnd.Next(depth);
                int value = rnd.Next(1001);

                int r = rnd.Next(4);
                if (r == 0)
                {
                    cuboid[w, h, d] = -value;
                    cuboid[width - 1 - w, h, d] = value;
                }
                if (r == 1)
                {
                    cuboid[w, h, d] = value;
                    cuboid[w, height - 1 - h, d] = -value;
                }
                if (r == 2)
                {
                    cuboid[w, h, d] = value;
                    cuboid[w, h, depth - 1 - d] = -value;
                }
            }

            // Print
            Console.WriteLine("{0} {1} {2}", width, height, depth);
            for (int h = 0; h < height; h++)
            {
                for (int d = 0; d < depth; d++)
                {
                    for (int w = 0; w < width; w++)
                    {
                        Console.Write(cuboid[w, h, d]);
                        if (w < width - 1)
                        {
                            Console.Write(' ');
                        }
                    }
                    if (d < depth - 1)
                    {
                        Console.Write(" | ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
