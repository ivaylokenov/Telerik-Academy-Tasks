using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_4_3D_Max_Walk
{
    public class TestGenerator
    {
        static void Main2()
        {
            int width = 99;
            int height = 99;
            int depth = 99;
            int[, ,] cuboid = new int[width, height, depth];

            for (int ww = 0; ww < width; ww++)
            {
                for (int hh = 0; hh < height; hh++)
                {
                    for (int dd = 0; dd < depth; dd++)
                    {
                        cuboid[ww, hh, dd] = 0;
                    }
                }
            }

            // Generate
            Random rnd = new Random();
            int value = 1;
            int w = width / 2;
            int h = height / 2;
            int d = depth / 2;
            while (true)
            {
                for (int nextW = 0; nextW < width; nextW++)
                {
                    if (cuboid[nextW, h, d] == 0)
                    {
                        cuboid[nextW, h, d] = -1 - nextW;
                    }
                }
                for (int nextH = 0; nextH < height; nextH++)
                {
                    if (cuboid[w, nextH, d] == 0)
                    {
                        cuboid[w, nextH, d] = -1 - 120 - nextH;
                    }
                }
                for (int nextD = 0; nextD < depth; nextD++)
                {
                    if (cuboid[w, h, nextD] == 0)
                    {
                        cuboid[w, h, nextD] = -1 - 250 - nextD;
                    }
                }
                cuboid[w, h, d] = value;
                value++;
                if (value > 200)
                {
                    break;
                }

                int r = rnd.Next(3);
                if (r == 0)
                {
                    w = rnd.Next(width);
                }
                if (r == 1)
                {
                    h = rnd.Next(height);
                }
                if (r == 2)
                {
                    d = rnd.Next(depth);
                }
            }

            // Print
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
