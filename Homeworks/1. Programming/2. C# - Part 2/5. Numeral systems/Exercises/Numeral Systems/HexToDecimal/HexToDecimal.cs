using System;
using System.Collections.Generic;

class HexToDecimal
{
    static void Main()
    {
        //get number in hex
        Console.Write("Enter number in hexadecimal system: ");
        string numberInHex = Console.ReadLine();

        //sum the polinom
        int sum = 0;
        int multiplier = 1;
        int digit;

        for (int i = (numberInHex.Length - 1); i >= 0; i--)
        {
            switch (numberInHex[i])
            {
                case 'A':
                    digit = 10;
                    break;
                case 'a':
                    digit = 10;
                    break;
                case 'B':
                    digit = 11;
                    break;
                case 'b':
                    digit = 11;
                    break;
                case 'C':
                    digit = 12;
                    break;
                case 'c':
                    digit = 12;
                    break;
                case 'D':
                    digit = 13;
                    break;
                case 'd':
                    digit = 13;
                    break;
                case 'E':
                    digit = 14;
                    break;
                case 'e':
                    digit = 14;
                    break;
                case 'F':
                    digit = 15;
                    break;
                case 'f':
                    digit = 15;
                    break;
                default:
                    digit = numberInHex[i] - '0';
                    break;
            }
            sum += digit * multiplier;
            multiplier *= 16;
        }

        //print result
        Console.Write("Your number in decimal system: ");
        Console.WriteLine(sum);
    }
}
