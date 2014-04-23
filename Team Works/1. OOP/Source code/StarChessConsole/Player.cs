using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace StarChessConsole
{
    public class Player
    {
        private string name;
        private readonly Colors color;

        private List<Names> takenFigures;

        public List<Names> TakenFigures 
        {
            get { return this.takenFigures; }
        } 

        public Player(string name, Colors color)  //constructor
        {
            this.name = name;
            this.color = color;
            this.takenFigures = new List<Names>();
        }

        public void AddTakenFigure(Names name)
        {
            this.takenFigures.Add(name);
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public Colors Color
        {
            get { return this.color; }
        }

    }
}
