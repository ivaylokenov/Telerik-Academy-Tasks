// <copyright file="Statistics.cs" company="MyCompany">
//     Copyright MyCompany. All rights reserved.
// </copyright>
using System;

/// <summary>
/// This class prints statistics of a table.
/// </summary>
public class Statistics
{
    /// <summary>
    /// This method prints maximum value, minimum value and average of a table with numbers.
    /// </summary>
    /// <param name="statisticsTable">Table used as input data.</param>
    /// <param name="maximumLength">Amount of numbers to be used from the input data.</param>
    public void PrintStatistics(double[] statisticsTable, int maximumLength)
    {
        double maximumValue = double.MinValue;
        for (int i = 0; i < maximumLength; i++)
        {
            if (statisticsTable[i] > maximumValue)
            {
                maximumValue = statisticsTable[i];
            }
        }

        this.PrintMax(maximumValue);
        double minimumValue = double.MaxValue;
        for (int i = 0; i < maximumLength; i++)
        {
            if (statisticsTable[i] < minimumValue)
            {
                minimumValue = statisticsTable[i];
            }
        }

        this.PrintMin(minimumValue);

        double sumOfStatistics = 0;
        for (int i = 0; i < maximumLength; i++)
        {
            sumOfStatistics += statisticsTable[i];
        }

        this.PrintAvg(sumOfStatistics / maximumLength);
    }

    /// <summary>
    /// Prints average on the console.
    /// </summary>
    /// <param name="average">Input data to be printed.</param>
    private void PrintAvg(double average)
    {
        Console.WriteLine(average);
    }

    /// <summary>
    /// Prints minimum value on the console.
    /// </summary>
    /// <param name="minimum">Input data to be printed.</param>
    private void PrintMin(double minimum)
    {
        Console.WriteLine(minimum);
    }

    /// <summary>
    /// Prints maximum value on the console.
    /// </summary>
    /// <param name="maximum">Input data to be printed.</param>
    private void PrintMax(double maximum)
    {
        Console.WriteLine(maximum);
    }
}