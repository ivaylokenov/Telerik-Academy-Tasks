using System;
using System.Collections.Generic;

namespace Point3D
{
    //1. Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} 
    //in the Euclidian 3D space. Implement the ToString() to enable printing a 3D point.

    //2. Add a private static read-only field to hold the start 
    //of the coordinate system – the point O{0, 0, 0}. Add a static property to return the point O.

    //3. Write a static class with a static method to calculate 
    //the distance between two points in the 3D space.

    //4. Create a class Path to hold a sequence of points in the 
    //3D space. Create a static class PathStorage with static methods to save and load paths from a text file. Use a file format of your choice.


    class Point3DTest
    {
        static void Main()
        {
            //just for testing the classes and structures

            Path newPath = PathStorage.LoadFile();
            Point3DCoordinates point = new Point3DCoordinates(1,2,6);

            newPath.AddPoint(point);

            foreach (var item in newPath.path)
            {
                Console.WriteLine(item.ToString());
            }

            PathStorage.SaveFile(newPath);

            Point3DCoordinates first = new Point3DCoordinates(1, 2, 3);
            Point3DCoordinates second = new Point3DCoordinates(1, 5, 8);

            Console.WriteLine(Distance.DistanceBetweenPoints(first, second));
        }
    }
}
