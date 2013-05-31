using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryAPI
{
    class Cylinder : Figure, IVolumeMeasurable, IAreaMeasurable
    {
        private double radius;

        public Vector3D Bottom
        {
            get { return new Vector3D(vertices[0].X, vertices[0].Y, vertices[0].Z); }
            set { this.vertices[0] = new Vector3D(value.X, value.Y, value.Z); }
        }

        public Vector3D Top
        {
            get { return new Vector3D(vertices[1].X, vertices[1].Y, vertices[1].Z); }
            set { this.vertices[1] = new Vector3D(value.X, value.Y, value.Z); }
        }

        public double Radius
        {
            get { return this.radius; }
            set { this.radius = value; }
        }

        public Cylinder(Vector3D bottom, Vector3D top, double radius) : base (bottom, top)
        {
            this.Radius = radius;
        }

        public double GetArea()
        {
            double baseArea = this.Radius * this.Radius * Math.PI;
            double topAndBottomArea = baseArea * 2;

            double basePerimeter = 2 * Math.PI * this.Radius;

            double sideArea = basePerimeter * (this.Top - this.Bottom).Magnitude;

            return sideArea + topAndBottomArea;
        }

        public double GetVolume()
        {
            return this.Radius * this.Radius * Math.PI * (this.Top - this.Bottom).Magnitude;
        }

        public override double GetPrimaryMeasure()
        {
            return this.GetVolume();
        }
    }
}
