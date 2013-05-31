namespace AcademyPopcorn
{
    public class Bullet : MovingObject
    {
        public new const string CollisionGroupString = "bullet";

        public Bullet(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '|' } }, new MatrixCoords(-1, 0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == Block.CollisionGroupString;
        }

        public override string GetCollisionGroupString()
        {
            return Bullet.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
    }
}
