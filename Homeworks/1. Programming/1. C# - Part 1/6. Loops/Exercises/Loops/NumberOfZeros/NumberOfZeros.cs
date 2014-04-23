using System;

class NumberOfZeros
{
    static void Main()
    {
        string title = new string('-', 52);
        Console.Title = "Number of zeros";
        Console.WriteLine(title);
        Console.WriteLine("This program prints the number of 0 at the end of N!");
        Console.WriteLine(title + "\n\r");
        int number = 0;
        string readStr;
        bool parseSuccess = false;
        do
        {
            Console.Write("Enter positive N: ");
            readStr = Console.ReadLine();
            parseSuccess = int.TryParse(readStr, out number);
        }
        while (parseSuccess == false || number < 1);

        int numberOfZeros = 0;
        int division = 1;
        int counter = 5;

        while (division != 0)
        {
            division = number / counter;
            numberOfZeros += division;
            counter *= 5;
        }

        Console.WriteLine("\n\rNumber of 0 at the end of {0}! is: {1}.\n\r", number, numberOfZeros);
    }
}
