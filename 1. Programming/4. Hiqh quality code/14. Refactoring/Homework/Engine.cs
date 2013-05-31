namespace RotatingWalkInMatrix
{
    using System;

    public class Engine
    {
        public static void Main()
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            int dimension = 0;
            while (!int.TryParse(input, out dimension) || dimension < 0 || dimension > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number!");
                input = Console.ReadLine();
            }

            FillMatrix matrix = new FillMatrix(dimension);

            int vertical = 0; 
            int horizontal = 0;

            matrix.FillMatrixWithNumbers(vertical, horizontal, dimension);

            matrix.FindEmptyCell(out vertical, out horizontal);

            if (vertical != 0 && horizontal != 0)
            {
                matrix.FillMatrixWithNumbers(vertical, horizontal, dimension);
            }

            matrix.PrintMatrix();
        }
    }
}
