using System;
using System.Collections.Generic;
using System.Text;

class Liquid
{
    //BGCoder: 0/100

    static readonly string[] firstLine = Console.ReadLine().Split(' ');
    static int W = int.Parse(firstLine[0]);
    static int H = int.Parse(firstLine[1]);
    static int D = int.Parse(firstLine[2]);

    static void Main()
    {
        int[, ,] capacity = new int[W, H, D];
        int[, ,] liquid = new int[W, H, D];
        int[, ,] leftCapacity = new int[W, H, D];

        for (int i = 0; i < H; i++)
        {
            string height = Console.ReadLine();
            string[] depth = height.Split('|');

            for (int j = 0; j < D; j++)
            {
                string currentDepth = depth[j];
                currentDepth = currentDepth.Trim();

                string[] currentWidth = currentDepth.Split(' ');

                for (int k = 0; k < W; k++)
                {
                    capacity[k, i, j] = int.Parse(currentWidth[k]);
                }
            }
        }

        for (int i = 0; i < W; i++)
        {
            for (int j = 0; j < H; j++)
            {
                liquid[i, j, 0] = capacity[i, j, 0];
            }
        }

        for (int i = 1; i < D; i++)
        {
            for (int j = 0; j < W; j++)
            {
                for (int k = 0; k < H; k++)
                {
                    int currentLiquid = liquid[j, k, i - 1];

                    if (currentLiquid <= capacity[j, k, i])
                    {
                        liquid[j, k, i] = currentLiquid;
                        leftCapacity[j, k, i] = capacity[j, k, i] - currentLiquid;
                    }
                    else
                    {
                        liquid[j, k, i] = capacity[j, k, i];
                    }
                }
            }
        }

        if (D > 1)
        {
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    leftCapacity[i, j, 0] = capacity[i, j, 0] - liquid[i, j, 1];
                }
            }
        }

        for (int i = 0; i < D - 1; i++)
        {
            for (int j = 0; j < W; j++)
            {
                for (int k = 0; k < H; k++)
                {
                    
                }
            }
        }

        for (int i = 0; i < W; i++)
        {
            for (int j = 0; j < H; j++)
            {
                Console.Write(liquid[i, j, 0]);
            }
            Console.WriteLine();
        }
    }
}
