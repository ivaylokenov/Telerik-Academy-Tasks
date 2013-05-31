namespace EventsTimer
{
    public delegate void TimeElapsedEvent(object sender, EventArgsClass e);

    public class EventArgsClass : System.EventArgs
    {
        private int ticks;

        public int Ticks
        {
            get { return this.ticks; }
        }

        public EventArgsClass(int ticks)
        {
            this.ticks = ticks;
        }
    }
}
