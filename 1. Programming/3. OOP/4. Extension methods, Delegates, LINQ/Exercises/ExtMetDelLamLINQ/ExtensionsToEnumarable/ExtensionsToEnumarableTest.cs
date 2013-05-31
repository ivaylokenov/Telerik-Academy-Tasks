using System;
using System.Collections.Generic;

namespace ExtensionsToEnumarable
{
    class ExtensionsToEnumarableTest
    {
        //2. Implement a set of extension methods for IEnumerable<T> 
        //that implement the following group functions:
        //sum, product, min, max, average.

        static void Main()
        {
            //this class is for testing purposes
            List<int> testList = new List<int>();

            testList.Add(1);
            testList.Add(2);
            testList.Add(3);
            testList.Add(4);

            Console.WriteLine(testList.Min());
            Console.WriteLine(testList.Max());
            Console.WriteLine(testList.Product());
            Console.WriteLine(testList.Sum());
            Console.WriteLine(testList.Average());
        }
    }
}
