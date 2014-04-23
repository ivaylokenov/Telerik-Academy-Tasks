using System;
using System.Linq;

namespace StarChessConsole
{
    public abstract class Figure : StarChessConsole.Interfaces.IMovable, Interfaces.ICollision
    {
        protected Colors color;

        protected Names name;

        public Colors Color 
        {
            get { return this.color; }
            protected set { this.color = value; }
        }
        public Names Name 
        { 
            get { return this.name; }
            protected set { this.name = value; }
        }
        
        public Figure(Colors color, Names name) 
        {
            this.color = color;
            this.name = name;
        }

        public virtual bool MakesChess(int row, int col, Player currentPlayer, FigurePositions currentPosition) 
        {
            return false;
        }

        public abstract bool MoveFigure(string coordinates, FigurePositions currentPosition);
        
        public abstract void MakeQueen();

        public void GetFigure(FigurePositions currentPosition, int nextRow, int nextCol)
        {
            if (StartProgram.CurrentPlayer == "white")
            {
                StartProgram.WhitePlayer.AddTakenFigure(currentPosition.Position[nextRow, nextCol].Name);
            }
            else
            {
                StartProgram.BlackPlayer.AddTakenFigure(currentPosition.Position[nextRow, nextCol].Name);
            }
        }
    }
}
