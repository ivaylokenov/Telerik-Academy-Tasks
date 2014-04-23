using System;
using System.Linq;

namespace StarChessConsole
{
    public class Knight : Figure
    {
        public Knight(Colors color, Names name)
            : base(color, name) 
        {

        }

        public override bool MoveFigure(string coordinates, FigurePositions currentPosition)
        {
            string[] coordinateSplit = coordinates.Split('-');

            int lastCol = int.Parse(coordinateSplit[0]);
            int lastRow = int.Parse(coordinateSplit[1]);
            int nextCol = int.Parse(coordinateSplit[2]);
            int nextRow = int.Parse(coordinateSplit[3]);

            //collision check
            bool isCollision = false;
            if (currentPosition.Position[nextRow, nextCol].Name != Names.None)
            {
                if (currentPosition.Position[nextRow, nextCol].Color == currentPosition.Position[lastRow, lastCol].Color)
                {
                    return false; //collision same colors
                }
                isCollision = true;
            }
            //valid move check
            if ((Math.Abs(lastCol - nextCol) == 1 && Math.Abs(lastRow - nextRow) == 2) || (Math.Abs(lastCol - nextCol) == 2 && Math.Abs(lastRow - nextRow) == 1))
            {
                if (isCollision)
                {
                    base.GetFigure(currentPosition, nextRow, nextCol);
                }
                currentPosition.Position[lastRow, lastCol].Name = Names.None;
                currentPosition.Position[nextRow, nextCol].Name = Names.Knight;
                currentPosition.Position[nextRow, nextCol].Color = currentPosition.Position[lastRow, lastCol].Color;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool MakesChess(int row, int col, Player currentPlayer, FigurePositions currentPosition)
        {
            //left-up
            if (row - 2 >= 0 && col - 1 >=0)
            {
                if (currentPosition.Position[row - 2, col - 1].Name == Names.King && currentPosition.Position[row - 2, col - 1].Color != currentPlayer.Color)
                {
                    return true; //chess
                } 
            }
            if (row - 1 >= 0 && col - 2 >=0)
            {
                if (currentPosition.Position[row - 1, col - 2].Name == Names.King && currentPosition.Position[row - 1, col - 2].Color != currentPlayer.Color)
                {
                    return true; //chess
                } 
            }
            //right-up
            if (row - 2 >= 0 && col + 1 <= 7)
            {
                if (currentPosition.Position[row - 2, col + 1].Name == Names.King && currentPosition.Position[row - 2, col + 1].Color != currentPlayer.Color)
                {
                    return true; //chess
                }
            }
            if (row - 1 >= 0 && col + 2 <= 7)
            {
                if (currentPosition.Position[row - 1, col + 2].Name == Names.King && currentPosition.Position[row - 1, col + 2].Color != currentPlayer.Color)
                {
                    return true; //chess
                }
            }
            //left-down
            if (row + 2 <= 7 && col - 1 >= 0)
            {
                if (currentPosition.Position[row + 2, col - 1].Name == Names.King && currentPosition.Position[row + 2, col - 1].Color != currentPlayer.Color)
                {
                    return true; //chess
                }
            }
            if (row + 1 <= 7 && col - 2 >= 0)
            {
                if (currentPosition.Position[row + 1, col - 2].Name == Names.King && currentPosition.Position[row + 1, col - 2].Color != currentPlayer.Color)
                {
                    return true; //chess
                }
            }
            //right-down
            if (row + 2 <= 7 && col + 1 <= 7)
            {
                if (currentPosition.Position[row + 2, col + 1].Name == Names.King && currentPosition.Position[row + 2, col + 1].Color != currentPlayer.Color)
                {
                    return true; //chess
                }
            }
            if (row - 1 >= 0 && col + 2 <= 7)
            {
                if (currentPosition.Position[row + 1, col + 2].Name == Names.King && currentPosition.Position[row + 1, col + 2].Color != currentPlayer.Color)
                {
                    return true; //chess
                }
            }
            return false;
        }

        public override void MakeQueen()
        {
            throw new NotImplementedException();
        }
    }
}
