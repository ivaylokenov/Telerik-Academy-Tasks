using System;
using System.Globalization;
using System.Text;

class After6HoursAnd30Minutes
{
    static void Main()
    {
        Console.WriteLine("Enter two days in format 'day.month.year hour:minute:second':");
        string dateString = Console.ReadLine(); //"27.02.2006 12:36:56";

        IFormatProvider culture = new CultureInfo("fr-FR", true);

        DateTime firstDate = DateTime.Parse(dateString, culture);

        firstDate = firstDate.AddHours(6);
        firstDate = firstDate.AddMinutes(30);

        
        Console.WriteLine("Date after 6 hours and 30 minutes is {0:dd.MM.yyyy H:mm:ss}.", firstDate);

        string inBulgaria = string.Empty;

        switch (firstDate.DayOfWeek.ToString())
        {
            case "Monday":
                inBulgaria = "Понеделник"; break;
            case "Tuesday":
                inBulgaria = "Вторник"; break;
            case "Wednesday":
                inBulgaria = "Сряда"; break;
            case "Thursday":
                inBulgaria = "Четвъртък"; break;
            case "Friday":
                inBulgaria = "Петък"; break;
            case "Saturday":
                inBulgaria = "Събота"; break;
            case "Sunday":
                inBulgaria = "Неделя"; break;
        }

        Console.WriteLine("Day of week in bulgarian: {0}.", inBulgaria);
    }
}
