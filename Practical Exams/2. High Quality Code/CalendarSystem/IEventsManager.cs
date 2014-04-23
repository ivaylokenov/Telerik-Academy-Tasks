namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;

    public interface IEventsManager
    {
        /// <summary>
        /// Adds to the current instance of IEventManager a new event. Dublicate values are accepted.
        /// </summary>
        /// <param name="aeventToBeAdded"></param>
        void AddEvent(Event aeventToBeAdded);

        /// <summary>
        /// Deletes all events by matching title in EventManager.
        /// </summary>
        /// <param name="title">All events with the titles will be deleted.</param>
        /// <returns>Number of deleted events from EventManager.</returns>
        int DeleteEventsByTitle(string title);

        /// <summary>
        /// Lists all events that appear from a certain date.
        /// </summary>
        /// <param name="date">Checks whether date of event is sooner than the parameter date.</param>
        /// <param name="count">How many events to return.</param>
        /// <returns>IEnumarable of selected events.</returns>
        IEnumerable<Event> ListEvents(DateTime date, int count);
    }
}
