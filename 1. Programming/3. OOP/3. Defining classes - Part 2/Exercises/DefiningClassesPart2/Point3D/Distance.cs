using System;

namespace Point3D
{
    static class Distance
    {
        //calculating distance between points

        public static decimal DistanceBetweenPoints(Point3DCoordinates first, Point3DCoordinates second)
        {
            decimal xd = first.X - second.X;
            decimal yd = first.Y - second.Y;
            decimal zd = first.Z - second.Z;

            return (decimal)Math.Sqrt((double)(xd * xd + yd * yd + zd * zd));
        }
    }
}
