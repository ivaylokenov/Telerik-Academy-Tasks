using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attribute
{
    [Version ("11.56")]
    class SampleClass
    {
        //11. Create a [Version] attribute that can be applied to 
        //structures, classes, interfaces, enumerations and methods 
        //and holds a version in the format major.minor (e.g. 2.11). Apply
        //the version attribute to a sample class and display 
        //its version at runtime.

        static void Main()
        {
            Type type = typeof(SampleClass);
            object[] attr = type.GetCustomAttributes(false);
            foreach (VersionAttribute item in attr)
            {
                Console.WriteLine(item.Version);
            }
        }
    }
}
