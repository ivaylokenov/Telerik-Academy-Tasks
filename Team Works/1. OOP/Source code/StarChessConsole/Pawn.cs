using System;
using System.Linq;

namespace StarChessConsole
{
    public class Pawn : Figure, Interfaces.IMovable
    {
        public Pawn(Colors color, Names name)
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

            //road check for two cells move
            if (Math.Abs(lastRow - nextRow) == 2)
            {
                if (nextRow - lastRow < 0 && currentPosition.Position[lastRow, lastCol].Color == Colors.White) //up - white
                {
                    if (currentPosition.Position[lastRow - 1, lastCol].Name != Names.None)
                    {
                        return false; // blocked road
                    }
                }
                else //down - black
                {
                    if (currentPosition.Position[lastRow + 1, lastCol].Name != Names.None)
                    {
                        return false; // blocked road
                    }
                }
            }
            
            //valid move check
            //up - white
            if (isCollision == true && currentPosition.Position[lastRow, lastCol].Color == Colors.White && Math.Abs(nextCol - lastCol) == 1 && nextRow - lastRow == -1) 
            {
                base.GetFigure(currentPosition, nextRow, nextCol);
                currentPosition.Position[lastRow, lastCol].Name = Names.None;
                currentPosition.Position[nextRow, nextCol].Name = Names.Pawn;
                currentPosition.Position[nextRow, nextCol].Color = currentPosition.Position[lastRow, lastCol].Color;
                return true;
            }
            //down - black
            if (isCollision == true && currentPosition.Position[lastRow, lastCol].Color == Colors.Black && Math.Abs(nextCol - lastCol) == 1 && nextRow - lastRow == 1) 
            {
                //TODO: collision
                base.GetFigure(currentPosition, nextRow, nextCol);
                currentPosition.Position[lastRow, lastCol].Name = Names.None;
                currentPosition.Position[nextRow, nextCol].Name = Names.Pawn;
                currentPosition.Position[nextRow, nextCol].Color = currentPosition.Position[lastRow, lastCol].Color;
                return true;
            }
            if ((lastCol == nextCol && Math.Abs(lastRow - nextRow) == 1) || (lastCol == nextCol && Math.Abs(lastRow - nextRow) == 2 && (lastRow == 1 || lastRow == 6)))
            {
                if (nextRow - lastRow < 0 && currentPosition.Position[lastRow, lastCol].Color == Colors.Black)
                {
                    return false; //wrong direction
                }
                else if (nextRow - lastRow > 0 && currentPosition.Position[lastRow, lastCol].Color == Colors.White)
                {
                    return false; //wrong direction
                }

                if (isCollision == false)
                {
                    currentPosition.Position[lastRow, lastCol].Name = Names.None;
                    currentPosition.Position[nextRow, nextCol].Name = Names.Pawn;
                    currentPosition.Position[nextRow, nextCol].Color = currentPosition.Position[lastRow, lastCol].Color;
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return false;
        }

        public override bool MakesChess(int row, int col, Player currentPlayer, FigurePositions currentPosition)
        {

            switch (currentPlayer.Color)
            {
                case Colors.Black:
                    {
                        //left fork
                        if (col - 1 >= 0 && row + 1 <=7)
                        {
                            if (currentPosition.Position[row+1, col - 1].Name == Names.King && currentPosition.Position[row+1, col-1].Color != currentPlayer.Color)
                            {
                                return true; //chess
                            }
                        }
                        //right fork
                        if (col + 1 <= 7 && row + 1 <=7)
                        {
                            if (currentPosition.Position[row+1, col + 1].Name == Names.King && currentPosition.Position[row+1, col+1].Color != currentPlayer.Color)
                            {
                                return true; //chess
                            }
                        }
                        break;
                    }
                case Colors.White:
                    {
                        //left fork
                        if (col - 1 >= 0 && row - 1 >= 0)
                        {
                            if (currentPosition.Position[row-1, col - 1].Name == Names.King && currentPosition.Position[row-1, col-1].Color != currentPlayer.Color)
                            {
                                return true; //chess
                            }
                        }
                        //right fork
                        if (col + 1 <= 7 && row - 1 >= 0)
                        {
                            if (currentPosition.Position[row-1, col + 1].Name == Names.King && currentPosition.Position[row-1, col+1].Color != currentPlayer.Color)
                            {
                                return true; //chess
                            }
                        }
                        break;
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
