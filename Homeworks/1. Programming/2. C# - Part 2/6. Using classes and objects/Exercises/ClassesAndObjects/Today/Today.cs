using System;

class Today
{
    static void Main()
    {
        DateTime currentDate = new DateTime();
        currentDate = DateTime.Now;
        Console.WriteLine("Today is: {0}.", currentDate.DayOfWeek);
    }
}
