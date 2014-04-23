using System;

namespace RangeException
{
    class Test
    {
        static void Main()
        {
            //check with numbers
            Console.Write("Enter number between 0 and 100: ");
            int number = int.Parse(Console.ReadLine());
            try
            {
                if (number < 0 || number > 100)
                {
                    throw new InvalidRangeException<int>("Number is invalid!", 0, 100);
                }
                Console.WriteLine("Number correct!");
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine("{2} It should be between {0} and {1}.", ex.Start, ex.End, ex.Message);
            }

            //check with DateTime
            Console.Write("Enter date between 1.1.1980 and 31.12.2013 \n\r(format should be Year.Month.Day): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            try
            {
                if (date < new DateTime(1980, 1, 1) || date > new DateTime(2013, 12, 31))
                {
                    throw new InvalidRangeException<DateTime>("Date is invalid!", new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));
                }
                Console.WriteLine("Date correct!");
            }
            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine("{2} It should be between {0} and {1}.", ex.Start.ToShortDateString(), ex.End.ToShortDateString(), ex.Message);
            }
        }
    }
}
