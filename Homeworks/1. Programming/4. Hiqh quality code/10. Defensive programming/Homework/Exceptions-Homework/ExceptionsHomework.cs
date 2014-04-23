using System;
using System.Collections.Generic;
using System.Text;

class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        List<T> result = new List<T>();

        if (startIndex < 0 || startIndex >= arr.Length)
        {
            throw new ArgumentException("Start index must be in the array!");
        }

        if (count < 0)
        {
            throw new ArgumentException("Count must be positive number!");
        }

        if (startIndex + count > arr.Length)
        {
            throw new ArgumentException("Start index + count must be less than the length of the array!");
        }

        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }
        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (str == null || str == string.Empty)
        {
            throw new ArgumentException("String cannot be null or empty!");
        }

        if (count < 0)
        {
            throw new ArgumentException("Count must be positive or zero!");
        }

        if (count > str.Length)
        {
            throw new ArgumentException("Count must be less than the length of the string!");
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }
        return result.ToString();
    }

    //this method should return bool not throw exception
    public static bool CheckPrime(int number)
    {
        if (number <= 0)
        {
            throw new ArgumentException("Number must be positive number!");
        }

        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }

    static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(String.Join(" ", subarr));

        var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(String.Join(" ", allarr));

        var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(String.Join(" ", emptyarr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));
        Console.WriteLine(ExtractEnding("Hi", 2));

        Console.WriteLine("23 is prime: " + CheckPrime(23));

        Console.WriteLine("33 is prime: " + CheckPrime(33));

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
