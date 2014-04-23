using System;

class ThirdDigitIsSeven
{
    static void Main()
    {
        int integer;
        Console.Write("Enter integer: ");
        string strRead = Console.ReadLine();
        bool parseSuccess = Int32.TryParse(strRead, out integer);
        while (parseSuccess == false)
        {
            Console.Write("Your integer is not valid. Try again: ");
            strRead = Console.ReadLine();
            parseSuccess = Int32.TryParse(strRead, out integer);
        }
        bool isSeven = (((integer / 100) % 10) == 7);
        if (isSeven == true)
        {
            Console.WriteLine("Your integer's third digit (right-to-left) is 7.");
        }
        else
        {
            Console.WriteLine("Your integer's third digit (right-to-left) is not 7.");
        }
    }
}
