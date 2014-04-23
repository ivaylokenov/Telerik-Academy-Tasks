namespace SortingDiagnostics
{
    using System;
    using System.Diagnostics;
    using System.Collections.Generic;

    class SortingDiagnostics
    {
        //selection sort
        static void SelectionSort(int[] array)
        {
            int minimumValue;

            for (int i = 0; i < array.Length - 1; i++)
            {
                minimumValue = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minimumValue])
                    {
                        minimumValue = j;
                    }
                }

                if (minimumValue != i)
                {
                    int temporaryVariable = array[minimumValue];
                    array[minimumValue] = array[i];
                    array[i] = temporaryVariable;
                }
            }
        }

        //merge sort
        static int[] MergeArrays(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];

            int leftIncrease = 0;
            int rightIncrease = 0;

            for (int i = 0; i < result.Length; i++)
            {
                if (rightIncrease == right.Length || ((leftIncrease < left.Length) && (left[leftIncrease] <= right[rightIncrease])))
                {
                    result[i] = left[leftIncrease];
                    leftIncrease++;
                }
                else if (leftIncrease == left.Length || ((rightIncrease < right.Length) && (right[rightIncrease] <= left[leftIncrease])))
                {
                    result[i] = right[rightIncrease];
                    rightIncrease++;
                }
            }

            return result;
        }

        //recursevily merges two arrays
        static int[] MergeSort(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }

            int middle = array.Length / 2;
            int[] leftArray = new int[middle];
            int[] rightArray = new int[array.Length - middle];

            for (int i = 0; i < middle; i++)
            {
                leftArray[i] = array[i];
            }

            for (int i = middle, j = 0; i < array.Length; i++, j++)
            {
                rightArray[j] = array[i];
            }

            leftArray = MergeSort(leftArray);
            rightArray = MergeSort(rightArray);

            return MergeArrays(leftArray, rightArray);
        }

        //quick sort
        static List<int> QuickSort(List<int> array)
        {
            if (array.Count <= 1)
            {
                return array;
            }

            int pivot = array[array.Count / 2];
            List<int> less = new List<int>();
            List<int> greater = new List<int>();

            for (int i = 0; i < array.Count; i++)
            {
                if (i != (array.Count / 2))
                {
                    if (array[i] <= pivot)
                    {
                        less.Add(array[i]);
                    }
                    else
                    {
                        greater.Add(array[i]);
                    }
                }
            }

            return ConcatenateArrays(QuickSort(less), pivot, QuickSort(greater));
        }

        static List<int> ConcatenateArrays(List<int> less, int pivot, List<int> greater)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < less.Count; i++)
            {
                result.Add(less[i]);
            }

            result.Add(pivot);

            for (int i = 0; i < greater.Count; i++)
            {
                result.Add(greater[i]);
            }

            return result;
        }

        static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();

            //random numbers case
            Console.WriteLine("Random numbers diagnostics");

            int[] array = new int[] { 4, 15983, 5, 6, -349, 2, 3, 4, - 5, 5, -6, 0, -9, -10, 11, 21214, - 1, 14, -5465 };
            stopwatch.Start();
            SelectionSort(array);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Selection sort");

            array = new int[] { 4, 15983, 5, 6, -349, 2, 3, 4, -5, 5, -6, 0, -9, -10, 11, 21214, -1, 14, -5465 };
            stopwatch.Restart();
            MergeSort(array);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Merge sort");

            List<int> list = new List<int>() { 4, 15983, 5, 6, -349, 2, 3, 4, -5, 5, -6, 0, -9, -10, 11, 21214, -1, 14, -5465 };
            stopwatch.Restart();
            QuickSort(list);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Quick sort");

            //sorted numbers case
            Console.WriteLine("\n\rSorted numbers diagnostics");
            array = MergeSort(array);
            list = QuickSort(list);

            stopwatch.Restart();
            SelectionSort(array);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Selection sort");

            stopwatch.Restart();
            MergeSort(array);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Merge sort");

            stopwatch.Restart();
            QuickSort(list);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Quick sort");

            //values sorted in reverse order
            Console.WriteLine("\n\rReverse sorted numbers diagnostics");

            Array.Reverse(array);
            stopwatch.Restart();
            SelectionSort(array);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Selection sort");

            Array.Reverse(array);
            stopwatch.Restart();
            MergeSort(array);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Merge sort");

            list = QuickSort(list);
            list.Reverse();
            stopwatch.Restart();
            QuickSort(list);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Quick sort");
        }
    }
}
