using System;
using System.Collections.Generic;
namespace Problem_2_7_segment_Digits
{
    class Program
    {
        static readonly byte[] digits = new byte[10]
        {
            Convert.ToByte("1111110", 2), // 0
            Convert.ToByte("0110000", 2), // 1
            Convert.ToByte("1101101", 2), // 2
            Convert.ToByte("1111001", 2), // 3
            Convert.ToByte("0110011", 2), // 4
            Convert.ToByte("1011011", 2), // 5
            Convert.ToByte("1011111", 2), // 6
            Convert.ToByte("1110000", 2), // 7
            Convert.ToByte("1111111", 2), // 8
            Convert.ToByte("1111011", 2), // 9
        };
        static int N;
        static byte[] segments;

        static void Main()
        {
            N = int.Parse(Console.ReadLine());
            segments = new byte[N];
            currentAnswer = new char[N];
            for (int i = 0; i < N; i++)
            {
                segments[i] = Convert.ToByte(Console.ReadLine(), 2);
            }
            SolveWithRecursion(0);
            Console.WriteLine(answers.Count);
            foreach (string answer in answers)
            {
                Console.WriteLine(answer);
            }
        }

        static readonly List<string> answers = new List<string>();
        static char[] currentAnswer;

        static void SolveWithRecursion(int numberPosition)
        {
            if (numberPosition == N)
            {
                answers.Add(new string(currentAnswer));
                return;
            }
            for (int i = 0; i < digits.Length; i++)
            {
                if ((digits[i] & segments[numberPosition]) == segments[numberPosition])
                {
                    currentAnswer[numberPosition] = (char)('0' + i);
                    SolveWithRecursion(numberPosition + 1);
                }
            }
        }
    }
}
