using System;

class NameOfDigit
{
    static void Main()
    {
        Console.Title = "Name of digit";
        string title = new string('-', 40);
        Console.WriteLine(title);
        Console.WriteLine("This program returns the name of a digit");
        Console.WriteLine(title + "\n\r");
        int digit;
        bool parseSuccess = false;
        do
        {
            Console.Write("Enter digit between 0 and 9: ");
            string readStr = Console.ReadLine();
            parseSuccess = int.TryParse(readStr, out digit);
        }
        while (digit < 0 || digit > 9 || parseSuccess == false);
        Console.Write("\n\rYour digit's name is: ");
        switch (digit)
        {
            case 0: Console.WriteLine("Zero.\n\r"); break;
            case 1: Console.WriteLine("One.\n\r"); break;
            case 2: Console.WriteLine("Two.\n\r"); break;
            case 3: Console.WriteLine("Three.\n\r"); break;
            case 4: Console.WriteLine("Four.\n\r"); break;
            case 5: Console.WriteLine("Five.\n\r"); break;
            case 6: Console.WriteLine("Six.\n\r"); break;
            case 7: Console.WriteLine("Seven.\n\r"); break;
            case 8: Console.WriteLine("Eight.\n\r"); break;
            case 9: Console.WriteLine("Nine.\n\r"); break;
        }
    }
}
