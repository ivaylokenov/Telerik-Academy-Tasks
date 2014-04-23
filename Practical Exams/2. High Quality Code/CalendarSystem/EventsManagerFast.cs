namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class EventsManagerFast : IEventsManager
    {
        private readonly MultiDictionary<string, Event> titlesList = new MultiDictionary<string, Event>(true);
        private readonly OrderedMultiDictionary<DateTime, Event> datesList = new OrderedMultiDictionary<DateTime, Event>(true);

        /// <summary>
        /// Gets an MultiDictionary representing each event and its title as key.
        /// </summary>
        public MultiDictionary<string, Event> TitlesList
        {
            get
            {
                return this.titlesList;
            }
        }

        /// <summary>
        /// Gets an OrderedMultiDictionary representing each event and its date as key.
        /// </summary>
        public OrderedMultiDictionary<DateTime, Event> DatesList
        {
            get
            {
                return this.datesList;
            }
        }

        /// <summary>
        /// Adds to the current instance of EventManager a new event. Dublicate values are accepted.
        /// </summary>
        /// <param name="currentEvent">Event to be added. Must contain date and title. May contain location.</param>
        public void AddEvent(Event currentEvent)
        {
            this.titlesList.Add(currentEvent.Title.ToLowerInvariant(), currentEvent);
            this.datesList.Add(currentEvent.Date, currentEvent);
        }

        /// <summary>
        /// Deletes all events by matching title in EventManager.
        /// </summary>
        /// <param name="title">All events with the titles will be deleted.</param>
        /// <returns>Number of deleted events from EventManager.</returns>
        public int DeleteEventsByTitle(string title)
        {
            string searchedTitle = title.ToLowerInvariant();
            var toBeDeleted = this.titlesList[searchedTitle];
            int counter = toBeDeleted.Count;

            foreach (var currentEvent in toBeDeleted)
            {
                this.datesList.Remove(currentEvent.Date, currentEvent);
            }

            this.titlesList.Remove(searchedTitle);

            return counter;
        }

        /// <summary>
        /// Lists all events that appear from a certain date.
        /// </summary>
        /// <param name="date">Checks whether date of event is sooner than the parameter date.</param>
        /// <param name="count">How many events to return.</param>
        /// <returns>IEnumarable of selected events.</returns>
        public IEnumerable<Event> ListEvents(DateTime date, int count)
        {
            var selectedEvents =
                from selectedEvent in this.datesList.RangeFrom(date, true).Values
                orderby selectedEvent.Date, selectedEvent.Title, selectedEvent.Location
                select selectedEvent;

            var result = selectedEvents.Take(count);

            return result;
        }
    }
}
