using System;

class DateTimeLeap
{
    static void Main()
    {
        Console.Write("Enter year: ");
        int year = int.Parse(Console.ReadLine());
        bool isLeap = DateTime.IsLeapYear(year);
        if (isLeap)
        {
            Console.WriteLine("Your year is leap.");
        }
        else
        {
            Console.WriteLine("Your year is not leap.");
        }
    }
}
