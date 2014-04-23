using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Globalization;

class Cooking
{
    //BGCoder: 15/100

    static List<decimal> quantity = new List<decimal>();
    static List<string> units = new List<string>();
    static List<string> products = new List<string>();

    static decimal ConverterToMLS(decimal quantity, string units)
    {
        switch (units)
        {
            case "milliliters":
            case "mls": return quantity;
            case "tablespoons":
            case "tbsps": return quantity * 15;
            case "liters":
            case "ls": return quantity * 1000;
            case "fluid ounces":
            case "fl ozs": return quantity * 30;
            case "teaspoons":
            case "tsps": return quantity * 5;
            case "gallons":
            case "gals": return quantity * 3840;
            case "pints":
            case "pts": return quantity * 480;
            case "quarts":
            case "qts": return quantity * 960;
            case "cups": return quantity * 240;
        }
        return 99999999999;
    }

    static decimal ConverterToUnits(decimal quantity, string units)
    {
        switch (units)
        {
            case "milliliters":
            case "mls": return quantity;
            case "tablespoons":
            case "tbsps": return quantity / 15;
            case "liters":
            case "ls": return quantity / 1000;
            case "fluid ounces":
            case "fl ozs": return quantity / 30;
            case "teaspoons":
            case "tsps": return quantity / 5;
            case "gallons":
            case "gals": return quantity / 3840;
            case "pints":
            case "pts": return quantity / 480;
            case "quarts":
            case "qts": return quantity / 960;
            case "cups": return quantity / 240;
        }
        return 99999999999;
    }

    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        int N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            string[] line = Console.ReadLine().Split(':');

            bool isHere = false;
            int indexProduct = 0;

            for (int j = 0; j < products.Count; j++)
            {
                if (string.Compare(products[j], line[2], true) == 0)
                {
                    isHere = true;
                    indexProduct = j;
                    break;
                }
            }

            if (isHere)
            {
                decimal ammount = decimal.Parse(line[0]);
                ammount = ConverterToMLS(ammount, line[1]);
                ammount = ConverterToUnits(ammount, units[indexProduct]);
                quantity[indexProduct] += ammount;
            }
            else
            {
                quantity.Add(decimal.Parse(line[0]));
                units.Add(line[1]);
                products.Add(line[2]);
            }
        }

        int M = int.Parse(Console.ReadLine());
        List<decimal> usedQuantity = new List<decimal>();
        List<string> usedUnits = new List<string>();
        List<string> usedProducts = new List<string>();

        StringBuilder output = new StringBuilder();

        for (int i = 0; i < M; i++)
        {
            string[] line = Console.ReadLine().Split(':');

            bool isHere = false;
            int indexProduct = 0;

            for (int j = 0; j < usedProducts.Count; j++)
            {
                if (string.Compare(usedProducts[j], line[2], true) == 0)
                {
                    isHere = true;
                    indexProduct = j;
                    break;
                }
            }

            if (isHere)
            {
                decimal ammount = decimal.Parse(line[0]);
                ammount = ConverterToMLS(ammount, line[1]);
                ammount = ConverterToUnits(ammount, usedUnits[indexProduct]);
                usedQuantity[indexProduct] += ammount;
            }
            else
            {
                usedQuantity.Add(decimal.Parse(line[0]));
                usedUnits.Add(line[1]);
                usedProducts.Add(line[2]);
            }
        }

        for (int i = 0; i < products.Count; i++)
        {
            bool isHere = false;
            int indexProduct = 0;

            for (int j = 0; j < usedProducts.Count; j++)
            {
                if (string.Compare(products[i], usedProducts[j], true) == 0)
                {
                    isHere = true;
                    indexProduct = j;
                    break;
                }
            }

            if (isHere)
            {
                decimal ammount = ConverterToMLS(usedQuantity[indexProduct], usedUnits[indexProduct]);
                ammount = ConverterToUnits(ammount, units[i]);

                if (quantity[i] - ammount > 0)
                {
                    output.Append(string.Format("{0:F2}:{1}:{2}\n\r", quantity[i] - ammount, units[i], products[i]));
                }
            }
            else
            {
                output.Append(string.Format("{0:F2}:{1}:{2}\n\r", quantity[i], units[i], products[i]));
            }
        }

        string finalOutput = output.ToString().Remove(output.Length - 2);

        Console.WriteLine();

        Console.WriteLine(finalOutput);
    }
}
