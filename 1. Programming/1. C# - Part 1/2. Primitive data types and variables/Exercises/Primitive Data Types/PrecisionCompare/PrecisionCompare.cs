using System;

    class PrecisionCompare
    {
        static void Main()
        {
            double firstNumber;
            double secondNumber;
            Console.Write("Enter floating-point number 1: ");
            string firstString = Console.ReadLine();
            double.TryParse(firstString, out firstNumber);
            Console.Write("Enter floating-point number 2: ");
            string secondString = Console.ReadLine();
            double.TryParse(secondString, out secondNumber);
            if (Math.Abs(firstNumber - secondNumber) < 0.000001)
            {
                Console.WriteLine("Precision of 0.000001 is correct.");
            }
            else
            {
                Console.WriteLine("Precision of 0.000001 is not correct.");
            }
        }
    }
