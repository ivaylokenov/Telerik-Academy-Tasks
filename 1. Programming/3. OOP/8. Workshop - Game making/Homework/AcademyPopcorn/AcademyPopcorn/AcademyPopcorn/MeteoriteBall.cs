namespace AcademyPopcorn
{
    //Task 6
    class MeteoriteBall : Ball
    {
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
        }

        //Task 7
        public override System.Collections.Generic.IEnumerable<GameObject> ProduceObjects()
        {
            TrailObject trail = new TrailObject(this.topLeft, new char[,] { { '.' } }, 3);
            System.Collections.Generic.List<GameObject> trails = new System.Collections.Generic.List<GameObject>();
            trails.Add(trail);
            return trails;
        }
    }
}
