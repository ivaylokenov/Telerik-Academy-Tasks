using System;

class Lines
{
    static void Main()
    {
        int[,] grid = new int[8, 8];
        int number;
        string readStr;
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            readStr = Console.ReadLine();
            number = int.Parse(readStr);
            for (int j = grid.GetLength(1) - 1; j >= 0; j--)
            {
                grid[i, j] = number % 2;
                number /= 2;
            }
        }

        //horizontal lines
        int currentBit = 0;
        int lastBit = 1;
        int lenghtOfLine = 0;
        int maxLenghtOfLine = int.MinValue;
        int numberOfLongestLines = 0;

        //vertical lines
        for (int j = 0; j < 8; j++)
        {
            for (int i = 0; i < 8; i++)
            {
                currentBit = grid[i, j];

                if (lastBit == 0 && currentBit == 1) //start of line
                {
                    lenghtOfLine++;
                }
                else if (lastBit == 1 && currentBit == 1) //middle of line
                {
                    lenghtOfLine++;
                }
                else if (lastBit == 1 && currentBit == 0) //end of line
                {
                    if (lenghtOfLine == maxLenghtOfLine)
                    {
                        numberOfLongestLines++;
                    }
                    if (lenghtOfLine > maxLenghtOfLine)
                    {
                        maxLenghtOfLine = lenghtOfLine;
                        numberOfLongestLines = 1;
                    }
                    lenghtOfLine = 0;
                }

                if (i == 7) //possible end of line at last bit
                {
                    if (lenghtOfLine == maxLenghtOfLine)
                    {
                        numberOfLongestLines++;
                    }
                    if (lenghtOfLine > maxLenghtOfLine)
                    {
                        maxLenghtOfLine = lenghtOfLine;
                        numberOfLongestLines = 1;
                    }
                    lenghtOfLine = 0;
                }
                lastBit = currentBit;
            }
            lastBit = 1;
        }

        ////horizontal lines
        currentBit = 0;
        lastBit = 1;
        lenghtOfLine = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                currentBit = grid[i, j];

                if (lastBit == 0 && currentBit == 1) //start of line
                {
                    lenghtOfLine++;
                }
                else if (lastBit == 1 && currentBit == 1) //middle of line
                {
                    lenghtOfLine++;
                }
                else if (lastBit == 1 && currentBit == 0) //end of line
                {
                    if (lenghtOfLine == maxLenghtOfLine)
                    {
                        numberOfLongestLines++;
                    }
                    if (lenghtOfLine > maxLenghtOfLine)
                    {
                        maxLenghtOfLine = lenghtOfLine;
                        numberOfLongestLines = 1;
                    }
                    lenghtOfLine = 0;
                }

                if (j == 7) //possible end of line at last bit
                {
                    if (lenghtOfLine == maxLenghtOfLine)
                    {
                        numberOfLongestLines++;
                    }
                    if (lenghtOfLine > maxLenghtOfLine)
                    {
                        maxLenghtOfLine = lenghtOfLine;
                        numberOfLongestLines = 1;
                    }
                    lenghtOfLine = 0;
                }
                lastBit = currentBit;
            }
            lastBit = 1;
        }

        Console.WriteLine(maxLenghtOfLine);
        if (maxLenghtOfLine != 0)
        {
            if (maxLenghtOfLine == 1)
            {
                Console.WriteLine(numberOfLongestLines/2);
            }
            else
            {
                Console.WriteLine(numberOfLongestLines);
            }
        }
        else
        {
            Console.WriteLine(0);
        }
    }
}
