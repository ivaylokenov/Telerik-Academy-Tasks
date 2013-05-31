using System;

class NMatrix
{
    static void Main()
    {
        string title = new string('-', 41);
        Console.Title = "Matrix";
        Console.WriteLine(title);
        Console.WriteLine("This program prints matrix depending on N");
        Console.WriteLine(title + "\n\r");
        int number = 0;
        string readStr;
        bool parseSuccess = false;
        do
        {
            Console.Write("Enter N between 2 and 20: ");
            readStr = Console.ReadLine();
            parseSuccess = int.TryParse(readStr, out number);
        }
        while (parseSuccess == false || number < 2 || number > 20);

        Console.WriteLine();

        for (int row = 1; row <= number; row++)
        {
            for (int col = row; col < number + row; col++)
            {
                Console.Write(col);
                Console.Write(" ");
            }
            Console.WriteLine("\n\r");
        }
    }
}
