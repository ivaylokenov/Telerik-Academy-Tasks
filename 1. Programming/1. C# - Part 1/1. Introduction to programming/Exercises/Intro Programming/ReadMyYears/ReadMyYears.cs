using System;

class ReadMyYears
{
    static void Main()
    {
        int myYears;
        Console.Write("Enter your current age: ");
        myYears = int.Parse(Console.ReadLine());
        Console.WriteLine("In 10 years you will be {0} years old.", (myYears + 10));
    }
}

