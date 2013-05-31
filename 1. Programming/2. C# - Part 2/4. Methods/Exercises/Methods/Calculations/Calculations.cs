using System;

class Calculations
{
    //generic method for minimum value
    static T Minimum<T>(T[] array) where T : System.IComparable<T>
    {

        T minValue = array[0];
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].CompareTo(minValue) < minValue.CompareTo(minValue))
            {
                minValue = array[i];
            }
        }
        return minValue;
    }

    //generic method for maximum value
    static T Maximum<T>(T[] array) where T : System.IComparable<T>
    {

        T maxValue = array[0];
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].CompareTo(maxValue) > maxValue.CompareTo(maxValue))
            {
                maxValue = array[i];
            }
        }
        return maxValue;
    }

    //generic method for average value
    static decimal Average<T>(T[] array) where T : System.IComparable<T>
    {
        int lenght = array.Length;
        decimal sum = Sum(array);
        sum /= lenght;
        return sum;
    }

    //generic method for sum value
    static decimal Sum<T>(T[] array) where T : System.IComparable<T>
    {
        decimal sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += (decimal)Convert.ChangeType(array[i], typeof(Decimal));
        }
        return sum;
    }

    //generic method for multiply value
    static decimal Product<T>(T[] array) where T : System.IComparable<T>
    {
        decimal product = 1;
        for (int i = 0; i < array.Length; i++)
        {
            product *= (decimal)Convert.ChangeType(array[i], typeof(Decimal));
        }
        return product;
    }

    static void Main()
    {
        //input data
        int[] intOfNumbers = { 1, 2, 5, -7, 3, 4 };
        double[] doubleOfNumbers = { 1.6, 2.3, 5.8, -7.2, 3.0, 4.5 };
        byte[] byteOfNumbers = { 1, 10, 56, 18, 20 };
        float[] floatOfNumbers = { 1.5f, 2.7f, 3.6f, 5.8f };
        decimal[] decimalOfNumbers = { 1.5m, 12.6m, 15.7m, 4.9m };

        //print results from methods
        Console.WriteLine(Minimum(intOfNumbers));
        Console.WriteLine(Maximum(byteOfNumbers));
        Console.WriteLine(Average(doubleOfNumbers));
        Console.WriteLine(Sum(floatOfNumbers));
        Console.WriteLine(Product(decimalOfNumbers));
    }
}
