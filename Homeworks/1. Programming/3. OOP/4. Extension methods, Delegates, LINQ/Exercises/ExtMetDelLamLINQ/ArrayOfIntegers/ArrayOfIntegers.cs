using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayOfIntegers
{
    class ArrayOfIntegers
    {
        //06. Write a program that prints from given array of integers 
        //all numbers that are divisible by 7 and 3. Use the built-in 
        //extension methods and lambda expressions. Rewrite the same with LINQ.

        static void Main()
        {
            List<int> array = new List<int>() { 21, 23, 31, 24, 56, 16, 42, 82, 39, 10, 18, 23, 84, 45, 51, 69, 72, 87, 9 };

            //lambda expression
            var queryDivisibleBy7And3 = array.FindAll(number => (number % 3 == 0) && (number % 7 == 0));

            //print
            foreach (var number in queryDivisibleBy7And3)
            {
                Console.WriteLine(number);
            }

            //LINQ
            var queryWithLINQ =
                from number in array
                where number % 3 == 0 && number % 7 == 0
                select number;

            //printing
            foreach (var number in queryWithLINQ)
            {
                Console.WriteLine(number);
            }
        }
    }
}
