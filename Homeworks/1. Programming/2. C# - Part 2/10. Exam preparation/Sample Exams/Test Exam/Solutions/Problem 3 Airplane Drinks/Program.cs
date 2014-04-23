using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_3_Airplane_Drinks
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int teaCount = int.Parse(Console.ReadLine());
            int[] tea = new int[teaCount];
            for (int i = 0; i < teaCount; i++)
            {
                tea[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(Solve(n, tea));
        }

        static long Solve(int n, int[] tea)
        {
            long res = n * 4;
            bool[] check = new bool[n];
            int i;
            for (i = 0; i < tea.Length; i++) check[tea[i] - 1] = true;
            long lastt = 0;
            long lastc = 0;
            int countt = 0;
            int countc = 0;
            for (i = n - 1; i >= 0; i--)
            {
                if (check[i]) { countt++; lastt = Math.Max(lastt, i + 1); }
                else { countc++; lastc = Math.Max(lastc, i + 1); }
                if (countc == 7) { countc = 0; res += lastc * 2; res += 47; lastc = 0; }
                if (countt == 7) { countt = 0; res += lastt * 2; res += 47; lastt = 0; }
            }
            if (countc != 0) { res += lastc * 2; res += 47; }
            if (countt != 0) { res += lastt * 2; res += 47; }
            return res;
        } 
    }
}
