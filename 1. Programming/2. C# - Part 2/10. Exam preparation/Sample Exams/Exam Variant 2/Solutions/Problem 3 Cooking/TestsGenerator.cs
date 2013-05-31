using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Problem_3_Cooking
{
    public static class TestsGenerator
    {
        private static Random rand = new Random();
        private static string[] units = new string[]
        {
            "tablespoons",
            "tbsps",
            "teaspoons",
            "tsps",
            "milliliters",
            "mls",
            "liters",
            "ls",
            "fluid ounces",
            "fl ozs",
            "pints",
            "pts",
            "quarts",
            "qts",
            "gallons",
            "gals",
            "cups",
        };

        public static void GenerateTests()
        {
            List<Tuple<int, int>> testsNandM = new List<Tuple<int, int>>();
            testsNandM.Add(new Tuple<int, int>(1, 1)); // 1
            testsNandM.Add(new Tuple<int, int>(1, 1)); // 2
            testsNandM.Add(new Tuple<int, int>(20, 1000)); // 3
            testsNandM.Add(new Tuple<int, int>(1000, 20)); // 4
            testsNandM.Add(new Tuple<int, int>(50, 50)); // 5
            testsNandM.Add(new Tuple<int, int>(100, 100)); // 6
            testsNandM.Add(new Tuple<int, int>(150, 500)); // 7
            testsNandM.Add(new Tuple<int, int>(500, 150)); // 8
            testsNandM.Add(new Tuple<int, int>(500, 500)); // 9
            testsNandM.Add(new Tuple<int, int>(550, 555)); // 10
            testsNandM.Add(new Tuple<int, int>(555, 555)); // 11
            testsNandM.Add(new Tuple<int, int>(555, 666)); // 12
            testsNandM.Add(new Tuple<int, int>(600, 800)); // 13
            testsNandM.Add(new Tuple<int, int>(756, 876)); // 14
            testsNandM.Add(new Tuple<int, int>(899, 901)); // 15
            testsNandM.Add(new Tuple<int, int>(950, 950)); // 16
            testsNandM.Add(new Tuple<int, int>(1000, 1)); // 17
            testsNandM.Add(new Tuple<int, int>(1, 1000)); // 18
            testsNandM.Add(new Tuple<int, int>(998, 999)); // 19
            testsNandM.Add(new Tuple<int, int>(1000, 1000)); // 20

            for (int i = 0; i < testsNandM.Count; i++)
            {
                Tuple<int, int> test = testsNandM[i];
                Console.WriteLine("Generating test {0}: {1}", i + 1, test);
                int items = test.Item1 + test.Item2;
                List<string> productNames = new List<string>();
                for (int j = 1; j <= items; j++)
                {
                    productNames.Add(GetRandomName());
                }

                using (StreamWriter sw = new StreamWriter(string.Format("test.{0:000}.in.txt", i + 1)))
                {
                    sw.WriteLine(test.Item1);
                    for (int j = 1; j <= test.Item1; j++)
                    {
                        string name = productNames[rand.Next(0, productNames.Count)];
                        string unit = units[rand.Next(0, units.Length)];
                        sw.WriteLine("{0}:{1}:{2}", rand.Next(1, 1250000) / 10.0M, unit, name);
                    }

                    sw.WriteLine(test.Item2);
                    for (int j = 1; j <= test.Item2; j++)
                    {
                        string name = productNames[rand.Next(0, productNames.Count)];
                        string unit = units[rand.Next(0, units.Length)];
                        sw.WriteLine("{0}:{1}:{2}", rand.Next(1, 1250000) / 10.0M, unit, name);
                    }
                }
            }
        }

        private static string GetRandomName()
        {
            string chars = "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int len = rand.Next(1, 50);
            StringBuilder sb = new StringBuilder(len);
            for (int i = 1; i <= len; i++)
            {
                sb.Append(chars[rand.Next(0, chars.Length)]);
            }
            return sb.ToString().Trim();
        }
    }
}
