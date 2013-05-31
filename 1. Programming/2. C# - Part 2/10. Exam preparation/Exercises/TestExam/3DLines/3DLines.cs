using System;
using System.Collections.Generic;
using System.Text;

class Lines
{
    static void Main()
    {
        //BGCoder: 0/100

        string[] dimensions = Console.ReadLine().Split(' ');

        char[, ,] cuboid = new char[int.Parse(dimensions[0]), int.Parse(dimensions[1]), int.Parse(dimensions[2])];

        for (int i = 0; i < int.Parse(dimensions[1]); i++)
        {
            string input = Console.ReadLine();

            for (int j = 0; j < int.Parse(dimensions[2]); j++)
            {
                string[] depths = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                for (int k = 0; k < int.Parse(dimensions[0]); k++)
                {
                    string currentColorSequence = depths[j];
                    cuboid[i, k, j] = currentColorSequence[k];
                }
            }
        }

        int W = int.Parse(Console.ReadLine());
        int H = int.Parse(Console.ReadLine());
        int D = int.Parse(Console.ReadLine());
        int max = 0;

        if (W >= H && W >= D)
        {
            max = W;
        }
        else if (H >= W && H >= D)
        {
            max = H;
        } 
        else if (D >= W && D >= H)
        {
            max = D;
        }

        int[] numberOfLines = new int[max];

        //Straight X, Y, Z

        char lastSaved = cuboid[0, 0, 0];

        for (int i = 0; i < W; i++)
        {
            for (int j = 0; j < H; j++)
            {
                for (int k = 0; k < D; k++)
                {
                    char currentColor = cuboid[i, j, k];

                    //Straight X


                }
            }
        }
    }
}
