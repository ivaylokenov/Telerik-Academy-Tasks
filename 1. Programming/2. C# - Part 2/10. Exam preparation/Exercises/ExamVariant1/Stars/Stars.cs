using System;
using System.Collections.Generic;
using System.Text;

class Stars
{
    static void Main()
    {
        //BGCoder: 80/100

        string[] dimensions = Console.ReadLine().Split(' ');

        char[, ,] cuboid = new char[int.Parse(dimensions[0]), int.Parse(dimensions[1]), int.Parse(dimensions[2])];

        for (int i = 0; i < int.Parse(dimensions[1]); i++)
        {
            string input = Console.ReadLine();

            for (int j = 0; j < int.Parse(dimensions[2]); j++)
            {
                string[] depths = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int k = 0; k < int.Parse(dimensions[0]); k++)
                {
                    string currentColorSequence = depths[j];
                    cuboid[k, i, j] = currentColorSequence[k];
                }
            }
        }

        int stars = 0;
        int index = 0;

        int[] colors = new int[26];

        for (int i = 1; i < int.Parse(dimensions[0]) - 1; i++)
        {
            for (int j = 1; j < int.Parse(dimensions[1]) - 1; j++)
            {
                for (int k = 1; k < int.Parse(dimensions[2]) - 1; k++)
                {
                    char currentChar = cuboid[i, j, k];

                    bool down = false;
                    bool up = false;
                    bool right = false;
                    bool left = false;
                    bool deep = false;
                    bool shallow = false;

                    /*
                    if (currentChar == cuboid[i - 1, j, k] && currentChar == cuboid[i + 1, j, k] && currentChar == cuboid[i, j - 1, k] && currentChar == cuboid[i, j + 1, k] && currentChar == cuboid[i, j, k - 1] && currentChar == cuboid[i, j, k + 1])
                    {
                        stars++;
                        colors[currentChar - 65]++;
                    }
                     */

                    if (currentChar == cuboid[i - 1, j, k])
                    {
                        down = true;
                    }
                    else
                    {
                        continue;
                    }

                    if (currentChar == cuboid[i + 1, j, k])
                    {
                        up = true;
                    }
                    else
                    {
                        continue;
                    }

                    if (currentChar == cuboid[i, j - 1, k])
                    {
                        right = true;
                    }
                    else
                    {
                        continue;
                    }

                    if (currentChar == cuboid[i, j + 1, k])
                    {
                        left = true;
                    }
                    else
                    {
                        continue;
                    }

                    if (currentChar == cuboid[i, j, k - 1])
                    {
                        deep = true;
                    }
                    else
                    {
                        continue;
                    }

                    if (currentChar == cuboid[i, j, k + 1])
                    {
                        shallow = true;
                    }
                    else
                    {
                        continue;
                    }

                    if (up && down && left && right && deep && shallow)
                    {
                        stars++;
                        colors[currentChar - 65]++;
                    }
                }
            }
        }

        Console.WriteLine(stars);

        for (int i = 0; i < colors.Length; i++)
        {
            if (colors[i] != 0)
            {
                Console.Write((char)(i + 65));
                Console.Write(" ");
                Console.Write(colors[i]);
                Console.WriteLine();
            }
        }
    }
}
