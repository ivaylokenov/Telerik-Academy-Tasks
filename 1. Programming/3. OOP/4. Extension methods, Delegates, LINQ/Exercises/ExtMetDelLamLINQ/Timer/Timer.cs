using System;
using System.Threading;

namespace Timer
{
    class Timer
    {
        //fields of timer
        public delegate void MethodsToExecute();
        public MethodsToExecute MethodsInTimer;
        private readonly int interval = 0; //interval between executions
        private readonly int totalTime; //total time to be executed
        private int counter = 1; //counter of executions

        //constructors
        public Timer(int interval, int totalTime)
        {
            this.interval = interval;
            this.totalTime = totalTime;
        }

        public Timer() : this(0, 25) { }

        //counter property
        public int Counter
        {
            get { return this.counter; }
        }

        //start of timer
        public void Start()
        {
            DateTime end = DateTime.Now.AddSeconds(totalTime);
            while (DateTime.Now < end)
            {
                MethodsInTimer();
                Thread.Sleep(interval * 1000);
                counter++;
            }
        }
    }
}
