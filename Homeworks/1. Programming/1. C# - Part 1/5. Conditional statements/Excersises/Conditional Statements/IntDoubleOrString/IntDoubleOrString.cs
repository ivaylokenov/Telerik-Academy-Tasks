using System;

class IntDoubleOrString
{
    static void Main()
    {
        Console.Title = "Int, Double or String";
        string title = new string('-', 24);
        Console.WriteLine(title);
        Console.WriteLine("This program uses switch");
        Console.WriteLine(title);
        Console.Write("\n\rEnter \"int\", \"double\" or \"string\": ");
        string readStr = Console.ReadLine();
        while (readStr != "int" && readStr != "double" && readStr != "string")
        {
            Console.WriteLine("Your input is invalid. Try again: ");
            readStr = Console.ReadLine();
        }
        switch (readStr)
        {
            case "int":
                int intNumber;
                Console.Write("Enter number: ");
                readStr = Console.ReadLine();
                bool parseSuccess = int.TryParse(readStr, out intNumber);
                while (parseSuccess == false)
                {
                    Console.WriteLine("Your input is invalid. Try again: ");
                    readStr = Console.ReadLine();
                    parseSuccess = int.TryParse(readStr, out intNumber);
                }
                Console.WriteLine("\n\rResult is: {0}.\n\r", (intNumber+=1));
                break;

            case "double":
                double doubleNumber;
                Console.Write("Enter number: ");
                readStr = Console.ReadLine();
                parseSuccess = double.TryParse(readStr, out doubleNumber);
                while (parseSuccess == false)
                {
                    Console.WriteLine("Your input is invalid. Try again: ");
                    readStr = Console.ReadLine();
                    parseSuccess = double.TryParse(readStr, out doubleNumber);
                }
                Console.WriteLine("\n\rResult is: {0}.\n\r", (doubleNumber+=1));
                break;

            case "string":
                Console.Write("Enter string: ");
                readStr = Console.ReadLine();
                Console.WriteLine("\n\rResult is: {0}.\n\r", (readStr + "*"));
                break;
        }
    }
}
