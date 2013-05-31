using System;
using System.Text;
using Wintellect.PowerCollections;

public class EventHolder
{
    private readonly MultiDictionary<string, Event> compareByTitle = new MultiDictionary<string, Event>(true);
    private readonly OrderedBag<Event> compareByDate = new OrderedBag<Event>();

    public void AddEvent(DateTime date, string title, string location)
    {
        Event newEvent = new Event(date, title, location);
        this.compareByTitle.Add(title.ToLower(), newEvent);
        this.compareByDate.Add(newEvent); 
        Messages.EventAdded();
    }

    public void DeleteEvents(string titleToDelete)
    {
        string title = titleToDelete.ToLower();
        int removed = 0;

        foreach (var eventToRemove in this.compareByTitle[title])
        {
            removed++;
            this.compareByDate.Remove(eventToRemove);
        }

        this.compareByTitle.Remove(title);
        Messages.EventDeleted(removed);
    }

    public void ListEvents(DateTime date, int count)
    {
        OrderedBag<Event>.View eventsToShow = this.compareByDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
        int showed = 0;
        foreach (var eventToShow in eventsToShow)
        {
            if (showed == count)
            {
                break;
            }

            Messages.PrintEvent(eventToShow);
            showed++;
        }

        if (showed == 0)
        {
            Messages.NoEventsFound();
        }
    }
}