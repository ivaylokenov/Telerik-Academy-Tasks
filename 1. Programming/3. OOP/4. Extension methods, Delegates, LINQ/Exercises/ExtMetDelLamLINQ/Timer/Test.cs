using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
    class Test
    {
        //07. Using delegates write a class Timer that has can execute certain method at each t seconds.

        static void Main()
        {
            Timer testingTimer = new Timer(1, 10);

            //add method to execute
            testingTimer.MethodsInTimer = delegate()
            {
                Console.Write("Executed!");
            };

            //add another method
            testingTimer.MethodsInTimer += delegate()
            {
                Console.WriteLine(" Counter: {0}", testingTimer.Counter);
            };

            //test
            testingTimer.Start();
        }
    }
}
