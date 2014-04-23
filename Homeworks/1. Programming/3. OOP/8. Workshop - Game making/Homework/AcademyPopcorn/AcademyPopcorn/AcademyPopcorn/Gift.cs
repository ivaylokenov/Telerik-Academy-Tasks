using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class Gift : MovingObject
    {
        private int lifeTime;

        public Gift(MatrixCoords topLeft, MatrixCoords direction, char[,] body)
            : base(topLeft, body, direction)
        {
            lifeTime = Console.BufferHeight;
        }

        protected override void UpdatePosition()
        {
            this.TopLeft += this.Speed;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override void Update()
        {
            base.Update();

            if (lifeTime == 0)
            {
                this.IsDestroyed = true;
            }

            lifeTime--;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {
                List<ShootingRacket> rackets = new List<ShootingRacket>();

                ShootingRacket shootingRacket = new ShootingRacket(
                    new MatrixCoords(this.TopLeft.Row + 1, this.TopLeft.Col), 6);
                rackets.Add(shootingRacket);

                return rackets;
            }
            else
            {
                return base.ProduceObjects();
            }
        }
    }
}
