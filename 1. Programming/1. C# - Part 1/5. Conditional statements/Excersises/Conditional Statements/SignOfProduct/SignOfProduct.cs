using System;

class SignOfProduct
{
    static void Main()
    {
        Console.Title = "Sign of product";
        string title = new string('-', 57);
        Console.WriteLine(title);
        Console.WriteLine("This program finds the product sign of three real numbers");
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
        int negativeNumbers = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < 0)
            {
                negativeNumbers += 1;
            }
        }
        if (negativeNumbers % 2 == 0)
        {
            Console.WriteLine("\n\rPositive product (+).\n\r");
        }
        else
        {
            Console.WriteLine("\n\rNegative product (-).\n\r");
        }
    }
}
