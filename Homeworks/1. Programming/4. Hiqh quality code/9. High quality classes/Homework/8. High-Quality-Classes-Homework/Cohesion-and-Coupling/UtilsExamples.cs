using System;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileExtensionMethods.GetFileExtension("example"));
            Console.WriteLine(FileExtensionMethods.GetFileExtension("example.pdf"));
            Console.WriteLine(FileExtensionMethods.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileExtensionMethods.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileExtensionMethods.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileExtensionMethods.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                Distance.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                Distance.CalcDistance3D(5, 2, -1, 3, -6, 4));

            FigureGeometry figure = new FigureGeometry();

            figure.Width = 3;
            figure.Height = 4;
            figure.Depth = 5;
            Console.WriteLine("Volume = {0:f2}", figure.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", figure.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", figure.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", figure.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", figure.CalcDiagonalYZ());
        }
    }
}
