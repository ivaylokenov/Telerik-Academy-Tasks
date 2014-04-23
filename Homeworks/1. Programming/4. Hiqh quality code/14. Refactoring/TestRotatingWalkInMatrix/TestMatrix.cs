namespace TestRotatingWalkInMatrix
{
    using System;
    using System.IO;
    using System.Text;
    using RotatingWalkInMatrix;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestMatrix
    {
        [TestMethod]
        public void TestFindEmptyCell()
        {
            FillMatrix matrix = new FillMatrix(4);

            matrix.Matrix = new int[4, 4] 
            {
                {1,2,3,4},
                {5,6,7,8},
                {1,0,3,4},
                {1,2,3,4}
            };

            int horizontal = 0;
            int vertical = 0;

            matrix.FindEmptyCell(out vertical, out horizontal);

            Assert.AreEqual(2, vertical);
            Assert.AreEqual(1, horizontal);
        }

        [TestMethod]
        public void TestFillMatrix()
        {
            FillMatrix matrix = new FillMatrix(6);

            int[,] expected = new int[,] 
            {
                 {1, 16, 17, 18, 19, 20},
                 {15, 2, 27, 28,  29, 21},
                 {14, 0, 3, 26 ,30 , 22},
                 {13, 0, 0,  4, 25, 23},
                 {12, 0, 0, 0, 5, 24},
                 {11, 10, 9, 8, 7, 6}
            };

            int horizontal = 0;
            int vertical = 0;

            matrix.FillMatrixWithNumbers(vertical, horizontal, 6);

            bool isSame = true;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (matrix.Matrix[i, j] != expected[i, j])
                    {
                        isSame = false;
                    }
                }
            }

            Assert.AreEqual(true, isSame);
        }

        [TestMethod]
        public void TestFillMatrixAfterJump()
        {
            FillMatrix matrix = new FillMatrix(6);

            int[,] expected = new int[,] 
            {
                 {1, 16, 17, 18, 19, 20},
                 {15, 2, 27, 28,  29, 21},
                 {14, 31, 3, 26 ,30 , 22},
                 {13, 36, 32,  4, 25, 23},
                 {12, 35, 34, 33, 5, 24},
                 {11, 10, 9, 8, 7, 6}
            };

            int horizontal = 0;
            int vertical = 0;

            matrix.FillMatrixWithNumbers(vertical, horizontal, 6);

            matrix.FindEmptyCell(out vertical, out horizontal);

            matrix.FillMatrixWithNumbers(vertical, horizontal, 6);

            bool isSame = true;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (matrix.Matrix[i, j] != expected[i, j])
                    {
                        isSame = false;
                    }
                }
            }

            Assert.AreEqual(true, isSame);
        }

        [TestMethod]
        public void TestPrintMatrix()
        {
            StreamWriter writer = new StreamWriter("testprint.txt");

            Console.SetOut(writer);

            FillMatrix matrix = new FillMatrix(6);

            int horizontal = 0;
            int vertical = 0;

            matrix.FillMatrixWithNumbers(vertical, horizontal, 6);

            matrix.FindEmptyCell(out vertical, out horizontal);

            matrix.FillMatrixWithNumbers(vertical, horizontal, 6);

            using (writer)
            {
                matrix.PrintMatrix();
            }

            StreamReader reader = new StreamReader("testprint.txt");
            StringBuilder result = new StringBuilder();

            using (reader)
            {
                for (int i = 0; i < 6; i++)
                {
                    result.Append(reader.ReadLine());
                    result.AppendLine();
                }
            }

            string resultStr = result.ToString();

            string expected = @"  1 16 17 18 19 20
 15  2 27 28 29 21
 14 31  3 26 30 22
 13 36 32  4 25 23
 12 35 34 33  5 24
 11 10  9  8  7  6
";

            Assert.AreEqual(resultStr, expected);
        }
    }
}
