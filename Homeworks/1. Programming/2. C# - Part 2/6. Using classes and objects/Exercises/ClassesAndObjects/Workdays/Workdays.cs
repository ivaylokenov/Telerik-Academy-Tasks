using System;

class Workdays
{
    static void Main()
    {
        string[] publicHolidays = { "2012/1/1", "2013/3/3", "2013/5/1", "2013/5/6", "2013/5/24", "2013/9/6", "2013/9/22", "2013/11/1", "2013/12/24", "2013/12/25", "2013/12/26" };

        string inputDate = "2014/3/10";
        DateTime currentDate = DateTime.Parse(inputDate);
        //Console.WriteLine((int)(currentDate - DateTime.Now).TotalDays + 1);

        DateTime now = DateTime.Now;
        TimeSpan tSpan = new System.TimeSpan(0, 24, 0, 0); 

        int counter = 0;

        do
        {
            now += tSpan;
            if (now.DayOfWeek != DayOfWeek.Sunday && now.DayOfWeek != DayOfWeek.Saturday)
            {
                counter++;

                foreach (var holiday in publicHolidays)
                {
                    DateTime holidayDate = DateTime.Parse(holiday);
                    if (now.Day == holidayDate.Day && now.Month == holidayDate.Month)
                    {
                        counter--;
                    }
                }
            }
        }
        while(now < currentDate);

        Console.WriteLine(counter);
    }
}
