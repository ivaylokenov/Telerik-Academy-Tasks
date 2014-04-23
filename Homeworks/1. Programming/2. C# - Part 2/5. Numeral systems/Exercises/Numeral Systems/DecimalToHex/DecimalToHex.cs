using System;
using System.Collections.Generic;

class DecimalToHex
{
    static void Main()
    {
        //get number
        Console.Write("Enter number in decimal system: ");
        int number = int.Parse(Console.ReadLine());

        //convert digits
        List<int> hexDigits = new List<int>();
        while (number != 0)
        {
            hexDigits.Add(number % 16);
            number /= 16;
        }

        //reverse digits to get correct order
        hexDigits.Reverse();

        //print number in hex
        Console.Write("Your number in hexadecimal system: ");
        for (int i = 0; i < hexDigits.Count; i++)
        {
            switch (hexDigits[i])
            {
                case 10:
                    Console.Write("A");
                    break;
                case 11:
                    Console.Write("B");
                    break;
                case 12:
                    Console.Write("C");
                    break;
                case 13:
                    Console.Write("D");
                    break;
                case 14:
                    Console.Write("E");
                    break;
                case 15:
                    Console.Write("F");
                    break;
                default:
                    Console.Write(hexDigits[i]);
                    break;
            }
        }

        Console.WriteLine();
    }
}
