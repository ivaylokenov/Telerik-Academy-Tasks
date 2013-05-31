using System;

class DescendingOrder
{
    static void Main()
    {
        Console.Title = "Descending order";
        string title = new string('-', 54);
        Console.WriteLine(title);
        Console.WriteLine("This program sorts 3 real integers in descending order");
        Console.WriteLine(title);
        decimal[] numbers = new decimal[3];
        Console.Write("\n\rEnter three real numbers: ");
        string readStr = Console.ReadLine();
        string[] separatedRead = readStr.Split(' ');
        while (separatedRead.Length != 3)
        {
            Console.WriteLine("Your input is not valid. Try again: ");
            readStr = Console.ReadLine();
            separatedRead = readStr.Split(' ');
        }
        for (int i = 0; i < separatedRead.Length; i++)
        {
            bool parseSuccess = decimal.TryParse(separatedRead[i], out numbers[i]);
            while (parseSuccess == false)
            {
                Console.WriteLine("Your input is not valid. Try again: ");
                readStr = Console.ReadLine();
                separatedRead = readStr.Split(' ');
                parseSuccess = decimal.TryParse(separatedRead[i], out numbers[i]);
                i = 0;
            }
        }
        decimal tempNumber;
        if (numbers[0] < numbers[1])
        {
            tempNumber = numbers[0];
            numbers[0] = numbers[1];
            numbers[1] = tempNumber;
            if (numbers[0] < numbers[2])
            {
                tempNumber = numbers[0];
                numbers[0] = numbers[2];
                numbers[2] = tempNumber;
            }
            if (numbers[1] < numbers[2])
            {
                tempNumber = numbers[1];
                numbers[1] = numbers[2];
                numbers[2] = tempNumber;
            }
        }
        Console.WriteLine("\n\rSorted numbers in descending numbers: ");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("{0} ", numbers[i]);
        }
        Console.WriteLine("\n\r");
    }
}
