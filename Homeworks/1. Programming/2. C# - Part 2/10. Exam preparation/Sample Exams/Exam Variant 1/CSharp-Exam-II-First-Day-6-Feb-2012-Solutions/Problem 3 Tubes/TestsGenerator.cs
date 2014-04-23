using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Problem_3_Tubes
{
    public static class TestsGenerator
    {
        public static Random rand = new Random();

        public static void GenerateTests()
        {
            List<Tuple<int, int, int>> TestsNMValues = new List<Tuple<int, int, int>>();
            TestsNMValues.Add(new Tuple<int, int, int>(10, 10, 2000000000)); // 1
            TestsNMValues.Add(new Tuple<int, int, int>(1, 10, 2000000000)); // 2
            TestsNMValues.Add(new Tuple<int, int, int>(100, 123, 2000000000)); // 3
            TestsNMValues.Add(new Tuple<int, int, int>(500, 1234, 2000000000)); // 4
            TestsNMValues.Add(new Tuple<int, int, int>(1000, 12345, 2000000000)); // 5
            TestsNMValues.Add(new Tuple<int, int, int>(2000, 12345, 2000000000)); // 6
            TestsNMValues.Add(new Tuple<int, int, int>(5000, 12345, 2000000000)); // 7
            TestsNMValues.Add(new Tuple<int, int, int>(8000, 12345, 2000000000)); // 8
            TestsNMValues.Add(new Tuple<int, int, int>(9002, 123451345, 2000000000)); // 9
            TestsNMValues.Add(new Tuple<int, int, int>(10003, 123451, 2000000000)); // 10
            TestsNMValues.Add(new Tuple<int, int, int>(12004, 12345, 2000000000)); // 11
            TestsNMValues.Add(new Tuple<int, int, int>(15005, 12345, 2000000000)); // 12
            TestsNMValues.Add(new Tuple<int, int, int>(18008, 12345, 2000000000)); // 13
            TestsNMValues.Add(new Tuple<int, int, int>(19009, 12345, 2000000000)); // 14
            TestsNMValues.Add(new Tuple<int, int, int>(20000, 20000000, 20000)); // 15
            TestsNMValues.Add(new Tuple<int, int, int>(20000, 10000, 2000000000)); // 16
            TestsNMValues.Add(new Tuple<int, int, int>(20000, 20000, 2000000000)); // 17
            TestsNMValues.Add(new Tuple<int, int, int>(20000, 20000, 2000000000)); // 18
            TestsNMValues.Add(new Tuple<int, int, int>(20000, 100000, 2000000000)); // 19
            TestsNMValues.Add(new Tuple<int, int, int>(20000, 1000000, 2000000000)); // 20
            
            for (int j = 1; j <= TestsNMValues.Count; j++)
            {
                Tuple<int, int, int> testParams = TestsNMValues[j - 1];
                StreamWriter sw;
                using (sw = new StreamWriter(string.Format("test.{0:000}.in.txt", j)))
                {
                    sw.AutoFlush = true;
                    sw.WriteLine(testParams.Item1);
                    sw.WriteLine(testParams.Item2);
                    for (int i = 1; i <= testParams.Item1; i++)
                    {
                        sw.WriteLine(rand.Next(1, testParams.Item3 + 1));
                    }
                    sw.Flush();
                }
                sw.Close();
            }
        }
    }
}
