using System;
using System.Text;

namespace StringBuilderSubstring
{
    //1. Implement an extension method Substring(int index, int length) 
    //for the class StringBuilder that returns new StringBuilder 
    //and has the same functionality as Substring in the class String.

    class StringBuilderSubstringTest
    {
        static void Main()
        {
            //testing class
            StringBuilder test = new StringBuilder();
            test.Append("abcdef");
            Console.WriteLine(test.Substring(1,4).ToString());
        }
    }
}
