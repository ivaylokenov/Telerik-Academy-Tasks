using System.Collections.Generic;

namespace Point3D
{
    class Path
    {
        public List<Point3DCoordinates> path = new List<Point3DCoordinates>();

        //add point to path
        public void AddPoint(Point3DCoordinates point)
        {
            path.Add(point);
        }

        //remove point from path
        public void RemovePoint(Point3DCoordinates point)
        {
            path.Remove(point);
        }
    }
}
