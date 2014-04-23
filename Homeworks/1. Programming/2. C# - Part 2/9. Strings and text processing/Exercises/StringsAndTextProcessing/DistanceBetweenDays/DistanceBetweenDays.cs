using System;
using System.Globalization;
using System.Text;

class DistanceBetweenDays
{
    static void Main()
    {
        Console.WriteLine("Enter two days in format 'DD.MM.YYYY':");
        string firstDateString = Console.ReadLine(); //"27.02.2006";
        string secondDateString = Console.ReadLine(); //"29.03.2006";

        IFormatProvider culture = new CultureInfo("de-DE", true);

        DateTime firstDate = DateTime.Parse(firstDateString, culture);
        DateTime secondDate = DateTime.Parse(secondDateString, culture);

        if (firstDate > secondDate)
        {
            Console.Write((firstDate - secondDate).Days);
        }
        else
        {
            Console.Write((secondDate - firstDate).Days);
        }
        Console.WriteLine(" days between {0} and {1}.", firstDateString, secondDateString);
    }
}
