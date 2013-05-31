using System;

namespace AcademyPopcorn
{
    //Task 5
    class TrailObject : GameObject
    {
        int Lifetime { get; set; }

        public override void Update()
        {
            if (this.Lifetime <= 1)
            {
                this.IsDestroyed = true;
            }

            this.Lifetime--;
        }

        public TrailObject(MatrixCoords topLeft, char[,] body, int lifetime) : base(topLeft, body)
        {
            this.Lifetime = lifetime;
        }
    }
}
