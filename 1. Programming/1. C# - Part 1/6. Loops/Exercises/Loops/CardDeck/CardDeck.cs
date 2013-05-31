using System;

class CardDeck
{
    static void Main()
    {
        string title = new string('-', 51);
        Console.Title = "Card Deck";
        Console.WriteLine(title);
        Console.WriteLine("This program prints all cards from a normal 52 deck");
        Console.WriteLine(title + "\n\r");
        for (int cardColor = 1; cardColor <= 4; cardColor++)
        {
            for (int cardNumber = 1; cardNumber <= 13; cardNumber++)
            {
                switch (cardNumber)
                {
                    case 1:
                        Console.Write("Ace of ");
                        break;
                    case 2:
                        Console.Write("Two of ");
                        break;
                    case 3:
                        Console.Write("Three of ");
                        break;
                    case 4:
                        Console.Write("Four of ");
                        break;
                    case 5:
                        Console.Write("Five of ");
                        break;
                    case 6:
                        Console.Write("Six of ");
                        break;
                    case 7:
                        Console.Write("Seven of ");
                        break;
                    case 8:
                        Console.Write("Eight of ");
                        break;
                    case 9:
                        Console.Write("Nine of ");
                        break;
                    case 10:
                        Console.Write("Ten of ");
                        break;
                    case 11:
                        Console.Write("Jack of ");
                        break;
                    case 12:
                        Console.Write("Queen of ");
                        break;
                    case 13:
                        Console.Write("King of ");
                        break;
                }

                switch (cardColor)
                {
                    case 1:
                        Console.WriteLine("Spades");
                        break;
                    case 2:
                        Console.WriteLine("Hearts");
                        break;
                    case 3:
                        Console.WriteLine("Diamonds");
                        break;
                    case 4:
                        Console.WriteLine("Clubs");
                        break;
                }
            }
        }
        Console.WriteLine();
    }
}
