using System;
using System.Linq;

namespace StarChessConsole
{
    public class King : Figure
    {
        public King(Colors color, Names name) : base (color, name)
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
            if (Math.Abs(lastCol-nextCol) <= 1 && Math.Abs(lastRow-nextRow) <= 1)
            {
                if (isCollision)
                {
                    base.GetFigure(currentPosition, nextRow, nextCol);
                }
                currentPosition.Position[lastRow, lastCol].Name = Names.None;
                currentPosition.Position[nextRow, nextCol].Name = Names.King;
                currentPosition.Position[nextRow, nextCol].Color = currentPosition.Position[lastRow, lastCol].Color;
                return true;
            }
            else
            {
                return false;
            }

        }

        public override void MakeQueen()
        {
            throw new NotImplementedException();
        }
    }
}
