using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Problem_3_Employees
{
    static class TestsGenerator
    {
        static Random rand = new Random();

        public static void GenerateTests()
        {
            List<Tuple<int, int>> TestsNMValues = new List<Tuple<int, int>>();
            TestsNMValues.Add(new Tuple<int, int>(1, 1)); // 1
            TestsNMValues.Add(new Tuple<int, int>(10, 15)); // 2
            TestsNMValues.Add(new Tuple<int, int>(40, 10)); // 3
            TestsNMValues.Add(new Tuple<int, int>(10, 40)); // 4
            TestsNMValues.Add(new Tuple<int, int>(50, 50)); // 5
            TestsNMValues.Add(new Tuple<int, int>(100, 100)); // 6
            TestsNMValues.Add(new Tuple<int, int>(200, 200)); // 7
            TestsNMValues.Add(new Tuple<int, int>(1000, 500)); // 8
            TestsNMValues.Add(new Tuple<int, int>(501, 1000)); // 9
            TestsNMValues.Add(new Tuple<int, int>(700, 700)); // 10
            TestsNMValues.Add(new Tuple<int, int>(750, 750)); // 11
            TestsNMValues.Add(new Tuple<int, int>(800, 800)); // 12
            TestsNMValues.Add(new Tuple<int, int>(909, 909)); // 13
            TestsNMValues.Add(new Tuple<int, int>(999, 950)); // 14
            TestsNMValues.Add(new Tuple<int, int>(950, 999)); // 15
            TestsNMValues.Add(new Tuple<int, int>(999, 999)); // 16
            TestsNMValues.Add(new Tuple<int, int>(1000, 999)); // 17
            TestsNMValues.Add(new Tuple<int, int>(999, 1000)); // 18
            TestsNMValues.Add(new Tuple<int, int>(1000, 1000)); // 19
            TestsNMValues.Add(new Tuple<int, int>(1000, 1000)); // 20

            for (int j = 1; j <= TestsNMValues.Count; j++)
            {
                Tuple<int, int> testParams = TestsNMValues[j - 1];

                // Generate
                List<Position> positions = new List<Position>();
                for (int i = 1; i <= testParams.Item1; i++)
                {
                    positions.Add(new Position(string.Format("{0} - {1}", GetRandomNameWithSpaces(), rand.Next(0, 10000))));
                }
                List<Employee> employees = new List<Employee>();
                for (int i = 1; i <= testParams.Item2; i++)
                {
                    employees.Add(new Employee(string.Format("{0} {1}", GetRandomName(), GetRandomName()), positions[rand.Next(0, positions.Count)]));
                }

                // Write
                using (StreamWriter sw = new StreamWriter(string.Format("test.{0:000}.in.txt", j)))
                {
                    sw.WriteLine(testParams.Item1);
                    foreach (var position in positions)
                    {
                        sw.WriteLine(string.Format("{0} - {1}", position.Name, position.Rating));
                    }
                    sw.WriteLine(testParams.Item2);
                    foreach (var employee in employees)
                    {
                        sw.WriteLine(string.Format("{0} {1} - {2}", employee.FirstName, employee.LastName, employee.Position.Name));
                    }
                }
            }
        }

        private static string GetRandomNameWithSpaces()
        {
            string chars = "abcdefghijklmnopqrstuvwxyz 0123456789 ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int len = rand.Next(1, 100);
            StringBuilder sb = new StringBuilder(len);
            for (int i = 1; i <= len; i++)
            {
                sb.Append(chars[rand.Next(0, chars.Length)]);
            }
            return sb.ToString();
        }

        private static string GetRandomName()
        {
            string chars = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int len = rand.Next(1, 100);
            StringBuilder sb = new StringBuilder(len);
            for (int i = 1; i <= len; i++)
            {
                sb.Append(chars[rand.Next(0, chars.Length)]);
            }
            return sb.ToString();
        }
    }
}
