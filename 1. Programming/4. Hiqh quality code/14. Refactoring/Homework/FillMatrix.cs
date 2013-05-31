namespace RotatingWalkInMatrix
{
    using System;

    public class FillMatrix
    {
        public readonly int[] VerticalDirection = { 1, 1, 1, 0, -1, -1, -1, 0 };
        public readonly int[] HorizontalDirection = { 1, 0, -1, -1, -1, 0, 1, 1 };

        public FillMatrix(int dimension)
        {
            this.Matrix = new int[dimension, dimension];
            this.NumberCounter = 1;
        }

        public int[,] Matrix { get; set; }

        public int NumberCounter { get; set; }

        public void FindEmptyCell(out int vertical, out int horizontal)
        {
            vertical = 0;
            horizontal = 0;

            for (int vert = 0; vert < this.Matrix.GetLength(0); vert++)
            {
                for (int hor = 0; hor < this.Matrix.GetLength(0); hor++)
                {
                    if (this.Matrix[vert, hor] == 0)
                    {
                        vertical = vert;
                        horizontal = hor;
                        return;
                    }
                }
            }
        }

        public void FillMatrixWithNumbers(int vertical, int horizontal, int dimension)
        {
            int directionY = 1;
            int directionX = 1;

            while (true)
            {
                this.Matrix[vertical, horizontal] = this.NumberCounter;

                if (!this.CheckPossibleDirection(this.Matrix, vertical, horizontal))
                {
                    this.NumberCounter++;
                    break;
                }

                // we change directions until we find suitable one
                while (CheckOutOfMatrix(vertical, horizontal, directionX, directionY, dimension))
                {
                    this.ChangeDirection(ref directionY, ref directionX);
                }

                vertical += directionY;
                horizontal += directionX;
                this.NumberCounter++;
            }
        }

        public void PrintMatrix()
        {
            for (int row = 0; row < this.Matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.Matrix.GetLength(1); col++)
                {
                    Console.Write("{0,3}", this.Matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private int FindCurrentDirection(int currentDirectionVertical, int currentDirectionHorizontal)
        {
            for (int directionCounter = 0; directionCounter < 8; directionCounter++)
            {
                if (this.VerticalDirection[directionCounter] == currentDirectionVertical
                    && this.HorizontalDirection[directionCounter] == currentDirectionHorizontal)
                {
                    return directionCounter;
                }
            }

            throw new ArgumentException("Direction was not found.");
        }

        private void ChangeDirection(ref int currentDirectionVertical, ref int currentDirectionHorizontal)
        {
            int currentDirectionIndex = this.FindCurrentDirection(currentDirectionVertical, currentDirectionHorizontal);

            if (currentDirectionIndex == 7)
            {
                currentDirectionVertical = this.VerticalDirection[0];
                currentDirectionHorizontal = this.HorizontalDirection[0];
            }
            else
            {
                currentDirectionVertical = this.VerticalDirection[currentDirectionIndex + 1];
                currentDirectionHorizontal = this.HorizontalDirection[currentDirectionIndex + 1];
            }
        }

        private bool CheckPossibleDirection(int[,] matrix, int vertical, int horizontal)
        {
            int[] possibleDirectionVertical = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] possibleDirectionHorizontal = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int index = 0; index < 8; index++)
            {
                if (vertical + possibleDirectionVertical[index] >= matrix.GetLength(0)
                    || vertical + possibleDirectionVertical[index] < 0)
                {
                    possibleDirectionVertical[index] = 0;
                }

                if (horizontal + possibleDirectionHorizontal[index] >= matrix.GetLength(0)
                    || horizontal + possibleDirectionHorizontal[index] < 0)
                {
                    possibleDirectionHorizontal[index] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (matrix[vertical + possibleDirectionVertical[i], horizontal + possibleDirectionHorizontal[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckOutOfMatrix(int vertical, int horizontal,
            int directionX, int directionY, int dimension)
        {
            if (vertical + directionY >= dimension
                    || vertical + directionY < 0
                    || horizontal + directionX >= dimension
                    || horizontal + directionX < 0
                    || this.Matrix[vertical + directionY, horizontal + directionX] != 0)
            {
                return true;
            }

            return false;
        }

    }
}
