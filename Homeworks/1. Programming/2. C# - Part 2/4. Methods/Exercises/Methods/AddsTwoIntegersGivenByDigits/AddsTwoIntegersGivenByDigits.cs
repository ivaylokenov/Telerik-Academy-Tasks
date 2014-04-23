using System;

class AddsTwoIntegersGivenByDigits
{
    //sums two integers given by arrays of digits. returns string because of huge number of digits
    static string SumOfArrays(int[] firstArray, int[] secondArray)
    {
        //checks which array has smaller lenght
        int[] smallerArray;
        int[] biggerArray;
        if (firstArray.Length < secondArray.Length)
        {
            smallerArray = firstArray;
            biggerArray = secondArray;
        }
        else
        {
            smallerArray = secondArray;
            biggerArray = firstArray;
        }

        //sums the digits one by one
        for (int i = 0; i < smallerArray.Length; i++)
        {
            biggerArray[i] = firstArray[i] + secondArray[i];

            if (biggerArray[i] > 9 && i != (biggerArray.Length - 1))
            {
                int value = biggerArray[i] % 10;
                biggerArray[i] = value;
                biggerArray[i + 1] += 1;
            }
        }

        //reverses the array to get the correct order of digits and returns the result
        string result = "";
        Array.Reverse(biggerArray);
        foreach (var ch in biggerArray)
        {
            result += ch;
        }

        return result;
    }

    static void Main()
    {
        //number 1521
        int[] firstNumber = { 1, 2, 5, 1};

        //number 654
        int[] secondNumber = { 4, 5, 6};

        Console.WriteLine(SumOfArrays(firstNumber, secondNumber));
    }
}
