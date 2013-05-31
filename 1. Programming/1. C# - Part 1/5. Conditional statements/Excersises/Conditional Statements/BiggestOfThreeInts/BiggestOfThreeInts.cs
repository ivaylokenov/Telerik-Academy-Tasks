using System;

class BiggestOfThreeInts
{
    static void Main()
    {
        Console.Title = "Biggest of three";
        string title = new string('-', 48);
        Console.WriteLine(title);
        Console.WriteLine("This program finds the biggest of three integers");
        Console.WriteLine(title);
        int[] numbers = new int[3];
        Console.Write("\n\rEnter three integer numbers: ");
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
            bool parseSuccess = int.TryParse(separatedRead[i], out numbers[i]);
            while (parseSuccess == false)
            {
                Console.WriteLine("Your input is not valid. Try again: ");
                readStr = Console.ReadLine();
                separatedRead = readStr.Split(' ');
                parseSuccess = int.TryParse(separatedRead[i], out numbers[i]);
                i = 0;
            }
        }
        int biggestValue = 0;
        if (numbers[0] > numbers[1])
        {
            if (numbers[0] > numbers[2])
            {
                biggestValue = numbers[0];
            }
        }
        if (numbers[1] > numbers[0])
        {
            if (numbers[1] > numbers[2])
            {
                biggestValue = numbers[1];
            }
        }
        if (numbers[2] > numbers[0])
        {
            if (numbers[2] > numbers[1])
            {
                biggestValue = numbers[2];
            }
        }
        Console.WriteLine("\n\rBiggest number is: {0}.\n\r", biggestValue);
    }
}