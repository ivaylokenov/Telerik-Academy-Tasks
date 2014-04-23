namespace Shapes
{
    abstract class Shape
    {
        protected decimal width;
        protected decimal height;

        public abstract decimal CalculateSurface();
    }
}
