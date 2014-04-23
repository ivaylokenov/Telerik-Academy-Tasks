using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // I could not make the racket to shoot no matter that I implemented the class... 
    //Please point my mistake in homework evaluation :)
    public class ShootingRacket : Racket
    {
        private bool hasFired = false;

        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
        }

        public void Shoot()
        {
            this.hasFired = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.hasFired)
            {
                this.hasFired = false;

                List<Bullet> bullets = new List<Bullet>();

                Bullet bullet = new Bullet(
                    new MatrixCoords(this.TopLeft.Row - 2, this.TopLeft.Col + this.Width / 2));

                bullets.Add(bullet);

                return bullets;
            }
            else
            {
                return base.ProduceObjects();
            }
        }
    }
}
