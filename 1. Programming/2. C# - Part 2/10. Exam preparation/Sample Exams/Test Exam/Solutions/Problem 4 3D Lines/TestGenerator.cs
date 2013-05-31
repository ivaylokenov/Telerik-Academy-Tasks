using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_4_3D_Lines
{
    public class TestGenerator
    {
        const int width = 50;
        const int height = 50;
        const int depth = 50;
        const int lettersToUse = 2;
        const int linesToInsert = 10000;
        const int noiseCount = 20;

        static char[, ,] cuboid = new char[width, height, depth];

        static void Main222()
        {
            // Randomize
            Random rnd = new Random();
            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    for (int d = 0; d < depth; d++)
                    {
                        char letter = (char)('A' + rnd.Next(lettersToUse));
                        cuboid[w, h, d] = letter;
                    }
                }
            }

            // Insert lines
            for (int i = 0; i < linesToInsert; i++)
            {
                int w = rnd.Next(width);
                int h = rnd.Next(height);
                int d = rnd.Next(depth);
                int dirW, dirH, dirD;
                do
                {
                    dirW = rnd.Next(3) - 1;
                    dirH = rnd.Next(3) - 1;
                    dirD = rnd.Next(3) - 1;
                } while (dirW == 0 && dirH == 0 && dirD == 0);
                char letter = (char)('A' + rnd.Next(lettersToUse));
                ProcessLine(w, h, d, dirW, dirH, dirD, letter);
                ProcessLine(w, h, d, -dirW, -dirH, -dirD, letter);
            }

            // Add noise
            for (int i = 0; i < noiseCount; i++)
            {
                int w = rnd.Next(width);
                int h = rnd.Next(height);
                int d = rnd.Next(depth);
                char letter = (char)('A' + rnd.Next(lettersToUse));
                cuboid[w, h, d] = letter;
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
                    }
                    if (ddd < depth - 1)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void ProcessLine(int w, int h, int d, int dirW, int dirH, int dirD, char letter)
        {
            while (IsInsideTheCuboid(w, h, d))
            {
                cuboid[w, h, d] = letter;
                w -= dirW;
                h -= dirH;
                d -= dirD;
            }
        }

        private static bool IsInsideTheCuboid(int w, int h, int d)
        {
            bool inside =
                w >= 0 && w < width &&
                h >= 0 && h < height &&
                d >= 0 && d < depth;
            return inside;
        }
    }
}
