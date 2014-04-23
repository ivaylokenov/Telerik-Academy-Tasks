namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EventsManager : IEventsManager
    {
        private readonly List<Event> eventCollection = new List<Event>();

        /// <summary>
        /// Adds to the current instance of EventManager a new event. Dublicate values are accepted.
        /// </summary>
        /// <param name="currentEvent">Event to be added. Must contain date and title. May contain location.</param>
        public void AddEvent(Event eventToBeAdded)
        {
            this.eventCollection.Add(eventToBeAdded);
        }

        /// <summary>
        /// Deletes all events by matching title in EventManager.
        /// </summary>
        /// <param name="title">All events with the titles will be deleted.</param>
        /// <returns>Number of deleted events from EventManager.</returns>
        public int DeleteEventsByTitle(string title)
        {
            // this may be a bottleneck beacuse RemoveAll operation is slow and builds new list
            return this.eventCollection.RemoveAll(
                selectedEvent => selectedEvent.Title.ToLowerInvariant() == title.ToLowerInvariant());
        }

        /// <summary>
        /// Lists all events that appear from a certain date.
        /// </summary>
        /// <param name="date">Checks whether date of event is sooner than the parameter date.</param>
        /// <param name="count">How many events to return.</param>
        /// <returns>IEnumarable of selected events.</returns>
        public IEnumerable<Event> ListEvents(DateTime date, int counter)
        {
            return (from selectedEvent in this.eventCollection
                    where selectedEvent.Date >= date
                    orderby selectedEvent.Date, selectedEvent.Title, selectedEvent.Location
                    select selectedEvent).Take(counter);
        }
    }
}
