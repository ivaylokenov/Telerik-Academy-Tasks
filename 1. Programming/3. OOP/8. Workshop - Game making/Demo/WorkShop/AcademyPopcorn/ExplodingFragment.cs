using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ExplodingFragment : Ball
    {
        private const int LifeTime = 1;
        private int lifeTime;

        public ExplodingFragment(MatrixCoords topLeft, MatrixCoords direction)
            : base(topLeft, direction)
        {
            this.lifeTime = LifeTime;
            this.body = new char[,] { { 'X' } };
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
