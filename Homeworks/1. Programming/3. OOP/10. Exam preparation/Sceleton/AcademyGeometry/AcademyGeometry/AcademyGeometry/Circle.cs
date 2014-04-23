using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryAPI
{
    public class Circle : Figure, IFlat, IAreaMeasurable
    {
        private double Radius { get; set; }

        private Vector3D Center
        {
            get { return this.vertices[0]; }
            set { this.vertices[0] = value; }
        }

        public Circle(Vector3D center, double radius) : base (center)
        {
            this.Radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        public Vector3D GetNormal()
        {
            Vector3D center = this.Center;
            Vector3D A = new Vector3D(center.X + this.Radius, center.Y, center.Z),
                B = new Vector3D(center.X, center.Y + this.Radius, center.Z);

            Vector3D normal = Vector3D.CrossProduct(center - A, center - B);
            normal.Normalize();
            return normal;
        }

        public override double GetPrimaryMeasure()
        {
            return this.GetArea();
        }
    }
}
