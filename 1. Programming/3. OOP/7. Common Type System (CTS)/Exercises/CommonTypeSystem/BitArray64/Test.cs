using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitArray
{
    class Test
    {
        static void Main()
        {
            BitArray64 number = new BitArray64(43);

            //check bits property
            int[] bits = number.Bits;

            for (int i = 0; i < bits.Length; i++)
            {
                Console.Write(bits[i]);
            }

            Console.WriteLine();

            //test enumerator
            foreach (var item in number)
            {
                Console.Write(item);
            }

            Console.WriteLine();

            //check indexator
            Console.WriteLine(number[0]);
            Console.WriteLine(number[63]);
        }
    }
}
