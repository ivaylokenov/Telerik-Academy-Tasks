using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_4_3D_Lines
{
    class Lines3D
    {
        static int width, height, depth;
        static char[, ,] cuboid;

        static int lineMaxLen = 0;
        static int linesCount;
        static bool[, , , , ,] processed;

        static void Main()
        {
            // Read the cuboid size
            ReadCuboid();

            // Find the longest line in the cuboid
            FindLongestLine();

            // Print the result
            if (lineMaxLen > 1)
            {
                Console.WriteLine("{0} {1}", lineMaxLen, linesCount);
            }
            else
            {
                Console.WriteLine(-1);
            }
        }

        private static void ReadCuboid()
        {
            // Read the cuboid size
            string cuboidSize = Console.ReadLine();
            string[] sizes = cuboidSize.Split();
            width = int.Parse(sizes[0]);
            height = int.Parse(sizes[1]);
            depth = int.Parse(sizes[2]);
            cuboid = new char[width, height, depth];

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
        }

        private static void FindLongestLine()
        {
            processed = new bool[width, height, depth, 3, 3, 3];

            for (int startW = 0; startW < width; startW++)
            {
                for (int startH = 0; startH < height; startH++)
                {
                    for (int startD = 0; startD < depth; startD++)
                    {
                        ProcessLinesInAllDirections(startW, startH, startD);
                    }
                }
            }
        }

        private static void ProcessLinesInAllDirections(
            int startW, int startH, int startD)
        {
            for (int stepW = -1; stepW <= 1; stepW++)
            {
                for (int stepH = -1; stepH <= 1; stepH++)
                {
                    for (int stepD = -1; stepD <= 1; stepD++)
                    {
                        ProcessLine(startW, startH, startD, stepW, stepH, stepD);
                    }
                }
            }
        }

        private static void ProcessLine(int w, int h, int d,
            int stepW, int stepH, int stepD)
        {
            if (stepW == 0 && stepH == 0 && stepD == 0)
            {
                // Invalid direction vector {0, 0, 0}
                return;
            }

            if (IsProcessed(w, h, d, stepW, stepH, stepD))
            {
                // The given start location and irection is already processed
                return;
            }

            char color = cuboid[w, h, d];
            int len = 0;

            // Find the end of the line
            while (IsInsideTheCuboid(w + stepW, h + stepH, d + stepD) &&
                cuboid[w + stepW, h + stepH, d + stepD] == color)
            {
                w += stepW;
                h += stepH;
                d += stepD;
            }

            // Scan the line back from the end to the start
            while (IsInsideTheCuboid(w, h, d) && cuboid[w, h, d] == color)
            {
                MarkAsProcessed(w, h, d, stepW, stepH, stepD);
                len++;
                if (len == lineMaxLen)
                {
                    linesCount++;
                }
                else if (len > lineMaxLen)
                {
                    lineMaxLen = len;
                    linesCount = 1;
                }
                w -= stepW;
                h -= stepH;
                d -= stepD;
            }
        }

        private static bool IsProcessed(
            int w, int h, int d, int stepW, int stepH, int stepD)
        {
            bool isProcessed =
                processed[w, h, d, stepW + 1, stepH + 1, stepD + 1] ||
                processed[w, h, d, -stepW + 1, -stepH + 1, -stepD + 1];
            return isProcessed;
        }

        private static void MarkAsProcessed(
            int w, int h, int d, int stepW, int stepH, int stepD)
        {
            processed[w, h, d, stepW + 1, stepH + 1, stepD + 1] = true;
            processed[w, h, d, -stepW + 1, -stepH + 1, -stepD + 1] = true;
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
