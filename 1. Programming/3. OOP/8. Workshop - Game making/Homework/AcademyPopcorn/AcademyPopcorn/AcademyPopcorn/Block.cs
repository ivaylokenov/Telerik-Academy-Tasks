using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class Block : GameObject
    {
        public new const string CollisionGroupString = "block";

        public Block(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '#' } })
        {

        }

        public override void Update()
        {
            
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "ball";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override string GetCollisionGroupString()
        {
            return Block.CollisionGroupString;
        }
    }
}
