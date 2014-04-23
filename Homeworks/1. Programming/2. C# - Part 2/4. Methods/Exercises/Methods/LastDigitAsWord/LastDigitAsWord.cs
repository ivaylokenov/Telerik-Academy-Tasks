using System;

class LastDigitAsWord
{
    //returns last digit from a number as word
    static string LastDigit(int number)
    {
        int lastDigit = number % 10;
        switch (lastDigit)
        {
            case 0:
                return "zero";
            case 1:
                return "one";
            case 2:
                return "two";
            case 3:
                return "three";
            case 4:
                return "four";
            case 5:
                return "five";
            case 6:
                return "six";
            case 7:
                return "seven";
            case 8:
                return "eight";
            case 9:
                return "nine";
        }
        return "0";
    }

    static void Main()
    {
        //read input
        Console.Write("Enter integer: ");
        int number = int.Parse(Console.ReadLine());

        //print result
        Console.WriteLine("Last digit is: " + LastDigit(number) + ".");
    }
}
