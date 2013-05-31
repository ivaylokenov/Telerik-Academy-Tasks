using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class TrailObject : GameObject
    {
        private int lifeTime;

        public TrailObject(MatrixCoords topleft, char[,] body, int lifeTime)
            : base(topleft, body)
        {
            this.lifeTime = lifeTime;
        }

        public override void Update()
        {
            if (this.lifeTime == 0)
            {
                this.IsDestroyed = true;
            }
            this.lifeTime--;
        }
    }
}
