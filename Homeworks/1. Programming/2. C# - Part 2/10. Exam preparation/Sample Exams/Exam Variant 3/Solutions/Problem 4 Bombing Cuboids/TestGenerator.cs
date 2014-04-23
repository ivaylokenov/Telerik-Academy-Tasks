using System;
namespace Problem_4_Bombing_Cuboids
{
    public class TestGenerator
    {
        static int width = 89;
        static int height = 99;
        static int depth = 93;
        //static char[, ,] cuboid;

        static void Main2()
        {
            Random rnd = new Random();

            Console.WriteLine("{0} {1} {2}", width, height, depth);
            for (int h = 0; h < height; h++)
            {
                for (int d = 0; d < depth; d++)
                {
                    for (int w = 0; w < width; w++)
                    {
                        char letter = (char)('A' + rnd.Next(25));
                        Console.Write(letter);
                    }
                    if (d < depth - 1)
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }

            int n = rnd.Next(5, 20);
            Console.WriteLine(n);
            for (int i = 0; i < n; i++)
            {
                int w = rnd.Next(width);
                int h = rnd.Next(height);
                int d = rnd.Next(depth);
                int p = 1 + rnd.Next(Math.Min(width, Math.Min(height, depth)) / 5);
                Console.WriteLine("{0} {1} {2} {3}", w, h, d, p);
            }

        }
    }
}