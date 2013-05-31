using System;

    class Nulls
    {
        static void Main()
        {
            int? first = null;
            double? second = null;
            Console.WriteLine(first);
            Console.WriteLine(second);
            first += 10;
            second += 100;
            Console.WriteLine(first);
            Console.WriteLine(second);
            first += null;
            second += null;
            Console.WriteLine(first);
            Console.WriteLine(second);
        }
    }
