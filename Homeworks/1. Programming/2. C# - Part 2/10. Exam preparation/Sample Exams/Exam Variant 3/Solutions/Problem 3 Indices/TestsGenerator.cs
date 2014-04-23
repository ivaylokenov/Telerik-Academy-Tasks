using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Problem_3_Indices
{
    static class TestsGenerator
    {
        public static void GenerateOneBigCycle()
        {
            int N = 199998;
            Console.WriteLine(N);
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < N; i++)
            {
                sb.AppendFormat("{0} ", i);
            }
            sb.AppendFormat("{0} ", 0);
            Console.WriteLine(sb.ToString().Trim());
        }

        public static void GenerateAndShuffle(int N)
        {
            int[] arr = new int[N];
            for (int i = 0; i < N; i++)
            {
                arr[i] = i;
            }
            arr = arr.Shuffle().ToArray();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                sb.AppendFormat("{0} ", arr[i]);
            }
            Console.WriteLine(N);
            Console.WriteLine(sb.ToString().Trim());
        }

        public static void PathPlusCycle(int N)
        {
            Random rand = new Random();
            int[] arr = new int[N];
            for (int i = 0; i < N; i++)
            {
                arr[i] = rand.Next(0, N);
            }
            arr = arr.Shuffle().ToArray();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                sb.AppendFormat("{0} ", arr[i]);
            }
            Console.WriteLine(N);
            Console.WriteLine(sb.ToString().Trim());
        }

        public static void PathPlusCyclePlusExit(int N)
        {
            Random rand = new Random();
            int[] arr = new int[N];
            for (int i = 0; i < N; i++)
            {
                arr[i] = rand.Next(0, (int)(N * 1.2));
            }
            arr = arr.Shuffle().ToArray();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                sb.AppendFormat("{0} ", arr[i]);
            }
            Console.WriteLine(N);
            Console.WriteLine(sb.ToString().Trim());
        }
    }
    public static class EnumerableExtensions
    {
        static Random rand = new Random();

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            var array = source.ToArray();
            var n = array.Length;
            while (n > 1)
            {
                var k = rand.Next(n);
                n--;
                var temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
            return array;
        }

        public static IEnumerable<T> TakeRandom<T>(this IEnumerable<T> source, int count)
        {
            return source.Shuffle().Take(count);
        }
    }
}
