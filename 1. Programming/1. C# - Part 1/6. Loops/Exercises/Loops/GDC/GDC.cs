using System;

class GDC
{
    static void Main()
    {
        string title = new string('-', 43);
        Console.Title = "GDC";
        Console.WriteLine(title);
        Console.WriteLine("This program calculates GDC of two integers");
        Console.WriteLine(title + "\n\r");
        int firstNumber = 0;
        int secondNumber = 0;
        string readStr;
        bool parseSuccess = false;

        do
        {
            Console.Write("Enter first number a: ");
            readStr = Console.ReadLine();
            parseSuccess = int.TryParse(readStr, out firstNumber);
        }
        while (parseSuccess == false);

        do
        {
            Console.Write("Enter second number b < a: ");
            readStr = Console.ReadLine();
            parseSuccess = int.TryParse(readStr, out secondNumber);
        }
        while (parseSuccess == false || secondNumber > firstNumber);

        int gdc;
        int remainer = 1;

        while (true)
        {
            if (secondNumber == 0)
            {
                gdc = firstNumber;
                break;
            }
            else
            {
                remainer = firstNumber % secondNumber;
                firstNumber = secondNumber;
                secondNumber = remainer;
            }
        }

        Console.WriteLine("\n\rGDC = {0}.\n\r", gdc);
    }
}
