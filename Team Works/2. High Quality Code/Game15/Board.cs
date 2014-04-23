namespace GameFifteen
{
    using System;

    /// <summary>
    /// Class containing game board for the game.
    /// </summary>
    public class Board
    {
        private const string EmptyCellValue = " ";

        private static readonly int[] DirectionRow = { -1, 0, 1, 0 }; // left, down, right, up
        private static readonly int[] DirectionColumn = { 0, 1, 0, -1 };
        private static readonly Random Random = new Random();

        private int matrixSizeRows;
        private int matrixSizeColumns;

        private string[,] matrix; 

        private int emptyCellRow;
        private int emptyCellColumn;

        /// <summary>
        /// Initializes a new instance of the Board class.
        /// </summary>
        /// <param name="matrixSizeRows">The number of rows the game board has.</param>
        /// <param name="matrixSizeColumns">The number of columns the game board has.</param>
        public Board(int matrixSizeRows, int matrixSizeColumns)
        {
            this.MatrixSizeRows = matrixSizeRows;
            this.MatrixSizeColumns = matrixSizeColumns;
        }

        /// <summary>
        /// Gets or sets the matrix of the game board.
        /// </summary>
        /// <value>Two dimensional array of strings.</value>
        public string[,] Matrix
        {
            get
            {
                return this.matrix;
            }

            set
            {
                this.matrix = value;
            }
        }

        /// <summary>
        /// Gets or sets the count of the rows in the game board's matrix
        /// </summary>
        /// <value>Positive integer number.</value>
        public int MatrixSizeRows
        {
            get
            {
                return this.matrixSizeRows;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Matrix cant have 0 or less rows");
                }

                this.matrixSizeRows = value;
            }
        }

        /// <summary>
        /// Gets or sets the count of columns in the game board's matrix 
        /// </summary>
        /// <value>Positive integer number.</value>
        public int MatrixSizeColumns
        {
            get
            {
                return this.matrixSizeColumns;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Matrix cant have 0 or less columns");
                }

                this.matrixSizeColumns = value;
            }
        }

        /// <summary>
        /// Gets or sets the row of the empty cell in the game board
        /// </summary>
        /// <value>Positive integer number.</value>
        public int EmptyRow
        {
            get
            {
                return this.emptyCellRow;
            }

            set
            {
                if (value < 0 || value >= this.MatrixSizeRows)
                {
                    throw new ArgumentOutOfRangeException("Value must be less than zero or bigger than matrix rows.");
                }

                this.emptyCellRow = value;
            }
        }

        /// <summary>
        /// Gets or sets the column of the empty cell in the game board
        /// </summary>
        /// <value>Positive integer number.</value>
        public int EmptyCol
        {
            get
            {
                return this.emptyCellColumn;
            }

            set
            {
                if (value < 0 || value >= this.MatrixSizeColumns)
                {
                    throw new ArgumentOutOfRangeException("Value must be less than zero or bigger than matrix columns.");
                }

                this.emptyCellColumn = value;
            }
        }

        /// <summary>
        /// Checks if the cell that is going to switch with
        /// the empty cell is inside the matrix
        /// </summary>
        /// <param name="direction">The direction to which the empty cell is going to be moved</param>
        /// <returns>\Returns boolean value showing if the next cell is valid.</returns>
        public bool ValidateNextCell(int direction)
        {
            int nextCellRow = this.EmptyRow + Board.DirectionRow[direction];
            bool isRowValid = (nextCellRow >= 0) && (nextCellRow < this.matrixSizeRows);

            int nextCellColumn = this.emptyCellColumn + Board.DirectionColumn[direction];
            bool isColumnValid = (nextCellColumn >= 0) && (nextCellColumn < this.matrixSizeColumns);

            bool isCellValid = isRowValid && isColumnValid;

            return isCellValid;
        }

        public int CellNumberToDirection(int cellNumber)
        {
            int direction = -1;

            for (int dir = 0; dir < DirectionRow.Length; dir++)
            {
                bool isDirValid = this.ValidateNextCell(dir);

                if (isDirValid)
                {
                    int nextCellRow = this.EmptyRow + Board.DirectionRow[dir];
                    int nextCellColumn = this.EmptyCol + Board.DirectionColumn[dir];

                    if (this.Matrix[nextCellRow, nextCellColumn] == cellNumber.ToString())
                    {
                        direction = dir;
                        break;
                    }
                }
            }

            return direction;
        }

        public void MoveCell(int direction)
        {
            int nextCellRow = this.EmptyRow + DirectionRow[direction];
            int nextCellColumn = this.EmptyCol + DirectionColumn[direction];

            this.Matrix[this.EmptyRow, this.EmptyCol] = this.Matrix[nextCellRow, nextCellColumn];
            this.Matrix[nextCellRow, nextCellColumn] = EmptyCellValue;

            this.EmptyRow = nextCellRow;
            this.emptyCellColumn = nextCellColumn;

            Turn.Count++;
        }

        public bool CheckIfMatrixIsOrderedCorrectly()
        {
            bool isEmptyCellInPlace = this.EmptyRow == this.matrixSizeRows - 1 &&
                this.EmptyCol == this.matrixSizeColumns - 1;

            if (!isEmptyCellInPlace)
            {
                return false;
            }

            int cellValue = 1;
            int matrixSize = this.matrixSizeRows * this.matrixSizeColumns;

            for (int row = 0; row < this.matrixSizeRows; row++)
            {
                for (int column = 0; column < this.matrixSizeColumns && cellValue < matrixSize; column++)
                {
                    if (this.Matrix[row, column] != cellValue.ToString())
                    {
                        return false;
                    }

                    cellValue++;
                }
            }

            return true;
        }

        public void InitializeMatrix()
        {
            this.Matrix = new string[this.matrixSizeRows, this.matrixSizeColumns];
            int cellValue = 1;

            for (int row = 0; row < this.matrixSizeRows; row++)
            {
                for (int column = 0; column < this.matrixSizeColumns; column++)
                {
                    this.Matrix[row, column] = cellValue.ToString();
                    cellValue++;
                }
            }

            this.emptyCellRow = this.matrixSizeRows - 1;
            this.emptyCellColumn = this.matrixSizeColumns - 1;
            this.Matrix[this.emptyCellRow, this.emptyCellColumn] = Board.EmptyCellValue;
        }

        public void ShuffleMatrix()
        {
            int matrixSize = this.matrixSizeRows * this.matrixSizeColumns;
            int shuffles = Random.Next(matrixSize, matrixSize * 100);

            for (int i = 0; i < shuffles; i++)
            {
                int direction = Random.Next(DirectionRow.Length);
                if (this.ValidateNextCell(direction))
                {
                    this.MoveCell(direction);
                }
            }

            if (this.CheckIfMatrixIsOrderedCorrectly())
            {
                this.ShuffleMatrix();
            }
        }
    }
}
