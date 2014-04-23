using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_1_Genome_Decoder
{
    class Program
    {
        static void Main()
        {
            string NandM = Console.ReadLine();
            string[] NandMParts = NandM.Split(' ');
            int N = int.Parse(NandMParts[0]);
            int M = int.Parse(NandMParts[1]);
            string genomeEncoded = Console.ReadLine();

            // Decode
            StringBuilder genome = new StringBuilder();
            int number = 0;
            for (int i = 0; i < genomeEncoded.Length; i++)
            {
                if (char.IsDigit(genomeEncoded[i]))
                {
                    number = number * 10 + (genomeEncoded[i] - '0');
                }
                else
                {
                    if (number == 0) number = 1;
                    genome.Append(new string(genomeEncoded[i], number));
                    number = 0;
                }
            }

            // Output
            int maxRowNumber = (int)Math.Ceiling((decimal)genome.Length / (decimal)N);
            int padSize = maxRowNumber.ToString().Length;
            for (int i = 1; i <= maxRowNumber; i++)
            {
                StringBuilder line = new StringBuilder();
                line.Append(new string(' ', padSize - i.ToString().Length));
                line.Append(i);
                for (int j = (i - 1) * N; j <= i * N  - 1; j++)
                {
                    if ((j - (i - 1) * N) % M == 0) line.Append(' ');
                    if (j >= genome.Length) break;
                    line.Append(genome[j]);
                }
                Console.WriteLine(line.ToString());
            }
        }
    }
}
