namespace StarChessConsole
{
    public static class ChessChecker
    {
        public static bool ChessValidator(FigurePositions currentPositions)
        {
            bool hasCheck = false;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Names currentFigureName = currentPositions.Position[i, j].Name;

                    if (currentFigureName == Names.None)
                    {
                        continue;
                    }

                    Colors currentFigureColors = currentPositions.Position[i, j].Color;
                    Player currentPlayer;

                    if (currentFigureColors == Colors.White)
                    {
                        currentPlayer = StartProgram.WhitePlayer;
                    }
                    else
                    {
                        currentPlayer = StartProgram.BlackPlayer;
                    }

                    if (currentFigureName == Names.Pawn)
                    {
                        Pawn pawn = new Pawn(currentFigureColors, currentFigureName);
                        hasCheck = pawn.MakesChess(i, j, currentPlayer, currentPositions);
                    }
                    else if (currentFigureName == Names.Bishop)
                    {
                        Bishop bishop = new Bishop(currentFigureColors, currentFigureName);
                        hasCheck = bishop.MakesChess(i, j, currentPlayer, currentPositions);
                    }
                    else if (currentFigureName == Names.Rook)
                    {
                        Rook rook = new Rook(currentFigureColors, currentFigureName);
                        hasCheck = rook.MakesChess(i, j, currentPlayer, currentPositions);
                    }
                    else if (currentFigureName == Names.Queen)
                    {
                        Queen queen = new Queen(currentFigureColors, currentFigureName);
                        hasCheck = queen.MakesChess(i, j, currentPlayer, currentPositions);
                    }
                    else if (currentFigureName == Names.King)
                    {
                        King king = new King(currentFigureColors, currentFigureName);
                        hasCheck = king.MakesChess(i, j, currentPlayer, currentPositions);
                    }
                    else if (currentFigureName == Names.Knight)
                    {
                        Knight knight = new Knight(currentFigureColors, currentFigureName);
                        hasCheck = knight.MakesChess(i, j, currentPlayer, currentPositions);
                    }

                    if (hasCheck)
                    {
                        return hasCheck;
                    }
                }
            }

            return hasCheck;
        }
    }
}
