using System;

class Print1ToN
{
    static void Main(string[] args)
    {
        string title = new string('-', 47);
        Console.Title = "Print 1 to N";
        Console.WriteLine(title);
        Console.WriteLine("This program prints all the numbers from 1 to N");
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
        Console.WriteLine("\n\rAll the numbers from 1 to N: ");
        int counter = 1;
        do
        {
            Console.WriteLine(counter);
            counter++;
        }
        while (counter <= number);
        Console.WriteLine();
    }
}
