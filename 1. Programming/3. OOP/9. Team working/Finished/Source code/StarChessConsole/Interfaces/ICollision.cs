using System;
using System.Linq;

namespace StarChessConsole.Interfaces
{
    interface ICollision
    {
        void GetFigure(FigurePositions currentPosition, int nextRow, int nextCol);     //Gets the opponent's figure
    }
}
