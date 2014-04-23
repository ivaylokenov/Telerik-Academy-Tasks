using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitar
{
    class Guitar
    {
        //BGCoder: 100/100

        static string input = Console.ReadLine().Replace(", ", " ");
        static string[] Cords = input.Split(' ');

        static int[] cordsInteger = new int[Cords.Length];

        static int B = int.Parse(Console.ReadLine());
        static int M = int.Parse(Console.ReadLine());

        static void Main(string[] args)
        {
            for (int i = 0; i < Cords.Length; i++)
            {
                cordsInteger[i] = int.Parse(Cords[i]);
            }

            int[,] checker = new int[cordsInteger.Length + 1, M + 1];

            checker[0, B] = 1;

            for (int i = 1; i <= cordsInteger.Length; i++)
            {
                for (int j = 0; j <= M; j++)
                {
                    if (checker[i-1, j] == 1)
                    {
                        int currentChange = cordsInteger[i - 1];
                        if (j + currentChange <= M)
                        {
                            checker[i, j + currentChange] = 1;
                        }
                        if (j - currentChange >= 0)
                        {
                            checker[i, j - currentChange] = 1;
                        }
                    }
                }
            }

            int answer = -1;

            for (int i = M; i >= 0; i--)
            {
                if (checker[cordsInteger.Length, i] == 1)
                {
                    answer = i;
                    break;
                }
            }

            Console.WriteLine(answer);
        }
    }
}
