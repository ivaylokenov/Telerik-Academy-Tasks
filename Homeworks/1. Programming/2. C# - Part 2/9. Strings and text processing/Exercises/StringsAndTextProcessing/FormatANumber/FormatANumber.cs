using System;
using System.Text;

class FormatANumber
{
    static void Main()
    {
        decimal number = decimal.Parse(Console.ReadLine());

        Console.WriteLine("{0,15:F}", number);
        Console.WriteLine("{0,15:X}", (int)number);
        Console.WriteLine("{0,15:P}", number);
        Console.WriteLine("{0,15:E}", number);
    }
}
