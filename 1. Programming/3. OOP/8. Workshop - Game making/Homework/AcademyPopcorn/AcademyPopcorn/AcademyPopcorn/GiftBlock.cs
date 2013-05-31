using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class GiftBlock : Block
    {
        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body = new char[,] { { '8' } };
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> gift = new List<GameObject>(1);

            if (this.IsDestroyed)
            {
                MatrixCoords direction = new MatrixCoords(1, 0);
                gift.Add(new Gift(this.topLeft, direction, new char[,] { { '+' } }));
            }

            return gift;
        }
    }
}
