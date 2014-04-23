using System;
using System.Linq;

namespace StarChessConsole
{
    public class Bishop : Figure
    {
        public Bishop(Colors color, Names name)
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

            //road check
            //find direction
            if (nextRow < lastRow && nextCol < lastCol) //up-left
            {
                //x -1 y -1
                for (int x = lastRow - 1, y = lastCol - 1; x > nextRow; x--, y--)
                {
                    if (currentPosition.Position[x, y].Name != Names.None)
                    {
                        return false; //road is not clear
                    }
                }

            }
            else if (nextRow > lastRow && nextCol < lastCol) //down-left
            {
                //x + 1 y - 1
                for (int x = lastRow + 1, y = lastCol - 1; x < nextRow; x++, y--)
                {
                    if (currentPosition.Position[x, y].Name != Names.None)
                    {
                        return false; //road is not clear
                    }
                }
            }
            else if (nextRow < lastRow && nextCol > lastCol) //up-right
            {
                //x-1 y+1
                for (int x = lastRow - 1, y = lastCol + 1; x > nextRow; x--, y++)
                {
                    if (currentPosition.Position[x, y].Name != Names.None)
                    {
                        return false; //road is not clear
                    }
                }

            }
            else if (nextRow > lastRow && nextCol > lastCol) // down-right
            {
                //x+1 y+1
                for (int x = lastRow + 1, y = lastCol + 1; x < nextRow; x++, y++)
                {
                    if (currentPosition.Position[x, y].Name != Names.None)
                    {
                        return false; //road is not clear
                    }
                }
            }

            //valid move check
            if (Math.Abs(lastCol - nextCol) == Math.Abs(lastRow - nextRow))
            {
                if (isCollision)
                {
                    //TODO:
                    if (StartProgram.CurrentPlayer == "white")
                    {
                        StartProgram.WhitePlayer.AddTakenFigure(currentPosition.Position[nextRow, nextCol].Name);
                    }
                    else
                    {
                        StartProgram.BlackPlayer.AddTakenFigure(currentPosition.Position[lastRow, lastCol].Name);
                    }
                }
                currentPosition.Position[lastRow, lastCol].Name = Names.None;
                currentPosition.Position[nextRow, nextCol].Name = Names.Bishop;
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
            //up-left x-1 y-1
            for (int x = row-1, y = col-1; x >= 0 && y >= 0; x--, y--)
            {
                if (currentPosition.Position[x,y].Name != Names.None)
                {
                    if (currentPosition.Position[x, y].Name == Names.King && currentPosition.Position[x, y].Color != currentPlayer.Color)
                    {
                        return true; //chess
                    }
                    else
                    {
                        break;
                    }
                }
            }
            //up-right x-1 y+1
            for (int x = row - 1, y = col + 1; x >= 0 && y <= 7; x--, y++)
            {
                if (currentPosition.Position[x, y].Name != Names.None)
                {
                    if (currentPosition.Position[x, y].Name == Names.King && currentPosition.Position[x, y].Color != currentPlayer.Color)
                    {
                        return true; //chess
                    }
                    else
                    {
                        break;
                    }
                }
            }
            //down-left x+1 y-1
            for (int x = row + 1, y = col - 1; x <= 7 && y >= 0; x++, y--)
            {
                if (currentPosition.Position[x, y].Name != Names.None)
                {
                    if (currentPosition.Position[x, y].Name == Names.King && currentPosition.Position[x, y].Color != currentPlayer.Color)
                    {
                        return true; //chess
                    }
                    else
                    {
                        break;
                    }
                }
            }
            //down-right x+1 y+1
            for (int x = row + 1, y = col + 1; x <= 7 && y <= 7; x++, y++)
            {
                if (currentPosition.Position[x, y].Name != Names.None)
                {
                    if (currentPosition.Position[x, y].Name == Names.King && currentPosition.Position[x, y].Color != currentPlayer.Color)
                    {
                        return true; //chess
                    }
                    else
                    {
                        break;
                    }
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
