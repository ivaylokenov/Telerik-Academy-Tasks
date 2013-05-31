using System.IO;

namespace Point3D
{

    static class PathStorage
    {
        //files to be read or written
        private static readonly StreamReader readFile = new StreamReader(@"..\..\CoordinatesIn.pts");
        private static readonly StreamWriter writeFile = new StreamWriter(@"..\..\CoordinatesOut.pts");

        //load file
        public static Path LoadFile()
        {
            Path currentPath = new Path();

            using (readFile)
            {
                string line = readFile.ReadLine();

                while (line != null)
                {
                    string[] numbers = line.Split(' ');

                    Point3DCoordinates currentPoint = new Point3DCoordinates()
                    {
                        X = decimal.Parse(numbers[0]),
                        Y = decimal.Parse(numbers[1]),
                        Z = decimal.Parse(numbers[2])
                    };

                    currentPath.AddPoint(currentPoint);

                    line = readFile.ReadLine();
                }
            }

            return currentPath;
        }

        //save file
        public static void SaveFile(Path currentPath)
        {
            using (writeFile)
            {
                foreach (var item in currentPath.path)
                {
                    string toBeWritten = string.Format("{0} {1} {2}", item.X, item.Y, item.Z);
                    writeFile.WriteLine(toBeWritten);
                }
            }
        }
    }
}