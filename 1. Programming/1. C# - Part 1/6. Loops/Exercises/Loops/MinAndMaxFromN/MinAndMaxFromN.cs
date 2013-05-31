using System;

class MinAndMaxFromN
{
    static void Main()
    {
        string title = new string('-', 73);
        Console.Title = "Print 1 to N";
        Console.WriteLine(title);
        Console.WriteLine("This program prints from 1 to N not divisible to 3 and 7 at the same time");
        Console.WriteLine(title + "\n\r");
        int number = 0;
        string readStr;
        bool parseSuccess = false;
        do
        {
            Console.Write("Enter positive number: ");
            readStr = Console.ReadLine();
            parseSuccess = int.TryParse(readStr, out number);
        }
        while (parseSuccess == false || number < 1);
        int currentNumber;
        int smallestNumber = int.MaxValue;
        int BigestNumber = int.MinValue;
        parseSuccess = false;
        for (int i = 1; i <= number; i++)
        {
            do
            {
                Console.Write("Enter number {0}: ", i);
                readStr = Console.ReadLine();
                parseSuccess = int.TryParse(readStr, out currentNumber);
            }
            while (parseSuccess == false);
            if (currentNumber > BigestNumber)
            {
                BigestNumber = currentNumber;
            }
            if (currentNumber < smallestNumber)
            {
                smallestNumber = currentNumber;
            }
        }
        Console.WriteLine("\n\rSmallest number is: {0}.\n\rBiggest number is: {1}.\n\r", smallestNumber, BigestNumber);
    }
}
