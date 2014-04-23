using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace StarChessConsole
{
    class Timer
    {
        private DateTime startCounting;
        private TimeSpan set;

        public Timer(int minutes)
        {
            this.set = new TimeSpan(0,minutes,0);
        }

        public TimeSpan Set
        {
            get { return this.set; }
        }

        public DateTime StartCounting
        {
            get { return this.startCounting; }
            set { this.startCounting = value; }
        }

        public TimeSpan Elapsed
        {
            get { return this.CalculateElapsed(); }
        }

        private TimeSpan CalculateElapsed()
        {
            return DateTime.Now - this.startCounting;
        }
    }
}
