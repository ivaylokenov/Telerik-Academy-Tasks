using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_4_3D_Stars
{
    class Stars3D
    {
        static void Main()
        {
            // Read the cuboid size
            string cuboidSize = Console.ReadLine();
            string[] sizes = cuboidSize.Split();
            int width = int.Parse(sizes[0]);
            int height = int.Parse(sizes[1]);
            int depth = int.Parse(sizes[2]);
            char[, ,] cuboid = new char[width, height, depth];

            // Read the cuboid data
            for (int h = 0; h < height; h++)
            {
                string line = Console.ReadLine();
                string[] letters = line.Split();
                for (int d = 0; d < depth; d++)
                {
                    for (int w = 0; w < width; w++)
                    {
                        cuboid[w, h, d] = letters[d][w];
                    }
                }
            }

            // Find all 3D stars in the cuboid
            int starsCount = 0;
            char[] starsCountsByLetter = new char['Z' - 'A' + 1];
            for (int w = 1; w < width - 1; w++)
            {
                for (int h = 1; h < height - 1; h++)
                {
                    for (int d = 1; d < depth - 1; d++)
                    {
                        char color = cuboid[w, h, d];
                        bool sameColor =
                            (cuboid[w + 1, h, d] == color) &&
                            (cuboid[w - 1, h, d] == color) &&
                            (cuboid[w, h + 1, d] == color) &&
                            (cuboid[w, h - 1, d] == color) &&
                            (cuboid[w, h, d + 1] == color) &&
                            (cuboid[w, h, d - 1] == color);
                        if (sameColor)
                        {
                            starsCount++;
                            starsCountsByLetter[color - 'A']++;
                        }
                    }
                }
            }

            // Print the result
            Console.WriteLine(starsCount);
            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                int count = starsCountsByLetter[letter - 'A'];
                if (count > 0)
                {
                    Console.WriteLine("{0} {1}", letter, count);
                }
            }
        }
    }
}
