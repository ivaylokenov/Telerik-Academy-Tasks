using System;
using System.Collections.Generic;

namespace DecimalToBinary
{
    class DecimalToBinary
    {
        static void Main()
        {
            //get decimal
            Console.Write("Enter number in decimal system: ");
            int number = int.Parse(Console.ReadLine());
            int bit;
            List<int> bits = new List<int>();

            //add bits from the number into the list
            while (number != 0)
            {
                bit = number % 2;
                bits.Add(bit);
                number /= 2;
            }

            //reverse the number so that it gets the right order of bits
            bits.Reverse();
         
            //print bits
            Console.Write("Your number is binary system: ");
            for (int i = 0; i < bits.Count; i++)
            {
                Console.Write(bits[i]);
            }

            Console.WriteLine();
        }
    }
}