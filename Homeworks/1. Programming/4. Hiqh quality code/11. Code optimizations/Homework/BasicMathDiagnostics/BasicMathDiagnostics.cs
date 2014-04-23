namespace BasicMathDiagnostics
{
    using System;
    using System.Diagnostics;

    class BasicMathDiagnostics
    {
        static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();

            //define variables
            int resultInt = 0;

            long resultLong = 0L;

            float resultFloat = 0.0F;

            double resultDouble = 0.0;

            decimal resultDecimal = 0.0M;

            //check sum
            Console.WriteLine("Sum diagnostics - sum of 10 000 numbers");

            stopwatch.Start();
            for (int i = 1; i <= 10000; i++)
            {
                stopwatch.Start();
                resultInt += i;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Int addition - " + resultInt);

            stopwatch.Restart();
            for (long i = 1L; i <= 10000L; i++)
            {
                resultLong += i;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Long addition - " + resultLong);

            stopwatch.Restart();
            for (float i = 0.0001F; i <= 1.0000F; i += 0.0001F)
            {
                resultFloat += i;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Float addition - " + resultFloat);

            stopwatch.Restart();
            for (double i = 0.0001; i <= 1.0000; i += 0.0001)
            {
                resultDouble += i;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Double addition - " + resultDouble);

            stopwatch.Restart();
            for (decimal i = 0.0001M; i <= 1.0000M; i += 0.0001M)
            {
                resultDecimal += i;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Decimal addition - " + resultDecimal);

            Console.WriteLine("\n\rSubstract diagnostics - substract 10 000 numbers");
            stopwatch.Restart();
            for (int i = 10000; i > 0; i--)
            {
                resultInt -= i;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Int substraction - " + resultInt);

            stopwatch.Restart();
            for (long i = 10000L; i > 0L; i--)
            {
                resultLong -= i;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Long substraction - " + resultLong);

            stopwatch.Restart();
            for (float i = 1.0000F; i > 0.0F; i -= 0.0001F)
            {
                resultFloat -= i;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Float substraction - " + resultFloat);

            stopwatch.Restart();
            for (double i = 1.0000; i > 0.0; i -= 0.0001)
            {
                resultDouble -= i;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Double substraction - " + resultDouble);

            stopwatch.Restart();
            for (decimal i = 1.0000M; i > 0.0M; i -= 0.0001M)
            {
                resultDecimal -= i;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Decimal substraction - " + resultDecimal);

            Console.WriteLine("\n\rIncrement diagnostics - increment 10 000 times");
            stopwatch.Restart();
            for (int i = 0; i < 10000; i++)
            {
                resultInt++;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Int increment - " + resultInt);

            stopwatch.Restart();
            for (int i = 0; i < 10000; i++)
            {
                resultLong++;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Long increment - " + resultLong);

            stopwatch.Restart();
            for (int i = 0; i < 10000; i++)
            {
                resultFloat++;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Float increment - " + resultFloat);

            stopwatch.Restart();
            for (int i = 0; i < 10000; i++)
            {
                resultDouble++;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Double increment - " + resultDouble);

            stopwatch.Restart();
            for (int i = 0; i < 10000; i++)
            {
                resultDecimal++;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Decimal increment - " + resultDecimal);

            Console.WriteLine("\n\rMultiplication diagnostics - multiply 10 times");
            resultInt = 1;
            stopwatch.Restart();
            for (int i = 1; i < 10; i++)
            {
                resultInt *= i;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Int multiply - " + resultInt);

            resultLong = 1;
            stopwatch.Restart();
            for (long i = 1L; i < 10L; i++)
            {
                resultLong *= i;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Long multiply - " + resultLong);

            resultFloat = 1.0F;
            stopwatch.Restart();
            for (float i = 0.1F; i < 1.0F; i += 0.1F)
            {
                resultFloat *= i;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Float multiply - " + resultFloat);

            resultDouble = 1.0;
            stopwatch.Restart();
            for (double i = 0.1; i < 1.0; i += 0.1)
            {
                resultDouble *= i;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Double multiply - " + resultDouble);

            resultDecimal = 1.0M;
            stopwatch.Restart();
            for (decimal i = 0.1M; i < 1.0M; i += 0.1M)
            {
                resultDecimal *= i;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Decimal multiply - " + resultDecimal);

            Console.WriteLine("\n\rDivision diagnostics - divide 10 times");
            stopwatch.Restart();
            for (int i = 1; i < 10; i++)
            {
                resultInt /= i;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Int divide - " + resultInt);

            stopwatch.Restart();
            for (long i = 1L; i < 10L; i++)
            {
                resultLong /= i;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Long divide - " + resultLong);

            stopwatch.Restart();
            for (float i = 0.1F; i < 1.0F; i += 0.1F)
            {
                resultFloat /= i;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Float divide - " + resultFloat);

            stopwatch.Restart();
            for (double i = 0.1; i < 1.0; i += 0.1)
            {
                resultDouble /= i;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Double divide - " + resultDouble);

            stopwatch.Restart();
            for (decimal i = 0.1M; i < 1.0M; i += 0.1M)
            {
                resultDecimal /= i;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Decimal divide - " + resultDecimal);
        }
    }
}
