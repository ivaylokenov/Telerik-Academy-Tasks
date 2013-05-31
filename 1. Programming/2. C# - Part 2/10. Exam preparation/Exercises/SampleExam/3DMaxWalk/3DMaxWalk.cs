using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MaxWalk
{
    //BGCoder: 100/100

    static readonly string[] firstLine = Console.ReadLine().Split(' ');
    static int W = int.Parse(firstLine[0]);
    static int H = int.Parse(firstLine[1]);
    static int D = int.Parse(firstLine[2]);
    static readonly bool[, ,] visitedCuboid = new bool[W, H, D];
    static readonly int[] totalMaxCoordinations = new int[3];

    static string checkMax(int[,,] cuboid, int width, int height, int depth)
    {
        int defaultWidth = width;
        int defaultHeight = height;
        int defaultDepth = depth;

        int totalMax = checkTotalMax(cuboid, defaultWidth, defaultHeight, defaultDepth);

        int maxCount = int.MinValue;
        int left = int.MinValue;
        width = defaultWidth;
        width -= 1;
        int positionLeft = 0;
        while (width >= 0)
        {
            if (cuboid[width, defaultHeight, defaultDepth] == totalMax && (width != totalMaxCoordinations[0] || defaultHeight != totalMaxCoordinations[1] || defaultDepth != totalMaxCoordinations[2]))
            {
                return "break";
            }
            if (cuboid[width, defaultHeight, defaultDepth] > maxCount)
            {
                maxCount = cuboid[width, defaultHeight, defaultDepth];
                positionLeft = width;
            }
            width -= 1;
        }
        left = maxCount;

        maxCount = int.MinValue;
        int right = int.MinValue;
        width = defaultWidth;
        width += 1;
        int positionRight = 0;
        while (width < W)
        {
            if (cuboid[width, defaultHeight, defaultDepth] == totalMax && (width != totalMaxCoordinations[0] || defaultHeight != totalMaxCoordinations[1] || defaultDepth != totalMaxCoordinations[2]))
            {
                return "break";
            }

            if (cuboid[width, defaultHeight, defaultDepth] > maxCount)
            {
                maxCount = cuboid[width, defaultHeight, defaultDepth];
                positionRight = width;
            }
            width += 1;
        }
        right = maxCount;

        maxCount = int.MinValue;
        int down = int.MinValue;
        height = defaultHeight;
        height -= 1;
        int positionDown = 0;
        while (height >= 0)
        {
            if (cuboid[defaultWidth, height, defaultDepth] == totalMax && (defaultWidth != totalMaxCoordinations[0] || height != totalMaxCoordinations[1] || defaultDepth != totalMaxCoordinations[2]))
            {
                return "break";
            }

            if (cuboid[defaultWidth, height, defaultDepth] > maxCount)
            {
                maxCount = cuboid[defaultWidth, height, defaultDepth];
                positionDown = height;
            }
            height -= 1;
        }
        down = maxCount;

        maxCount = int.MinValue;
        int up = int.MinValue;
        height = defaultHeight;
        height += 1;
        int positionUp = 0;
        while (height < H)
        {
            if (cuboid[defaultWidth, height, defaultDepth] == totalMax && (defaultWidth != totalMaxCoordinations[0] || height != totalMaxCoordinations[1] || defaultDepth != totalMaxCoordinations[2]))
            {
                return "break";
            }

            if (cuboid[defaultWidth, height, defaultDepth] > maxCount)
            {
                maxCount = cuboid[defaultWidth, height, defaultDepth];
                positionUp = height;
            }
            height += 1;
        }
        up = maxCount;

        maxCount = int.MinValue;
        int shallow = int.MinValue;
        depth = defaultDepth;
        depth -= 1;
        int positionShallow = 0;
        while (depth >= 0)
        {
            if (cuboid[defaultWidth, defaultHeight, depth] == totalMax && (defaultWidth != totalMaxCoordinations[0] || defaultHeight != totalMaxCoordinations[1] || depth != totalMaxCoordinations[2]))
            {
                return "break";
            }

            if (cuboid[defaultWidth, defaultHeight, depth] > maxCount)
            {
                maxCount = cuboid[defaultWidth, defaultHeight, depth];
                positionShallow = depth;
            }
            depth -= 1;
        }
        shallow = maxCount;

        maxCount = int.MinValue;
        int deep = int.MinValue;
        depth = defaultDepth;
        depth += 1;
        int positionDeep = 0;
        while (depth < D)
        {
            if (cuboid[defaultWidth, defaultHeight, depth] == totalMax && (defaultWidth != totalMaxCoordinations[0] || defaultHeight != totalMaxCoordinations[1] || depth != totalMaxCoordinations[2]))
            {
                return "break";
            }

            if (cuboid[defaultWidth, defaultHeight, depth] > maxCount)
            {
                maxCount = cuboid[defaultWidth, defaultHeight, depth];
                positionDeep = depth;
            }
            depth += 1;
        }
        deep = maxCount;

        if (left > right && left > down && left > up && left > shallow && left > deep)
        {
            if (visitedCuboid[positionLeft, defaultHeight, defaultDepth])
            {
                return "break";
            }
            return "left";
        }
        if (right > left && right > down && right > up && right > shallow && right > deep)
        {
            if (visitedCuboid[positionRight, defaultHeight, defaultDepth])
            {
                return "break";
            }
            return "right";
        }
        if (up > left && up > right && up > down && up > shallow && up > deep)
        {
            if (visitedCuboid[defaultWidth, positionUp, defaultDepth])
            {
                return "break";
            }
            return "up";
        }
        if (down > left && down > right && down > up && down > shallow && down > deep)
        {
            if (visitedCuboid[defaultWidth, positionDown, defaultDepth])
            {
                return "break";
            }
            return "down";
        }
        if (shallow > left && shallow > right && shallow > up && shallow > down && shallow > deep)
        {
            if (visitedCuboid[defaultWidth, defaultHeight, positionShallow])
            {
                return "break";
            }
            return "shallow";
        }
        if (deep > left && deep > right && deep > up && deep > down && deep > shallow)
        {
            if (visitedCuboid[defaultWidth, defaultHeight, positionDeep])
            {
                return "break";
            }
            return "deep";
        }

        return "break";
    }

    static int checkTotalMax(int[, ,] cuboid, int width, int height, int depth)
    {
        int totalMax = int.MinValue;
        int defaultWidth = width;
        int defaultHeight = height;
        int defaultDepth = depth;

        int maxCount = int.MinValue;
        width = defaultWidth;
        width -= 1;
        while (width >= 0)
        {
            if (cuboid[width, defaultHeight, defaultDepth] > totalMax)
            {
                totalMax = cuboid[width, defaultHeight, defaultDepth];
                totalMaxCoordinations[0] = width;
                totalMaxCoordinations[1] = defaultHeight;
                totalMaxCoordinations[2] = defaultDepth;
            }
            width -= 1;
        }

        maxCount = int.MinValue;
        width = defaultWidth;
        width += 1;
        while (width < W)
        {
            if (cuboid[width, defaultHeight, defaultDepth] > totalMax)
            {
                totalMax = cuboid[width, defaultHeight, defaultDepth];
                totalMaxCoordinations[0] = width;
                totalMaxCoordinations[1] = defaultHeight;
                totalMaxCoordinations[2] = defaultDepth;
            }
            width += 1;
        }

        maxCount = int.MinValue;
        height = defaultHeight;
        height -= 1;
        while (height >= 0)
        {
            if (cuboid[defaultWidth, height, defaultDepth] > totalMax)
            {
                totalMax = cuboid[defaultWidth, height, defaultDepth];
                totalMaxCoordinations[0] = defaultWidth;
                totalMaxCoordinations[1] = height;
                totalMaxCoordinations[2] = defaultDepth;
            }
            height -= 1;
        }

        maxCount = int.MinValue;
        height = defaultHeight;
        height += 1;
        while (height < H)
        {
            if (cuboid[defaultWidth, height, defaultDepth] > totalMax)
            {
                totalMax = cuboid[defaultWidth, height, defaultDepth];
                totalMaxCoordinations[0] = defaultWidth;
                totalMaxCoordinations[1] = height;
                totalMaxCoordinations[2] = defaultDepth;
            }
            height += 1;
        }

        maxCount = int.MinValue;
        depth = defaultDepth;
        depth -= 1;
        while (depth >= 0)
        {
            if (cuboid[defaultWidth, defaultHeight, depth] > totalMax)
            {
                totalMax = cuboid[defaultWidth, defaultHeight, depth];
                totalMaxCoordinations[0] = defaultWidth;
                totalMaxCoordinations[1] = defaultHeight;
                totalMaxCoordinations[2] = depth;
            }
            depth -= 1;
        }

        maxCount = int.MinValue;
        depth = defaultDepth;
        depth += 1;
        while (depth < D)
        {
            if (cuboid[defaultWidth, defaultHeight, depth] > totalMax)
            {
                totalMax = cuboid[defaultWidth, defaultHeight, depth];
                totalMaxCoordinations[0] = defaultWidth;
                totalMaxCoordinations[1] = defaultHeight;
                totalMaxCoordinations[2] = depth;
            }
            depth += 1;
        }

        return totalMax;
    }

    static void Main()
    {
        int[, ,] cuboid = new int[W, H, D];

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
                     cuboid[k, i, j] = int.Parse(currentWidth[k]);
                }
            }
        }

        int currentWidthNumber = W / 2;
        int currentHeightNumber = H / 2;
        int currentDepthNumber = D / 2;
        int currentNumber = cuboid[currentWidthNumber, currentHeightNumber, currentDepthNumber];
        long sum = currentNumber;

        while (true)
        {
            string direction = checkMax(cuboid, currentWidthNumber, currentHeightNumber, currentDepthNumber);
            visitedCuboid[currentWidthNumber, currentHeightNumber, currentDepthNumber] = true;

            if (direction == "left")
            {
                int widthCheck = currentWidthNumber;
                widthCheck -= 1;
                int maxNumber = int.MinValue;

                while (widthCheck >= 0)
                {
                    if (cuboid[widthCheck, currentHeightNumber, currentDepthNumber] > maxNumber)
                    {
                        maxNumber = cuboid[widthCheck, currentHeightNumber, currentDepthNumber];
                        currentWidthNumber = widthCheck;
                    }
                    widthCheck -= 1;
                }

                currentNumber = cuboid[currentWidthNumber, currentHeightNumber, currentDepthNumber];
                sum += currentNumber;
            }
            else if (direction == "right")
            {
                int widthCheck = currentWidthNumber;
                widthCheck += 1;
                int maxNumber = int.MinValue;

                while (widthCheck < W)
                {
                    if (cuboid[widthCheck, currentHeightNumber, currentDepthNumber] > maxNumber)
                    {
                        maxNumber = cuboid[widthCheck, currentHeightNumber, currentDepthNumber];
                        currentWidthNumber = widthCheck;
                    }
                    widthCheck += 1;
                }

                currentNumber = cuboid[currentWidthNumber, currentHeightNumber, currentDepthNumber];
                sum += currentNumber;
            }
            else if (direction == "down")
            {
                int heightCheck = currentHeightNumber;
                heightCheck -= 1;
                int maxNumber = int.MinValue;

                while (heightCheck >= 0)
                {
                    if (cuboid[currentWidthNumber, heightCheck, currentDepthNumber] > maxNumber)
                    {
                        maxNumber = cuboid[currentWidthNumber, heightCheck, currentDepthNumber];
                        currentHeightNumber = heightCheck;
                    }
                    heightCheck -= 1;
                }

                currentNumber = cuboid[currentWidthNumber, currentHeightNumber, currentDepthNumber];
                sum += currentNumber;
            }
            else if (direction == "up")
            {
                int heightCheck = currentHeightNumber;
                heightCheck += 1;
                int maxNumber = int.MinValue;

                while (heightCheck < H)
                {
                    if (cuboid[currentWidthNumber, heightCheck, currentDepthNumber] > maxNumber)
                    {
                        maxNumber = cuboid[currentWidthNumber, heightCheck, currentDepthNumber];
                        currentHeightNumber = heightCheck;
                    }
                    heightCheck += 1;
                }

                currentNumber = cuboid[currentWidthNumber, currentHeightNumber, currentDepthNumber];
                sum += currentNumber;
            }
            else if (direction == "shallow")
            {
                int depthCheck = currentDepthNumber;
                depthCheck -= 1;
                int maxNumber = int.MinValue;

                while (depthCheck >= 0)
                {
                    if (cuboid[currentWidthNumber, currentHeightNumber, depthCheck] > maxNumber)
                    {
                        maxNumber = cuboid[currentWidthNumber, currentHeightNumber, depthCheck];
                        currentDepthNumber = depthCheck;
                    }
                    depthCheck -= 1;
                }

                currentNumber = cuboid[currentWidthNumber, currentHeightNumber, currentDepthNumber];
                sum += currentNumber;
            }
            else if (direction == "deep")
            {
                int depthCheck = currentDepthNumber;
                depthCheck += 1;
                int maxNumber = int.MinValue;

                while (depthCheck < D)
                {
                    if (cuboid[currentWidthNumber, currentHeightNumber, depthCheck] > maxNumber)
                    {
                        maxNumber = cuboid[currentWidthNumber, currentHeightNumber, depthCheck];
                        currentDepthNumber = depthCheck;
                    }
                    depthCheck += 1;
                }

                currentNumber = cuboid[currentWidthNumber, currentHeightNumber, currentDepthNumber];
                sum += currentNumber;
            }
            else if (direction == "break")
            {
                break;
            }
        }
        Console.WriteLine(sum);
    }
}
