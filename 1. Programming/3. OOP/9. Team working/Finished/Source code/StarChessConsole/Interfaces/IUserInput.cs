using System;
using System.Linq;

namespace StarChessConsole.Interfaces
{
    interface IUserInput
    {
        void Rocade();               //Method for making rocades(long or short)
        string GetFieldCoordinates();  //Method for moving the figures at positions
        bool ValidateInput(); //validates the input
    }
}
