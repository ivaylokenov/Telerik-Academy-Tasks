namespace GameFifteen
{
    using System;
    using System.Text;

    public class ConsoleRenderer
    {
        public ConsoleRenderer()
        {
        }

        public void RenderTopScores(Score scores)
        {
            Console.WriteLine("Scoreboard:");
            string[] topScores = scores.GetTopScoresFromFile();

            if (topScores[0] == null)
            {
                Console.WriteLine("There are no scores to display yet.");
            }
            else
            {
                foreach (string score in topScores)
                {
                    if (score != null)
                    {
                        Console.WriteLine(score);
                    }
                }
            }
        }

        public void RenderMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void RenderMatrix(Board gameField)
        {
            StringBuilder matrixToString = new StringBuilder();

            string horizontalBorder = this.GetHorizontalBorder(gameField);

            matrixToString.AppendLine(horizontalBorder);

            for (int row = 0; row < gameField.MatrixSizeRows; row++)
            {
                matrixToString.Append(" |");

                for (int column = 0; column < gameField.MatrixSizeColumns; column++)
                {
                    matrixToString.AppendFormat("{0,3}", gameField.Matrix[row, column]);
                }

                matrixToString.AppendLine(" |");
            }

            matrixToString.Append(horizontalBorder);

            Console.WriteLine(matrixToString);
        }

        private string GetHorizontalBorder(Board gameField)
        {
            StringBuilder horizontalBorder = new StringBuilder();

            horizontalBorder.Append("  ");

            for (int i = 0; i < gameField.MatrixSizeColumns; i++)
            {
                horizontalBorder.Append("---");
            }

            horizontalBorder.Append("- ");

            return horizontalBorder.ToString();
        }
    }
}
