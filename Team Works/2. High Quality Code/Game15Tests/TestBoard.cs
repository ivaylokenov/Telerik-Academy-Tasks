using System;
using GameFifteen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game15Tests
{
    [TestClass]
    public class TestBoard
    {
        [TestMethod]
        public void TestBoardConstructorMatrixSize()
        {
            Board board = new Board(3, 6);

            Assert.AreEqual(board.MatrixSizeRows, 3);
            Assert.AreEqual(board.MatrixSizeColumns, 6);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestBoardConstructorMatrixSizeInvalidRows()
        {
            Board board = new Board(-3, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestBoardConstructorMatrixSizeInvalidCols()
        {
            Board board = new Board(5, -3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInvalidEmptyRows()
        {
            Board board = new Board(5, 4);

            board.EmptyRow = 15;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInvalidEmptyCols()
        {
            Board board = new Board(5, 4);

            board.EmptyCol = 15;
        }

        [TestMethod]
        public void TestValidateNextCellInvalidRowZero()
        {
            Board board = new Board(3, 3);

            board.Matrix = new string[,] 
            {
                { "8", "1", "3"},
                { " ", "2", "4"},
                { "6", "5", "7"},
            };

            board.EmptyRow = 1;
            board.EmptyCol = 0;

            bool validation = board.ValidateNextCell(3);

            Assert.AreEqual(false, validation);
        }

        [TestMethod]
        public void TestValidateNextCellInvalidRowAboveLength()
        {
            Board board = new Board(3, 3);

            board.Matrix = new string[,] 
            {
                { "8", "1", "3"},
                { "4", "2", " "},
                { "6", "5", "7"},
            };

            board.EmptyRow = 1;
            board.EmptyCol = 2;

            bool validation = board.ValidateNextCell(1);

            Assert.AreEqual(false, validation);
        }

        [TestMethod]
        public void TestValidateNextCellInvalidColZero()
        {
            Board board = new Board(3, 3);

            board.Matrix = new string[,] 
            {
                { "8", " ", "3"},
                { "4", "2", "1"},
                { "6", "5", "7"},
            };

            board.EmptyRow = 0;
            board.EmptyCol = 1;

            bool validation = board.ValidateNextCell(0);

            Assert.AreEqual(false, validation);
        }

        [TestMethod]
        public void TestValidateNextCellInvalidColAboveLength()
        {
            Board board = new Board(3, 3);

            board.Matrix = new string[,] 
            {
                { "8", "1", "3"},
                { "4", "2", "7"},
                { "6", "5", " "},
            };

            board.EmptyRow = 2;
            board.EmptyCol = 2;

            bool validation = board.ValidateNextCell(2);

            Assert.AreEqual(false, validation);
        }

        [TestMethod]
        public void TestValidateNextCellValid()
        {
            Board board = new Board(3, 3);

            board.Matrix = new string[,] 
            {
                { "8", "1", "3"},
                { "4", "2", "7"},
                { "6", "5", " "},
            };

            board.EmptyRow = 2;
            board.EmptyCol = 2;

            bool validation = board.ValidateNextCell(0);

            Assert.AreEqual(true, validation);
        }

        [TestMethod]
        public void TestCellNumberToDirectionDown()
        {
            Board board = new Board(3, 3);

            board.Matrix = new string[,] 
            {
                { "8", "1", "3"},
                { "2", " ", "4"},
                { "6", "5", "7"},
            };

            board.EmptyRow = 1;
            board.EmptyCol = 1;

            int direction = board.CellNumberToDirection(1);

            Assert.AreEqual(0, direction);
        }

        [TestMethod]
        public void TestCellNumberToDirectionUp()
        {
            Board board = new Board(3, 3);

            board.Matrix = new string[,] 
            {
                { "8", "1", "3"},
                { "2", " ", "4"},
                { "6", "5", "7"},
            };

            board.EmptyRow = 1;
            board.EmptyCol = 1;

            int direction = board.CellNumberToDirection(5);

            Assert.AreEqual(2, direction);
        }

        [TestMethod]
        public void TestCellNumberToDirectionRight()
        {
            Board board = new Board(3, 3);

            board.Matrix = new string[,] 
            {
                { "8", "1", "3"},
                { "2", " ", "4"},
                { "6", "5", "7"},
            };

            board.EmptyRow = 1;
            board.EmptyCol = 1;

            int direction = board.CellNumberToDirection(2);

            Assert.AreEqual(3, direction);
        }

        [TestMethod]
        public void TestCellNumberToDirectionLeft()
        {
            Board board = new Board(3, 3);

            board.Matrix = new string[,] 
            {
                { "8", "1", "3"},
                { "2", " ", "4"},
                { "6", "5", "7"},
            };

            board.EmptyRow = 1;
            board.EmptyCol = 1;

            int direction = board.CellNumberToDirection(4);

            Assert.AreEqual(1, direction);
        }

        [TestMethod]
        public void TestCellNumberToDirectionInvalid()
        {
            Board board = new Board(3, 3);

            board.Matrix = new string[,] 
            {
                { "8", "1", "3"},
                { "2", " ", "4"},
                { "6", "5", "7"},
            };

            board.EmptyRow = 1;
            board.EmptyCol = 1;

            int direction = board.CellNumberToDirection(3);

            Assert.AreEqual(-1, direction);
        }

        [TestMethod]
        public void TestMoveCell()
        {
            Board board = new Board(3, 3);

            board.Matrix = new string[,] 
            {
                { "8", "1", "3"},
                { "2", " ", "4"},
                { "6", "5", "7"},
            };

            board.EmptyRow = 1;
            board.EmptyCol = 1;

            board.MoveCell(0);

            Board result = new Board(3, 3);

            result.Matrix = new string[,] 
            {
                { "8", " ", "3"},
                { "2", "1", "4"},
                { "6", "5", "7"},
            };

            bool endResult = false;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board.Matrix[i, j] != result.Matrix[i, j])
                    {
                        endResult = true;
                        break;
                    }
                }

                if (endResult)
                {
                    break;
                }
            }

            Assert.IsFalse(endResult);
        }

        [TestMethod]
        public void TestCheckIfMatrixIsOrderedCorrectly()
        {
            Board board = new Board(3, 3);

            board.InitializeMatrix();

            bool result = board.CheckIfMatrixIsOrderedCorrectly();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestCheckIfMatrixIsOrderedCorrectlyInvalidEmptyCells()
        {
            Board board = new Board(3, 3);

            board.InitializeMatrix();

            board.EmptyRow = 1;

            bool result = board.CheckIfMatrixIsOrderedCorrectly();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestCheckIfMatrixIsOrderedCorrectlyUnorderedMatrix()
        {
            Board board = new Board(3, 3);

            board.InitializeMatrix();
            board.ShuffleMatrix();

            bool result = board.CheckIfMatrixIsOrderedCorrectly();

            Assert.IsFalse(result);
        }
    }
}
