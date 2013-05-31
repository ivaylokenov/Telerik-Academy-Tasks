using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class MatrixTest
    {
        //8. Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 

        //9. Implement an indexer this[row, col] to access the inner matrix cells.

        //10. Implement the operators + and - (addition and subtraction of matrices
        //of the same size) and * for matrix multiplication. Throw an 
        //exception when the operation cannot be performed. Implement 
        //the true operator (check for non-zero elements).

        static void Main()
        {
            //this class is for testing
            Matrix<int> testMatrixFirst = new Matrix<int>(4, 2);
            Matrix<int> testMatrixSecond = new Matrix<int>(2, 5);

            for (int i = 0; i < testMatrixFirst.Rows; i++)
            {
                for (int j = 0; j < testMatrixFirst.Cols; j++)
                {
                    testMatrixFirst[i, j] = i + j + 1;
                }
            }

            for (int i = 0; i < testMatrixSecond.Rows; i++)
            {
                for (int j = 0; j < testMatrixSecond.Cols; j++)
                {
                    testMatrixSecond[i, j] = i * j;
                }
            }

            //addition
            //Matrix<int> result = testMatrixFirst + testMatrixSecond;

            //substraction
            //result = testMatrixFirst - testMatrixSecond;

            //multiplication
            Matrix<int> result = testMatrixFirst * testMatrixSecond;

            if (testMatrixFirst)
            {
                Console.WriteLine("Does not have zero element");
            }
            else
            {
                Console.WriteLine("Has zero element");
            }

            Console.WriteLine();
        }
    }
}
