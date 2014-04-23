using System;
using System.Collections.Generic;

namespace JustConvert
{
    class JustConvert
    {
        static void Main()
        {
            //get bases and numbers
            Console.Write("Enter base: ");
            int s = int.Parse(Console.ReadLine());

            Console.Write("Enter number of base {0}: ", s);
            string numberInS = Console.ReadLine();

            Console.Write("Enter base to convert to: ");
            int d = int.Parse(Console.ReadLine());

            //convert s in decimal

            //sum the polinom
            int sum = 0;
            int multiplier = 1;
            int digit;

            for (int i = (numberInS.Length - 1); i >= 0; i--)
            {
                switch (numberInS[i])
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
                        digit = numberInS[i] - '0';
                        break;
                }
                sum += digit * multiplier;
                multiplier *= s;
            }

            //covert decimal to d
            //get number
            int number = sum;

            //convert digits
            List<int> hexDigits = new List<int>();
            while (number != 0)
            {
                hexDigits.Add(number % d);
                number /= d;
            }

            //reverse digits to get correct order
            hexDigits.Reverse();

            //print number in hex
            Console.Write("Your number of base {0}: ", d);
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
}
