using System;
using System.Collections.Generic;

class Task
{
    //menu
    static int Menu()
    {
        Console.Title = "Tasks";
        Console.WindowHeight = 40;
        Console.BufferHeight = 40;
        Console.SetCursorPosition(Console.WindowWidth / 2 - 3, Console.WindowHeight / 2 - 5);
        Console.WriteLine("TASKS!");
        Console.SetCursorPosition(Console.WindowWidth / 2 - 8, Console.WindowHeight / 2 - 3);
        Console.WriteLine("Choose an option: ");
        Console.SetCursorPosition(Console.WindowWidth / 2 - 22, Console.WindowHeight / 2 - 2);
        Console.WriteLine("1 - Reverse the digit of a number");
        Console.SetCursorPosition(Console.WindowWidth / 2 - 22, Console.WindowHeight / 2 - 1);
        Console.WriteLine("2 - Calculate average of sequence of integers");
        Console.SetCursorPosition(Console.WindowWidth / 2 - 22, Console.WindowHeight / 2);
        Console.WriteLine("3 - Solve linear equation");

        int choices;
        Console.SetCursorPosition(Console.WindowWidth / 2 - 22, Console.WindowHeight / 2 + 1);
        while (!int.TryParse(Console.ReadLine(), out choices) || choices < 1 || choices > 3)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 22, Console.WindowHeight / 2 + 1);
            Console.Write("Your input is invalid. Try again: ");
        }

        return choices;
    }

    //reverse digit of decimal
    static void ReverseDigit()
    {
        decimal number;

        Console.WriteLine("This program will reverse the digits of a positive decimal number.");
        Console.WriteLine();
        Console.Write("Enter positive decimal number: ");

        while (!decimal.TryParse(Console.ReadLine(), out number) || number < 0)
        {
            Console.Write("Your input is invalid. Try again: ");
        }

        char[] input = (number.ToString()).ToCharArray();
        Array.Reverse(input);

        string result = "";

        foreach (var ch  in input)
        {
            result += ch;
        }

        Console.WriteLine();
        Console.WriteLine("Reversed number is: {0}", result);
        Console.WriteLine();
    }

    //average of sequence
    static void AverageOfSequence()
    {
        Console.WriteLine("This program will calculate the average of a sequence of integers.");
        Console.WriteLine();
        Console.Write("Enter ammount of numbers: ");
        int amount;
        while (!int.TryParse(Console.ReadLine(), out amount) || amount <= 0)
        {
            Console.Write("Your input is invalid. Try again: ");
        }

        int[] sequenceOfNumbers = new int[amount];
        for (int i = 0; i < amount; i++)
        {
            Console.Write("Enter number {0}: ", i);
            while (!int.TryParse(Console.ReadLine(), out sequenceOfNumbers[i]))
            {
                Console.Write("Your input is invalid. Try again: ");
            }
        }

        decimal sum = 0;
        for (int i = 0; i < amount; i++)
        {
            sum += sequenceOfNumbers[i];
        }
        sum /= amount;

        Console.WriteLine();
        Console.WriteLine("The average is: {0}", sum);
        Console.WriteLine();
    }

    //linear equation
    static void LinearEquation()
    {
        Console.WriteLine("This program will solve linear equation a*x^2 + b.");
        Console.WriteLine();
        Console.Write("Enter a != 0: ");
        decimal a;
        while (!decimal.TryParse(Console.ReadLine(), out a) || a == 0)
        {
            Console.Write("Your input is invalid. Try again: ");
        }

        decimal b;
        Console.Write("Enter b: ");
        while (!decimal.TryParse(Console.ReadLine(), out b))
        {
            Console.Write("Your input is invalid. Try again: ");
        }

        decimal x = (-b/a);

        Console.WriteLine();
        Console.WriteLine("x = {0}", x);
        Console.WriteLine();
    }

    static void Main()
    {
        int choice = Menu();
        Console.Clear();
        if (choice == 1)
        {
            ReverseDigit();
        }
        if (choice == 2)
        {
            AverageOfSequence();
        }
        if (choice == 3)
        {
            LinearEquation();
        }
    }
}
