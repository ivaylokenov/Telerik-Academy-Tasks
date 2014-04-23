using System;
using System.Linq;

class BinSearch
{
    static void Main()
    {
        //get data
        Console.Write("Enter N: ");
        int N = int.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        int K = int.Parse(Console.ReadLine());
        int[] array = new int[N];
        for (int i = 0; i < N; i++)
        {
            Console.Write("Enter element {0}: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        //sort array 
        Array.Sort(array);
        
        //start binary search for less than K
        int target = K;
        int result = 0;
        bool hasValue = true;
        while (true)
        {
            int index = Array.BinarySearch(array, target);
            if (index > 0)
            {
                result = array[index];
                break;
            }
            target--;
            if (target - K == -10000000)
            {
                hasValue = false;
                break;
            }
        }

        //print result
        if (hasValue)
        {
            Console.WriteLine("Result is: {0}.", result);
        }
        else
        {
            Console.WriteLine("There is no smaller number than K in your array.");
        }

    }
}
