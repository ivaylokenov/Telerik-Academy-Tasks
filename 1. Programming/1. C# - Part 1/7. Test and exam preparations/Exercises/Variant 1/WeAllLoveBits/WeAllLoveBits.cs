using System;

class WeAllLoveBits
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        

        for (int i = 0; i < N; i++)
        {
            int P = int.Parse(Console.ReadLine());
            int Pnew = 0;
            while (P > 0)
            {
                Pnew <<= 1;
                if ((P & 1) == 1)
                {
                    Pnew |= 1;
                }
                P >>= 1;
            }

            Console.WriteLine(Pnew);
        }
        
    }
}
