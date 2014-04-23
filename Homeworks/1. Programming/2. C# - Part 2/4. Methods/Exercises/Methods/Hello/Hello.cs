using System;

class Hello
{
    static void HelloName()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Hello, " + name + "!");
    }

    static void Main()
    {
        HelloName();
    }
}
