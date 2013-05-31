using System;

namespace Problem_5_Fall_Down
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the input numbers
            int num0 = int.Parse(Console.ReadLine());
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int num4 = int.Parse(Console.ReadLine());
            int num5 = int.Parse(Console.ReadLine());
            int num6 = int.Parse(Console.ReadLine());
            int num7 = int.Parse(Console.ReadLine());

            for (int count = 1; count <= 7; count++)
            {
                for (int bit = 0; bit <= 7; bit++)
                {
                    if ((num7 >> bit & 1) == 0 &&
                        (num6 >> bit & 1) == 1)
                    {
                        num7 |= (1 << bit);
                        num6 &= ~(1 << bit);
                    }
                }

                for (int bit = 0; bit <= 7; bit++)
                {
                    if ((num6 >> bit & 1) == 0 &&
                        (num5 >> bit & 1) == 1)
                    {
                        num6 |= (1 << bit);
                        num5 &= ~(1 << bit);
                    }
                }

                for (int bit = 0; bit <= 7; bit++)
                {
                    if ((num5 >> bit & 1) == 0 &&
                        (num4 >> bit & 1) == 1)
                    {
                        num5 |= (1 << bit);
                        num4 &= ~(1 << bit);
                    }
                }

                for (int bit = 0; bit <= 7; bit++)
                {
                    if ((num4 >> bit & 1) == 0 &&
                        (num3 >> bit & 1) == 1)
                    {
                        num4 |= (1 << bit);
                        num3 &= ~(1 << bit);
                    }
                }

                for (int bit = 0; bit <= 7; bit++)
                {
                    if ((num3 >> bit & 1) == 0 &&
                        (num2 >> bit & 1) == 1)
                    {
                        num3 |= (1 << bit);
                        num2 &= ~(1 << bit);
                    }
                }

                for (int bit = 0; bit <= 7; bit++)
                {
                    if ((num2 >> bit & 1) == 0 &&
                        (num1 >> bit & 1) == 1)
                    {
                        num2 |= (1 << bit);
                        num1 &= ~(1 << bit);
                    }
                }

                for (int bit = 0; bit <= 7; bit++)
                {
                    if ((num1 >> bit & 1) == 0 &&
                        (num0 >> bit & 1) == 1)
                    {
                        num1 |= (1 << bit);
                        num0 &= ~(1 << bit);
                    }
                }
            }

            Console.WriteLine(num0);
            Console.WriteLine(num1);
            Console.WriteLine(num2);
            Console.WriteLine(num3);
            Console.WriteLine(num4);
            Console.WriteLine(num5);
            Console.WriteLine(num6);
            Console.WriteLine(num7);
        }
    }
}
