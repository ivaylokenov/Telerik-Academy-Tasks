namespace Point3D
{
    public struct Point3DCoordinates
    {
        //coordinates
        private decimal x;
        private decimal y;
        private decimal z;

        //start of system
        private static readonly Point3DCoordinates startOfCordinateSystem = new Point3DCoordinates(0, 0, 0);

        //x property
        public decimal X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        //y property
        public decimal Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        //z property
        public decimal Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        //constructor
        public Point3DCoordinates(decimal x, decimal y, decimal z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        //start of coordination system
        public static Point3DCoordinates StartOfCordinateSystem
        {
            get { return startOfCordinateSystem; }
        }

        //override of tostring
        public override string ToString()
        {
            return string.Format("Point: {0}, {1}, {2}", this.X, this.Y, this.Z);
        }
    }
}