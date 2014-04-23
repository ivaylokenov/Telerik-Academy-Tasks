namespace EventsTimer
{
    class Timer
    {
        public event TimeElapsedEvent ElapsedTime;

        private int totalTicks;
        private int interval;

        public int TotalTicks
        {
            get { return this.totalTicks; }
        }

        public int Interval
        {
            get { return this.interval; }
        }

        public Timer(int totalTicks, int interval)
        {
            this.interval = interval;
            this.totalTicks = totalTicks;
        }

        public void OnTime(int ticks)
        {
            if (ElapsedTime != null)
            {
                EventArgsClass e = new EventArgsClass(ticks);
                ElapsedTime(this, e);
            }
        }

        public void Run()
        {
            int ticks = this.totalTicks;

            while (ticks > 0)
            {
                System.Threading.Thread.Sleep(this.interval);
                ticks--;
                OnTime(ticks);
            }
        }
    }
}
