using System;

class AstrologicalDigits
{
    static void Main()
    {
        string number = Console.ReadLine();
        int sumOfDigits = 0;
        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] != '.' && number[i] != '-')
            {
                sumOfDigits += int.Parse(number[i].ToString());
            }
        }
        int tempNumber = sumOfDigits;
        
        while (sumOfDigits > 9)
        {
            tempNumber = sumOfDigits;
            sumOfDigits = 0;
            do
            {
                int currentDigit = tempNumber % 10;
                tempNumber /= 10;
                sumOfDigits += currentDigit;
            }
            while (tempNumber != 0);
        }
        Console.WriteLine(sumOfDigits);
    }
}
