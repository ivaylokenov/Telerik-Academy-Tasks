using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_5_Secret_Language
{
    class Program
    {
        static void Main()
        {
            string sentence = Console.ReadLine();
            string words = Console.ReadLine();
            string[] validWords = words.Split(new char[] { ' ', ',', '\"' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(Decompose(sentence, validWords));
        }

        static int Decompose(string sentence, string[] validWords)
        {
            int N = sentence.Length;
            int M = validWords.Length;
            string[] validSorted = new string[M];
            for (int i = 0; i < M; i++)
            {
                char[] c = validWords[i].ToCharArray();
                Array.Sort(c);
                validSorted[i] = new string(c);
            }
            int[] min = new int[N + 1];
            for (int i = 0; i < N; i++)
            {
                min[i + 1] = 999999;
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (i + 1 >= validWords[j].Length)
                    {
                        string s = sentence.Substring(i - validWords[j].Length + 1, validWords[j].Length);
                        char[] c = s.ToCharArray();
                        Array.Sort(c);
                        string s2 = new string(c);
                        if (s2 == validSorted[j])
                        {
                            int cost = 0;
                            for (int k = 0; k < validWords[j].Length; k++)
                            {
                                if (s[k] != validWords[j][k]) cost++;
                            }
                            min[i + 1] = Math.Min(min[i + 1], min[i + 1 - validWords[j].Length] + cost);
                        }
                    }
                }
            }
            return min[N] < 999999 ? min[N] : -1;
        } 
    }
}
