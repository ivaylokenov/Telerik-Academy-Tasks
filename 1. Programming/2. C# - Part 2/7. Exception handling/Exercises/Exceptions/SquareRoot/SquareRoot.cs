using System;

class SquareRoot
{
    static void Main()
    {
        try
        {
            uint number = uint.Parse(Console.ReadLine());
            double result = Math.Sqrt(number);
            Console.WriteLine(result);
        }
        catch (FormatException)
        {
            Console.WriteLine("Your number is not valid.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Your number is negative.");
        }
        finally
        {
            Console.WriteLine("Good bye!");
        }
    }
}
