using System;

class Sequence
{
    static void Main()
    {
        for (int i = 1; i <= 10; i++)
        {
            if (i % 2 == 0)
            {
                if (i == 10)
                {
                    Console.WriteLine("-{0}...", (i + 1));
                }
                else
                {
                    Console.Write("-{0}, ", (i + 1));
                }
            }
            else
            {
                Console.Write("{0}, ", (i + 1));
            }
        }
    }
}

