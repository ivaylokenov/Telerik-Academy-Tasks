using System;

class MissCat2011
{
    static void Main()
    {
        string readStr = Console.ReadLine();
        int N = int.Parse(readStr);
        int[] catVotes = new int[11];
        int currentVote, mostVotes = int.MinValue, winnerCat = 0;

        for (int i = 1; i <= N; i++)
        {
            readStr = Console.ReadLine();
            currentVote = int.Parse(readStr);
            catVotes[currentVote]++;
        }
        for (int i = 1; i < catVotes.Length; i++)
        {
                if (catVotes[i] > mostVotes)
                {
                    mostVotes = catVotes[i];
                    winnerCat = i;
                }
        }
        for (int i = 1; i < catVotes.Length; i++)
        {
            if (i != winnerCat && catVotes[i] == mostVotes)
            {
                if (i < winnerCat)
                {
                    winnerCat = i;
                }
            }
        }
        Console.WriteLine(winnerCat);
    }
}
