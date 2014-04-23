using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryAPI
{
    public class ExtendedFigureController : FigureController
    {
        public override void ExecuteFigureCreationCommand(string[] splitFigString)
        {

            switch (splitFigString[0])
            {
                case "circle":
                    {
                        Vector3D center = Vector3D.Parse(splitFigString[1]);
                        currentFigure = new Circle(center, double.Parse(splitFigString[2]));
                        break;
                    }
                case "cylinder":
                    {
                        Vector3D bottom = Vector3D.Parse(splitFigString[1]);
                        Vector3D top = Vector3D.Parse(splitFigString[2]);
                        currentFigure = new Cylinder(bottom, top, double.Parse(splitFigString[3]));
                        break;
                    }
            }

            base.ExecuteFigureCreationCommand(splitFigString);
        }

        protected override void ExecuteFigureInstanceCommand(string[] splitCommand)
        {
            switch (splitCommand[0])
            {
                case "area":
                    {
                        if (this.currentFigure is IAreaMeasurable)
                        {
                            Console.WriteLine("{0:F2}", ((IAreaMeasurable)this.currentFigure).GetArea());
                        }
                        else
                        {
                            Console.WriteLine("undefined");
                        }
                        break;
                    }
                case "volume":
                    {
                        if (this.currentFigure is IVolumeMeasurable)
                        {
                            Console.WriteLine("{0:F2}", ((IVolumeMeasurable)this.currentFigure).GetVolume());
                        }
                        else
                        {
                            Console.WriteLine("undefined");
                        }
                        break;
                    }
                case "normal":
                    {
                        if (this.currentFigure is IFlat)
                        {
                            Console.WriteLine(((IFlat)this.currentFigure).GetNormal().ToString());
                        }
                        else
                        {
                            Console.WriteLine("undefined");
                        }
                        break;
                    }
            }

            base.ExecuteFigureInstanceCommand(splitCommand);
        }
    }
}
