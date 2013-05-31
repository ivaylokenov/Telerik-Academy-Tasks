using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Slices
{
    static void Main()
    {
        //BGCoder: 100/100

        string[] dimensions = Console.ReadLine().Split(' ');

        int W = int.Parse(dimensions[0]);
        int H = int.Parse(dimensions[1]);
        int D = int.Parse(dimensions[2]);

        int[, ,] cuboid = new int[W, H, D];

        long sum = 0;

        for (int height = 0; height < H; height++)
        {
            string[] line = Console.ReadLine().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            for (int depth = 0; depth < D; depth++)
            {
                string currentDepth = line[depth].Trim();
                string[] widths = currentDepth.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int width = 0; width < W; width++)
                {
                    cuboid[width, height, depth] = int.Parse(widths[width]);
                    sum += cuboid[width, height, depth];
                }
            }
        }

        if (sum % 2 == 1)
        {
            Console.WriteLine(0);
        }

        int result = 0;
        int currentSum = 0;

        for (int width = 0; width < W - 1; width++)
        {
            for (int height = 0; height < H; height++)
            {
                for (int depth = 0; depth < D; depth++)
                {
                    currentSum += cuboid[width, height, depth];
                }
            }

            if (currentSum == sum / 2)
            {
                result++;
            }
        }

        currentSum = 0;

        for (int height = 0; height < H - 1; height++)
        {
            for (int width = 0; width < W; width++)
            {
                for (int depth = 0; depth < D; depth++)
                {
                    currentSum += cuboid[width, height, depth];
                }
            }

            if (currentSum == sum / 2)
            {
                result++;
            }
        }

        currentSum = 0;

        for (int depth = 0; depth < D - 1; depth++)
        {
            for (int width = 0; width < W; width++)
            {
                for (int height = 0; height < H; height++)
                {
                    currentSum += cuboid[width, height, depth];
                }
            }

            if (currentSum == sum / 2)
            {
                result++;
            }
        }

        Console.WriteLine(result);
    }
}
