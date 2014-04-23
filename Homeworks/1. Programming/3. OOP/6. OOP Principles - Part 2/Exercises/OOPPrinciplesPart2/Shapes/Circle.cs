namespace Shapes
{
    class Circle:Shape
    {
        private decimal radius;

        public decimal Radius
        {
            get { return this.radius; }
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentException("Value must be positive number!");
                }

                this.radius = value;
            }
        }

        public Circle()
            : this(0)
        {
        }

        public Circle(decimal radius)
        {
            this.width = radius;
            this.height = radius;
            this.radius = radius;
        }

        public override decimal CalculateSurface()
        {
            return ((decimal)System.Math.PI) * this.radius * this.radius;
        }
    }
}
