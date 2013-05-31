using System;
using System.Collections.Generic;
using System.Text;

class GenomeDecoder
{
    static void Main()
    {
        //BGCoder: 80/100

        string[] NandM = Console.ReadLine().Split(' ');
        int N = int.Parse(NandM[0]);
        int M = int.Parse(NandM[1]);

        string encodedGenome = Console.ReadLine();

        string[] numbersFromGenome = encodedGenome.Split('A', 'C', 'G', 'T');

        List<int> numbers = new List<int>();

        for (int i = 0; i < numbersFromGenome.Length; i++)
		{
            int number;

            bool parseTry = int.TryParse(numbersFromGenome[i], out number);

            if (parseTry)
            {
                numbers.Add(number);
            }
            else
            {
                numbers.Add(1);
            }
		}

        StringBuilder decodedGenome = new StringBuilder();

        int counter = 0;

        for (int i = 0; i < encodedGenome.Length; i++)
        {
            if (encodedGenome[i] == 'A' || encodedGenome[i] == 'C' || encodedGenome[i] == 'G' || encodedGenome[i] == 'T')
            {
                int currentNumber = numbers[counter];

                for (int j = 0; j < currentNumber; j++)
                {
                    decodedGenome.Append(encodedGenome[i]);
                }

                counter++;
            }
        }

        string decodedGenomeString = decodedGenome.ToString();

        int spaceCounter = 0;
        int lineCounter = 1;
        int numberOfLines = 0;

        if (decodedGenomeString.Length % N == 0)
        {
            numberOfLines = decodedGenomeString.Length / N;
        }
        else
        {
            numberOfLines = decodedGenomeString.Length / N + 1;
        }

        StringBuilder lineNumbers = new StringBuilder();

        for (int i = 0; i < numberOfLines.ToString().Length - 1; i++)
        {
            lineNumbers.Append(" ");
        }

        Console.Write(lineNumbers.ToString() + lineCounter + " ");

        StringBuilder characters = new StringBuilder();

        for (int i = 0; i < decodedGenomeString.Length; i++)
        {
            if (i % N == 0 && i != 0)
            {
                Console.Write(characters.ToString());
                characters.Clear();
                Console.WriteLine();
                spaceCounter = 0;
                lineCounter++;
                lineNumbers.Clear();

                for (int j = 0; j < numberOfLines.ToString().Length - (lineCounter.ToString()).Length; j++)
                {
                    lineNumbers.Append(" ");
                }

                Console.Write(lineNumbers.ToString() + lineCounter + " ");
            }

            characters.Append(decodedGenomeString[i]);
            spaceCounter++;

            if (spaceCounter % M == 0 && i%N != N-1)
            {
                characters.Append(" ");
            }
        }

        Console.Write(characters.ToString());
    }
}
