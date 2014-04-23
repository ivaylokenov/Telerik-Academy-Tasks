using System;
using System.Linq;

namespace StarChessConsole.Interfaces
{
    interface IMovable
    {
        bool MoveFigure(string coordinates, FigurePositions currentPosition);  //Moving figure if input is right
        void MakeQueen();     //Get queen if pawn reached the end of the Black
    }
}
