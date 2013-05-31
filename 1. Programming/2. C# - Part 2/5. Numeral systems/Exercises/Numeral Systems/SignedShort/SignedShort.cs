using System;
using System.Collections.Generic;

class SignedShort
{
    static void Main()
    {
        Console.Write("Enter 16-bit signed number: ");
        int number = int.Parse(Console.ReadLine());
        string binaryNumber = "";

        List<int> digits = new List<int>();

        if (number >= 0)
        {
            while (number != 0)
            {
                digits.Add(number % 2);
                number /= 2;
            }

            digits.Reverse();

            for (int i = 0; i < digits.Count; i++)
            {
                binaryNumber += digits[i];
            }

            while (binaryNumber.Length % 16 != 0)
            {
                binaryNumber = "0" + binaryNumber;
            }
        }
        else
        {
            number = Math.Abs(number) - 1;

            while (number != 0)
            {
                digits.Add(number % 2);
                number /= 2;
            }

            digits.Reverse();

            for (int i = 0; i < digits.Count; i++)
            {
                if (digits[i] == 0)
                {
                    binaryNumber += "1";
                }
                else
                {
                    binaryNumber += "0";
                }
            }

            while (binaryNumber.Length % 16 != 0)
            {
                binaryNumber = "1" + binaryNumber;
            }
        }
        Console.Write("Result: ");
        Console.WriteLine(binaryNumber);
    }
}
