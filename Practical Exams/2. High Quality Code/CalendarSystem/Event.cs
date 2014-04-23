namespace CalendarSystem
{
    using System;

    public class Event : IComparable<Event>
    {
        public Event(DateTime date, string title, string location = null)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date { get; private set; }

        public string Title { get; private set; }

        public string Location { get; private set; }

        public override string ToString()
        {
            string form = "{0:yyyy-MM-ddTHH:mm:ss} | {1}";

            if (this.Location != null)
            {
                form += " | {2}";
            }

            return string.Format(form, this.Date, this.Title, this.Location);
        }

        public int CompareTo(Event otherEvent)
        {
            /*
             * there was a bottleneck here traversing for each character in this.Title 
             * which will be slow if title has a lot of characters. 
            */

            int result = DateTime.Compare(this.Date, otherEvent.Date);

            if (result == 0)
            {
                result = string.Compare(this.Title, otherEvent.Title, StringComparison.InvariantCulture);

                if (result == 0)
                {
                    result = string.Compare(this.Location, otherEvent.Location, StringComparison.InvariantCulture);
                }
            }

            return result;
        }
    }
}
