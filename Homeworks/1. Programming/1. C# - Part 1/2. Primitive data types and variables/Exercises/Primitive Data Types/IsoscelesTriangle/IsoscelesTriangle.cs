using System;

    class IsoscelesTriangle
    {
        static void Main()
        {
            char copy = '\u00A9';
            for (int i = 0; i < 3; i++)
			{
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(copy);
                }
                Console.WriteLine();
			}
            for (int k = 2; k > 0; k--)
            {
                for (int g = k; g > 0; g--)
                {
                    Console.Write(copy);
                }
                Console.WriteLine();
            }
        }
    }
