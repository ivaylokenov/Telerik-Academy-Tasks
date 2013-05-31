using System;
using System.Threading;
using System.Globalization;

class Fibonacci
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.Title = "Fibonacci";
        string title = new string('-', 55);
        Console.WriteLine(title);
        Console.WriteLine("This program prints 100 members of Fibonacci's sequence");
        Console.WriteLine(title + "\n\r");
        decimal a = 0;
        decimal b = 1;
        decimal c;
        Console.Write("{0}, {1}, ", a, b);
        for (int i = 0; i < 100; i++)
        {
            System.Threading.Thread.Sleep(100);
            c = a + b;
            if (i == 99)
            {
                Console.Write("{0}", c);
                Console.WriteLine("\n\r");
            }
            else
            {
                Console.Write("{0}, ", c);
            }
            a = b;
            b = c;
        }
    }
}
