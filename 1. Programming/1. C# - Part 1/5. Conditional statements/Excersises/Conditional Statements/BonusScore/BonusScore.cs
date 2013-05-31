using System;

class BonusScore
{
    static void Main()
    {
        Console.Title = "Bonus score";
        string title = new string('-', 47);
        Console.WriteLine(title);
        Console.WriteLine("This program returns bonus score to your points");
        Console.WriteLine(title + "\n\r");
        int digit;
        bool parseSuccess = false;
        do
        {
            Console.Write("Enter digit between 0 and 9: ");
            string readStr = Console.ReadLine();
            parseSuccess = int.TryParse(readStr, out digit);
        }
        while (digit < 1 || digit > 9 || parseSuccess == false);
        switch (digit)
        {
            case 1: digit *= 10; break;
            case 2: digit *= 10; break;
            case 3: digit *= 10; break;
            case 4: digit *= 100; break;
            case 5: digit *= 100; break;
            case 6: digit *= 100; break;
            case 7: digit *= 1000; break;
            case 8: digit *= 1000; break;
            case 9: digit *= 1000; break;
        }
        Console.WriteLine("\n\rBonus score: {0}.\n\r", digit);
    }
}
