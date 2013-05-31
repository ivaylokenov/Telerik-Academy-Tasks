using System;

class SubsetZero
{
    static void Main()
    {
        Console.Title = "Subset of zero";
        string title = new string('-', 43);
        Console.WriteLine(title);
        Console.WriteLine("This program finds subset which sum is zero");
        Console.WriteLine(title);
        int[] numbers = new int[5];
        Console.Write("\n\rEnter five integer numbers: ");
        string readStr = Console.ReadLine();
        string[] separatedRead = readStr.Split(' ');
        while (separatedRead.Length != 5)
        {
            Console.WriteLine("Your input is not valid. Try again: ");
            readStr = Console.ReadLine();
            separatedRead = readStr.Split(' ');
        }
        for (int i = 0; i < separatedRead.Length; i++)
        {
            bool parseSuccess = int.TryParse(separatedRead[i], out numbers[i]);
            while (parseSuccess == false)
            {
                Console.WriteLine("Your input is not valid. Try again: ");
                readStr = Console.ReadLine();
                separatedRead = readStr.Split(' ');
                parseSuccess = int.TryParse(separatedRead[i], out numbers[i]);
                i = 0;
            }
        }
        int sum = 0;
        bool isZero = false;
        for (int i = 0; i < (numbers.Length); i++)
        {
            if (numbers[i] == 0)
            {
                isZero = true;
            }
            else
            {
                for (int j = i+1; j < numbers.Length; j++)
                {
                    sum = numbers[i] + numbers[j];
                    if (sum == 0)
                    {
                        isZero = true;
                    }
                    else
                    {
                        for (int k = j+1; k < numbers.Length; k++)
                        {
                            sum = numbers[i] + numbers[j] + numbers[k];
                            if (sum == 0)
                            {
                                isZero = true;
                            }
                            else
                            {
                                for (int g = k+1; g < numbers.Length; g++)
                                {
                                    sum = numbers[i] + numbers[j] + numbers[k] + numbers[g];
                                    if (sum == 0)
                                    {
                                        isZero = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        if (isZero == false)
        {
            Console.WriteLine("\n\rThere is NO subset with sum = 0.\n\r");
        }
        else
        {
            Console.WriteLine("\n\rThere is a subset with sum = 0.\n\r");
        }
    }
}

