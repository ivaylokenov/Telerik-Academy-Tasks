using System;
using System.Linq;
using System.Diagnostics;

class AssertionsHomework
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        for (int index = 0; index < arr.Length-1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }
        
        //Assertion for sorted array
        for (int i = 1; i < arr.Length; i++)
        {
            Debug.Assert(arr[i].CompareTo(arr[i - 1]) >= 0, "Array is not sorted after trying to sort it!");
        }
    }
  
    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        //assertiont for start index bigger than end index
        Debug.Assert(arr != null, "Array should not be null or empty!");
        Debug.Assert(startIndex >= 0, "Start index should be bigger or equal to zero!");
        Debug.Assert(endIndex >= 0, "End index should be bigger or equal to zero!");
        Debug.Assert(endIndex < arr.Length, "End index should be less than the length of the array!");
        Debug.Assert(startIndex <= endIndex, "Start index is bigger than end index!");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        //assertion for checking whether the min element is really the min element
        for (int i = startIndex + 1; i < endIndex; i++)
        {
            Debug.Assert(arr[minElementIndex].CompareTo(arr[i]) <= 0, "The element is not the minimum in the array!");
        }

        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array cannot be empty or null!");
        Debug.Assert(value != null, "Value cannot be null!");

        //Assertion for sorted array
        for (int i = 1; i < arr.Length; i++)
        {
            Debug.Assert(arr[i].CompareTo(arr[i - 1]) >= 0, "Array is not sorted. Binary search is not possible!");
        }

        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array cannot be empty or null!");
        Debug.Assert(value != null, "Value cannot be null!");
        Debug.Assert(startIndex >= 0, "Start index should be bigger or equal to zero!");
        Debug.Assert(endIndex >= 0, "End index should be bigger or equal to zero!");
        Debug.Assert(endIndex < arr.Length, "End index should be less than the length of the array!");
        Debug.Assert(startIndex <= endIndex, "Start index is bigger than end index!");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }
            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else 
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, -1, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }
}
