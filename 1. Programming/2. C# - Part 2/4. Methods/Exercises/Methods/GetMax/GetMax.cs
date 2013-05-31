using System;

class GetMax
{
    //returns the bigger of two integers
    static int GetMaxFromTwo(int firstNumber, int secondNumber)
    {
        if (firstNumber > secondNumber)
        {
            return firstNumber;
        }
        else
        {
            return secondNumber;
        }
    }

    static void Main()
    {
        //read input
        Console.Write("Enter first integer: ");
        int first = int.Parse(Console.ReadLine());
        Console.Write("Enter second integer: ");
        int second = int.Parse(Console.ReadLine());
        Console.Write("Enter third integer: ");
        int third = int.Parse(Console.ReadLine());

        //check the biggest of them
        int temporaryVariable = GetMaxFromTwo(first, second);
        int biggestNumber = GetMaxFromTwo(temporaryVariable, third);

        //print result
        Console.WriteLine("Biggest number is: {0}", biggestNumber);
    }
}
