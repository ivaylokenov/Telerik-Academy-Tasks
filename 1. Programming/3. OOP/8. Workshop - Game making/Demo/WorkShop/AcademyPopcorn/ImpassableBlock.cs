using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ImpassableBlock : IndestructibleBlock
    {
        public new const string CollisionGroupString = "impassble";
        public new const char Symbol = '$';

        public ImpassableBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = ImpassableBlock.Symbol;
        }

        public override string GetCollisionGroupString()
        {
            return ImpassableBlock.CollisionGroupString;
        }
    }
}
