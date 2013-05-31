using System;
using System.Collections.Generic;

class ReverseDigits
{
    //reverses digits
    static string Reverse(decimal number)
    {
        string data = number.ToString();
        char[] digits = data.ToCharArray();
        Array.Reverse(digits);
        data = "";

        foreach (var ch in digits)
        {
            data += ch.ToString();
        }

        return data;
    }

    static void Main()
    {
        //input data
        decimal number = decimal.Parse(Console.ReadLine());

        //print result
        Console.WriteLine(Reverse(number));
    }
}
