using System;

class TextToEnglish
{
    static void Main(string[] args)
    {
        Console.Title = "Number to English";
        string title = new string('-', 33);
        Console.WriteLine(title);
        Console.WriteLine("This program turns number to text");
        Console.WriteLine(title + "\n\r");
        int digit;
        bool parseSuccess = false;
        do
        {
            Console.Write("Enter number between 0 and 999: ");
            string readStr = Console.ReadLine();
            parseSuccess = int.TryParse(readStr, out digit);
        }
        while (digit < 1 || digit > 999 || parseSuccess == false);
        string englishPronounce = "NumberToText";
        if (digit >= 0 && digit <= 20)
        {
            switch (digit)
            {
                case 0:
                    englishPronounce = "Zero";
                    break;
                case 1:
                    englishPronounce = "One";
                    break;
                case 2:
                    englishPronounce = "Two";
                    break;
                case 3:
                    englishPronounce = "Three";
                    break;
                case 4:
                    englishPronounce = "Four";
                    break;
                case 5:
                    englishPronounce = "Five";
                    break;
                case 6:
                    englishPronounce = "Six";
                    break;
                case 7:
                    englishPronounce = "Seven";
                    break;
                case 8:
                    englishPronounce = "Eight";
                    break;
                case 9:
                    englishPronounce = "Nine";
                    break;
                case 10:
                    englishPronounce = "Ten";
                    break;
                case 11:
                    englishPronounce = "Eleven";
                    break;
                case 12:
                    englishPronounce = "Twelve";
                    break;
                case 13:
                    englishPronounce = "Thirdteen";
                    break;
                case 14:
                    englishPronounce = "Fourteen";
                    break;
                case 15:
                    englishPronounce = "Fifteen";
                    break;
                case 16:
                    englishPronounce = "Sixteen";
                    break;
                case 17:
                    englishPronounce = "Seventeen";
                    break;
                case 18:
                    englishPronounce = "Eighteen";
                    break;
                case 19:
                    englishPronounce = "Nineteen";
                    break;
                case 20:
                    englishPronounce = "Twenty";
                    break;
            }
        }

        if (digit > 20 & digit < 100)
        {
            int firstDigit = digit % 10;
            int secondDigit = digit / 10;

            switch (secondDigit)
            {
                case 2:
                    englishPronounce = "Twenty";
                    break;
                case 3:
                    englishPronounce = "Thirty";
                    break;
                case 4:
                    englishPronounce = "Fourty";
                    break;
                case 5:
                    englishPronounce = "Fifty";
                    break;
                case 6:
                    englishPronounce = "Sixty";
                    break;
                case 7:
                    englishPronounce = "Seventy";
                    break;
                case 8:
                    englishPronounce = "Eighty";
                    break;
                case 9:
                    englishPronounce = "Ninety";
                    break;
            }

            if (firstDigit != 0)
            {
                switch (firstDigit)
                {
                    case 1:
                        englishPronounce += " one";
                        break;
                    case 2:
                        englishPronounce += " two";
                        break;
                    case 3:
                        englishPronounce += " three";
                        break;
                    case 4:
                        englishPronounce += " four";
                        break;
                    case 5:
                        englishPronounce += " five";
                        break;
                    case 6:
                        englishPronounce += " six";
                        break;
                    case 7:
                        englishPronounce += " seven";
                        break;
                    case 8:
                        englishPronounce += " eight";
                        break;
                    case 9:
                        englishPronounce += " nine";
                        break;
                }
            }
        }

        if (digit >= 100 && digit <= 999)
        {
            int firstDigit = digit % 10;
            int secondDigit = (digit % 100) / 10;
            int thirdDigit = digit / 100;

            switch (thirdDigit)
            {
                case 1:
                    englishPronounce = "One hundred";
                    break;
                case 2:
                    englishPronounce = "Two hundred";
                    break;
                case 3:
                    englishPronounce = "Three hundred";
                    break;
                case 4:
                    englishPronounce = "Four hundred";
                    break;
                case 5:
                    englishPronounce = "Five hundred";
                    break;
                case 6:
                    englishPronounce = "Six hundred";
                    break;
                case 7:
                    englishPronounce = "Seven hundred";
                    break;
                case 8:
                    englishPronounce = "Eight hundred";
                    break;
                case 9:
                    englishPronounce = "Nine hundred";
                    break;
            }

            string[] secondDigits = { "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] firstDigits = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] aboveTen = { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

            if (firstDigit == 0 && secondDigit != 0)
            {
                englishPronounce = englishPronounce + " and " + secondDigits[secondDigit-1];
            }

            if (firstDigit != 0 && secondDigit == 0)
            {
                englishPronounce = englishPronounce + " and " + firstDigits[firstDigit - 1];
            }

            if (firstDigit != 0 && secondDigit == 1)
            {
                englishPronounce = englishPronounce + " and " + aboveTen[firstDigit - 1];
            }

            if (firstDigit != 0 && secondDigit > 1)
            {
                englishPronounce = englishPronounce + " " + secondDigits[secondDigit - 1] + " " + firstDigits[firstDigit - 1];
            }

        }

        Console.WriteLine("\n\rResult: " + digit + " => " + englishPronounce + "\n\r");
    }
}
