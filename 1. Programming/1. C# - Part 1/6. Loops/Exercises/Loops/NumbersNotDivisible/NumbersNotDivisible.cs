using System;

class NumbersNotDivisible
{
    static void Main()
    {
        string title = new string('-', 73);
        Console.Title = "Print 1 to N";
        Console.WriteLine(title);
        Console.WriteLine("This program prints from 1 to N not divisible to 3 and 7 at the same time");
        Console.WriteLine(title + "\n\r");
        int number = 0;
        bool parseSuccess = false;
        do
        {
            Console.Write("Enter positive number: ");
            string readStr = Console.ReadLine();
            parseSuccess = int.TryParse(readStr, out number);
        }
        while (parseSuccess == false || number < 1);
        Console.WriteLine("\n\rAll the numbers from 1 to N that are not divisible to 3 and 7: ");
        for (int i = 1; i <= number; i++)
        {
            if (i % 3 == 0 && i % 7 == 0)
            {
                continue;
            }
            else
            {
                Console.WriteLine(i);
            }
        }
        Console.WriteLine();
    }
}
