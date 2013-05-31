namespace AcademyPopcorn
{
    class UnstopableBall : Ball
    {
        public new const string CollisionGroupString = "unstoppableBall";

        public UnstopableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket" || otherCollisionGroupString == "block"
               || otherCollisionGroupString == "IndestructableBlock" || otherCollisionGroupString == "UnpasableBlock";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            for (int i = 0; i < collisionData.hitObjectsCollisionGroupStrings.Count; i++)
            {
                if (collisionData.hitObjectsCollisionGroupStrings[i] == "racket" ||
                    collisionData.hitObjectsCollisionGroupStrings[i] == "IndestructableBlock" ||
                    collisionData.hitObjectsCollisionGroupStrings[i] == "UnpasableBlock")
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
}