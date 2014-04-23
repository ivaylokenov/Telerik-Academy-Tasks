using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class IndestructibleBlock : Block
    {
        public new const string CollisionGroupString = "indestructible";

        public const char Symbol = '|';

        public IndestructibleBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = IndestructibleBlock.Symbol;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            //base.RespondToCollision(collisionData);
        }

        public override string GetCollisionGroupString()
        {
            return IndestructibleBlock.CollisionGroupString;
        }
    }
}
