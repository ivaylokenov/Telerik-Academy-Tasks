using System;

namespace Matrix
{
    class Matrix<T> where T : IComparable<T>
    {
        //field for matrix
        private readonly T[,] matrix;

        //constructor
        public Matrix(int rows, int cols)
        {
            matrix = new T[rows, cols];
        }

        //get rows
        public int Rows
        {
            get { return matrix.GetLength(0); }
        }

        //get cols
        public int Cols
        {
            get { return matrix.GetLength(1); }
        }

        //indexator
        public T this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= Rows || col < 0 || col >= Cols)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return matrix[row, col];
                }
            }

            set
            {
                if (row < 0 || row >= Rows || col < 0 || col >= Cols)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    matrix[row, col] = value;
                }
            }
        }

        //addition + 
        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            if (first.Rows == second.Rows && first.Cols == second.Cols)
            {
                Matrix<T> result = new Matrix<T>(first.Rows, first.Cols);

                for (int i = 0; i < first.Rows; i++)
                {
                    for (int j = 0; j < first.Cols; j++)
                    {
                        result[i, j] = (dynamic)first[i, j] + (dynamic)second[i, j];
                    }
                }

                return result;
            }
            else
            {
                throw new OperationCanceledException("Matrixes should be same size.");
            }
        }

        //substracting -
        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            if (first.Rows == second.Rows && first.Cols == second.Cols)
            {
                Matrix<T> result = new Matrix<T>(first.Rows, first.Cols);

                for (int i = 0; i < first.Rows; i++)
                {
                    for (int j = 0; j < first.Cols; j++)
                    {
                        result[i, j] = (dynamic)first[i, j] - (dynamic)second[i, j];
                    }
                }

                return result;
            }
            else
            {
                throw new OperationCanceledException("Matrixes should be same size.");
            }
        }

        //multiplication
        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Cols != secondMatrix.Rows)
            {
                throw new OperationCanceledException("Cannot multiply!");
            }
            else
            {
                Matrix<T> result = new Matrix<T>(firstMatrix.Rows, secondMatrix.Cols);

                for (int i = 0; i < result.Rows; i++)
                {
                    for (int j = 0; j < result.Cols; j++)
                    {
                        for (int k = 0; k < firstMatrix.Cols; k++)
                        {
                            result[i, j] += (dynamic)firstMatrix[i, k] * (dynamic)secondMatrix[k, j];
                        }
                    }
                }

                return result;
            }
        }

        public static bool operator true(Matrix<T> matrix)
        {
            bool isNonZero = true;

            for (int i = 0; i < matrix.Rows; i++)
			{
                for (int j = 0; j < matrix.Cols; j++)
                {
                    if ((dynamic)matrix[i, j] == 0)
                    {
                        isNonZero = false;
                    }
                }
			}

            return isNonZero;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            bool isNonZero = true;

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {
                    if ((dynamic)matrix[i, j] == 0)
                    {
                        isNonZero = false;
                    }
                }
            }

            return isNonZero;
        }
    }
}
