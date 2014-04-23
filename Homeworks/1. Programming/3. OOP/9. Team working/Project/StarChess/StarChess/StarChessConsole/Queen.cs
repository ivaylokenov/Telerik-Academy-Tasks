using System;
using System.Linq;

namespace StarChessConsole
{
    public class Queen : Figure
    {
        public Queen(Colors color, Names name)
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
            if (lastRow == nextRow || lastCol == nextCol) ////pawn move
            {
                if (nextRow > lastRow) //down
                {
                    //x+1
                    for (int x = lastRow + 1, y = lastCol; x < nextRow; x++)
                    {
                        if (currentPosition.Position[x, y].Name != Names.None)
                        {
                            return false; //road is not clear
                        }
                    }

                }
                else if (nextRow < lastRow) //up
                {
                    //x-1 
                    for (int x = lastRow - 1, y = lastCol; x > nextRow; x--)
                    {
                        if (currentPosition.Position[x, y].Name != Names.None)
                        {
                            return false; //road is not clear
                        }
                    }
                }
                else if (nextCol > lastCol) //left
                {
                    //y+1
                    for (int x = lastRow, y = lastCol + 1; y < nextCol; y++)
                    {
                        if (currentPosition.Position[x, y].Name != Names.None)
                        {
                            return false; //road is not clear
                        }
                    }

                }
                else if (nextCol < lastCol) //right
                {
                    //y-1
                    for (int x = lastRow, y = lastCol - 1; y > nextCol; y--)
                    {
                        if (currentPosition.Position[x, y].Name != Names.None)
                        {
                            return false; //road is not clear
                        }
                    }
                }
            }
            else ////bishop move
            {
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
            }

            //valid move check
            if ((Math.Abs(lastCol - nextCol) == Math.Abs(lastRow - nextRow)) || (lastRow == nextRow || lastCol == nextCol))
            {
                if (isCollision)
                {
                    base.GetFigure(currentPosition, nextRow, nextCol);
                }
                currentPosition.Position[lastRow, lastCol].Name = Names.None;
                currentPosition.Position[nextRow, nextCol].Name = Names.Queen;
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
            //bishop moves
            //up-left x-1 y-1
            for (int x = row - 1, y = col - 1; x >= 0 && y >= 0; x--, y--)
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

            //Rook moves
            //up            
            for (int i = row - 1; i >= 0; i--)
            {
                if (currentPosition.Position[i, col].Name != Names.None)
                {
                    if (currentPosition.Position[i, col].Name == Names.King && currentPosition.Position[i, col].Color != currentPlayer.Color)
                    {
                        return true; //chess
                    }
                    else
                    {
                        break;
                    }
                }
            }
            //down
            for (int i = row + 1; i <= 7; i++)
            {
                if (currentPosition.Position[i, col].Name != Names.None)
                {
                    if (currentPosition.Position[i, col].Name == Names.King && currentPosition.Position[i, col].Color != currentPlayer.Color)
                    {
                        return true; //chess
                    }
                    else
                    {
                        break;
                    }
                }
            }
            //left
            for (int i = col - 1; i >= 0; i--)
            {
                if (currentPosition.Position[row, i].Name != Names.None)
                {
                    if (currentPosition.Position[row, i].Name == Names.King && currentPosition.Position[row, i].Color != currentPlayer.Color)
                    {
                        return true; //chess
                    }
                    else
                    {
                        break;
                    }
                }
            }
            //right
            for (int i = col + 1; i <= 7; i++)
            {
                if (currentPosition.Position[row, i].Name != Names.None)
                {
                    if (currentPosition.Position[row, i].Name == Names.King && currentPosition.Position[row, i].Color != currentPlayer.Color)
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
