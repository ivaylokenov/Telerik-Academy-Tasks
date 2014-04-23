using System;

class GreatestVariableFromFive
{
    static void Main()
    {
        Console.Title = "Greatest variable";
        string title = new string('-', 54);
        Console.WriteLine(title);
        Console.WriteLine("This program finds the greatest value from 5 variables");
        Console.WriteLine(title);
        decimal[] numbers = new decimal[5];
        Console.Write("\n\rEnter five real numbers: ");
        string readStr = Console.ReadLine();
        string[] separatedRead = readStr.Split(' ');
        while (separatedRead.Length != 5)
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
        decimal bigestNumber = decimal.MinValue;
        for (int i = 0; i < (numbers.Length); i++)
        {
            if (bigestNumber < numbers[i])
            {
                bigestNumber = numbers[i];
            }
        }
        Console.WriteLine("\n\rGreatest value is: {0}.\n\r", bigestNumber);
    }
}
