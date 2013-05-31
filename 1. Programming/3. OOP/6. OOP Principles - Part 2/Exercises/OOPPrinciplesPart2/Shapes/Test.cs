using System;

namespace Shapes
{
    class Test
    {
        static void Main()
        {
            //array of shapes
            Shape[] shapes = 
                {
                    new Triangle(5, 7.8m),
                    new Circle(),
                    new Circle(5.6m),
                    new Rectangle(),
                    new Triangle(4.5m, 3),
                    new Rectangle(3.5m, 2)
                };

            //calculate durfaces to all shapes
            for (int i = 0; i < shapes.Length; i++)
            {
                Console.Write(shapes[i].GetType() + ": ");
                Console.WriteLine(shapes[i].CalculateSurface()); 
            }
        }
    }
}
