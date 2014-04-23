using System;

class LeastMajorityMultiple
{
    static void Main()
    {
        string readStr = Console.ReadLine();
        byte a = byte.Parse(readStr);
        readStr = Console.ReadLine();
        byte b = byte.Parse(readStr);
        readStr = Console.ReadLine();
        byte c = byte.Parse(readStr);
        readStr = Console.ReadLine();
        byte d = byte.Parse(readStr);
        readStr = Console.ReadLine();
        byte e = byte.Parse(readStr);
        int leastMajorityMultiple = int.MaxValue;
        for (int i = 1; i < 1000000; i++)
        {
            if (i % a == 0 && i % b == 0 && i % c == 0)
            {
                if (i < leastMajorityMultiple)
                {
                    leastMajorityMultiple = i;
                }
            }
            if (i % a == 0 && i % b == 0 && i % d == 0)
            {
                if (i < leastMajorityMultiple)
                {
                    leastMajorityMultiple = i;
                }
            }
            if (i % a == 0 && i % b == 0 && i % e == 0)
            {
                if (i < leastMajorityMultiple)
                {
                    leastMajorityMultiple = i;
                }
            }
            if (i % a == 0 && i % c == 0 && i % d == 0)
            {
                if (i < leastMajorityMultiple)
                {
                    leastMajorityMultiple = i;
                }
            }
            if (i % a == 0 && i % c == 0 && i % e == 0)
            {
                if (i < leastMajorityMultiple)
                {
                    leastMajorityMultiple = i;
                }
            }
            if (i % a == 0 && i % d == 0 && i % e == 0)
            {
                if (i < leastMajorityMultiple)
                {
                    leastMajorityMultiple = i;
                }
            }
            if (i % b == 0 && i % c == 0 && i % d == 0)
            {
                if (i < leastMajorityMultiple)
                {
                    leastMajorityMultiple = i;
                }
            }
            if (i % b == 0 && i % c == 0 && i % e == 0)
            {
                if (i < leastMajorityMultiple)
                {
                    leastMajorityMultiple = i;
                }
            }
            if (i % b == 0 && i % d == 0 && i % e == 0)
            {
                if (i < leastMajorityMultiple)
                {
                    leastMajorityMultiple = i;
                }
            }
            if (i % c == 0 && i % d == 0 && i % e == 0)
            {
                if (i < leastMajorityMultiple)
                {
                    leastMajorityMultiple = i;
                }
            }
            if (leastMajorityMultiple != int.MaxValue)
            {
                Console.WriteLine(leastMajorityMultiple);
                break;
            }
        }
    }
}
