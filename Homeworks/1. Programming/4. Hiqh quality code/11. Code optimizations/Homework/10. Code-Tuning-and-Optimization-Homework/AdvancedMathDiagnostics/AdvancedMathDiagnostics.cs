namespace AdvancedMathDiagnostics
{
    using System;
    using System.Diagnostics;

    class AdvancedMathDiagnostics
    {
        static void Main()
        {
            float resultFloat = 0.0F;

            double resultDouble = 0.0;

            decimal resultDecimal = 0.0M;

            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("Square root diagnostics");

            stopwatch.Start();
            resultFloat = (float)Math.Sqrt(1234567.123456f);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Float - " + resultFloat);

            stopwatch.Restart();
            resultDouble = Math.Sqrt(1234567.123456);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Double - " + resultDouble);

            stopwatch.Restart();
            resultDecimal = (decimal)Math.Sqrt((double)1234567.123456M);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Decimal - " + resultDecimal);

            Console.WriteLine("\n\rNatural logarithm diagnostics");

            stopwatch.Restart();
            resultFloat = (float)Math.Log(1234567.123456f, Math.E);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Float - " + resultFloat);

            stopwatch.Restart();
            resultDouble = Math.Log(1234567.123456, Math.E);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Double - " + resultDouble);

            stopwatch.Restart();
            resultDecimal = (decimal)Math.Log((double)1234567.123456M, Math.E);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Decimal - " + resultDecimal);

            Console.WriteLine("\n\rSinus diagnostics");

            stopwatch.Restart();
            resultFloat = (float)Math.Sin(1234567.123456f);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Float - " + resultFloat);

            stopwatch.Restart();
            resultDouble = Math.Sin(1234567.123456);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Double - " + resultDouble);

            stopwatch.Restart();
            resultDecimal = (decimal)Math.Sin((double)1234567.123456M);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " - Decimal - " + resultDecimal);
        }
    }
}
