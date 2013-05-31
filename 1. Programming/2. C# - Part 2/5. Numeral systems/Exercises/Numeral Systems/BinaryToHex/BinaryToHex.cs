using System;
using System.Collections.Generic;

class BinaryToHex
{
    static void Main()
    {
        //get number in binary
        Console.Write("Enter number in binary system: ");
        string numberInBinary = Console.ReadLine();
        string digit;
        
        //convert string to divisable by 4
        while (numberInBinary.Length % 4 != 0)
        {
            numberInBinary = "0" + numberInBinary;
        }

        //print number in hex
        Console.Write("Your number in hexadecimal system is: ");
        for (int i = 0; i < numberInBinary.Length; i+= 4)
        {
            digit = numberInBinary[i].ToString() + numberInBinary[i + 1].ToString() + numberInBinary[i + 2].ToString() + numberInBinary[i + 3].ToString();

            switch (digit)
            {
                case "0001":
                    Console.Write(1);
                    break;
                case "0010":
                    Console.Write(2);
                    break;
                case "0011":
                    Console.Write(3);
                    break;
                case "0100":
                    Console.Write(4);
                    break;
                case "0101":
                    Console.Write(5);
                    break;
                case "0110":
                    Console.Write(6);
                    break;
                case "0111":
                    Console.Write(7);
                    break;
                case "1000":
                    Console.Write(8);
                    break;
                case "1001":
                    Console.Write(9);
                    break;
                case "1010":
                    Console.Write("A");
                    break;
                case "1011":
                    Console.Write("B");
                    break;
                case "1100":
                    Console.Write("C");
                    break;
                case "1101":
                    Console.Write("D");
                    break;
                case "1110":
                    Console.Write("E");
                    break;
                case "1111":
                    Console.Write("F");
                    break;
            }
        }

        Console.WriteLine();
    }
}
