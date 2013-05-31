using System;

class StringAndObject
{
    static void Main()
    {
        string firstString = "Hello";
        string secondString = "World";
        object objectOfStrings = firstString + " " + secondString;
        string sumOfString = (string)objectOfStrings;
        Console.WriteLine(sumOfString);
    }
}
