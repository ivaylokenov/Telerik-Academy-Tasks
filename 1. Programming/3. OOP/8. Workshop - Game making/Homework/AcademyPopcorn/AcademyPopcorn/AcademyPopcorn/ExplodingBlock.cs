using System;
using System.Collections.Generic;

namespace AcademyPopcorn
{
    class ExplodingBlock : Block
    {
        public const char Symbol = 'X';

        public ExplodingBlock(MatrixCoords topLeft) : base(topLeft)
        {
            this.body[0, 0] = 'X';
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
            ProduceObjects();
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> fragments = new List<GameObject>(8);
            if (this.IsDestroyed)
            {
                for (int row = -1; row <= 1; row++)
                {
                    for (int col = -1; col <= 1; col++)
                    {
                        if (row == 0 && col == 0)
                        {
                            continue;
                        }

                        fragments.Add(new Explosion(
                            new MatrixCoords(this.TopLeft.Row + row, this.TopLeft.Col + col),
                            new MatrixCoords(0, 0)
                            ));
                    }
                }
            }

            return fragments;
        }
    }
}
