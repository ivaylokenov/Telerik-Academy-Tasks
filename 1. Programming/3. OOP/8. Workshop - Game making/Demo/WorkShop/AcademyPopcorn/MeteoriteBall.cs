using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class MeteoriteBall : Ball, IObjectProducer
    {
        public MeteoriteBall(MatrixCoords firstCoords, MatrixCoords secondCoords)
            : base(firstCoords, secondCoords)
        {

        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            return new GameObject[] { new TrailObject(this.GetTopLeft(), new char[,] { { '*' } }, 2) };
        }
    }
}
