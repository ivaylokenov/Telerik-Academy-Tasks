namespace Abstraction
{
    using System;

    public abstract class Figure
    {
        public Figure(double width, double height)
        {
            if (width <= 0)
            {
                throw new ArgumentException("Width cannot be empty or less than zero.");
            }

            if (height <= 0)
            {
                throw new ArgumentException("Width cannot be empty or less than zero.");
            }

            this.Width = width;
            this.Height = height;
        }

        public virtual double Width { get; protected set; }

        public virtual double Height { get; protected set; }

        public abstract double CalcPerimeter();
        public abstract double CalcSurface();
    }
}
