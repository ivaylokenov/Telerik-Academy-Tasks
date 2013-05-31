using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class UnstoppableBall : Ball
    {
        public UnstoppableBall(MatrixCoords topleft, MatrixCoords direction)
            : base(topleft, direction)
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket" || otherCollisionGroupString == "indestructible" ||
                otherCollisionGroupString == "block";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            if (collisionData.hitObjectsCollisionGroupStrings.Contains("indestructible") ||
                collisionData.hitObjectsCollisionGroupStrings.Contains("racket") ||
                collisionData.hitObjectsCollisionGroupStrings.Contains("impassble"))
            {
                if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0)
                {

                    this.Speed.Row *= -1;
                }
                if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0)
                {
                    this.Speed.Col *= -1;
                }
            }
        }
    }
}
