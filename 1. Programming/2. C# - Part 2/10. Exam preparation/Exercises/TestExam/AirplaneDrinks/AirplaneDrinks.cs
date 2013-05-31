using System;
using System.Collections.Generic;
using System.Text;

class AirplaneDrinks
{
    //BGCoder: 10/100

    static long numberOfSeats = int.Parse(Console.ReadLine());
    static char[] seatDrinks = new char[numberOfSeats];
    static long totalTime = 0;

    static void Main()
    {
        int numberOfTeas = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfTeas; i++)
        {
            seatDrinks[int.Parse(Console.ReadLine()) - 1] = 'T';
        }

        for (long i = 0; i < numberOfSeats; i++)
        {
            if (seatDrinks[i] != 'T')
            {
                seatDrinks[i] = 'C';
            }
        }

        int teaRefills = 0;
        if (numberOfTeas % 7 == 0)
        {
            teaRefills = numberOfTeas / 7;
        }
        else
        {
            teaRefills = numberOfTeas / 7 + 1;
        }

        long coffeeRefills = 0;
        if ((numberOfSeats - numberOfTeas) % 7 == 0)
        {
            coffeeRefills = (numberOfSeats - numberOfTeas) / 7;
        }
        else
        {
            coffeeRefills = (numberOfSeats - numberOfTeas) / 7 + 1;
        }
         

        long refills = (teaRefills + coffeeRefills) * 47;
        long servings = numberOfSeats * 4;

        totalTime += refills;
        totalTime += servings;

        //find last tea
        long lastTea = Array.LastIndexOf(seatDrinks, 'T');

        int counter = 0;
        long totalCounter = 0;

        for (int i = 0; i <= lastTea; i++)
        {
            if (seatDrinks[i] == 'T')
            {
                counter++;
            }

            if (counter == 7)
            {
                totalTime += (i + 1) * 2;
                counter = 0;
            }

            if (i == lastTea)
            {
                totalTime += (i + 1) * 2;
            }
        }

        //find last coffee
        long lastCoffee = Array.LastIndexOf(seatDrinks, 'C');

        counter = 0;

        for (int i = 0; i <= lastCoffee; i++)
        {
            if (seatDrinks[i] == 'C')
            {
                counter++;
            }

            if (counter == 7 || lastCoffee == i)
            {
                totalTime += (i + 1) * 2;
                counter = 0;
            }
        }

        Console.WriteLine(totalTime);
    }
}
