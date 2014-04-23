using System;

namespace BinaryToDecimal
{
    class BinaryToDecimal
    {
        static void Main()
        {
            //get number in binary
            Console.Write("Enter number is binary system: ");
            string binaryNumber = Console.ReadLine();

            //get number in polinom
            int sum = 0;
            int binaryPow = 1;

            for (int i = (binaryNumber.Length - 1); i >= 0; i--)
            {
                sum += (binaryNumber[i] - '0') * binaryPow;
                binaryPow *= 2;
            }

            //print result
            Console.Write("Your number in decimal system is: ");
            Console.WriteLine(sum);
        }
    }
}
