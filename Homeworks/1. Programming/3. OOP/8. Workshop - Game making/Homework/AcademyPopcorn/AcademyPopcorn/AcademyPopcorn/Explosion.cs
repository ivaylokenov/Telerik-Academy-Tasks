namespace AcademyPopcorn
{
    class Explosion : Ball
    {
        private const int LifeTime = 1;
        private int lifeTime;

        public Explosion(MatrixCoords topLeft, MatrixCoords direction)
            : base(topLeft, direction)
        {
            this.lifeTime = LifeTime;
            this.body = new char[,] { { '.' } };
        }

        public override void Update()
        {
            if (this.lifeTime == 0)
            {
                this.IsDestroyed = true;
            }
            this.lifeTime--;
        }

        protected override void UpdatePosition()
        {
            //base.UpdatePosition();
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return base.CanCollideWith(otherCollisionGroupString);
        }

    }
}
