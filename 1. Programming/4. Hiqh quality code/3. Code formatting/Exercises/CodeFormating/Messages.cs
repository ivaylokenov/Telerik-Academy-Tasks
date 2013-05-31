using System.Text;

public static class Messages
{
    public static readonly StringBuilder Output = new StringBuilder();

    public static void EventAdded()
    {
        Output.Append("Event added\n");
    }

    public static void EventDeleted(int eventCount)
    {
        if (eventCount == 0)
        {
            NoEventsFound();
        }
        else
        {
            Output.AppendFormat("{0} events deleted\n", eventCount);
        }
    }

    public static void NoEventsFound()
    {
        Output.Append("No events found\n");
    }

    public static void PrintEvent(Event eventToPrint)
    {
        if (eventToPrint != null)
        {
            Output.Append(eventToPrint + "\n");
        }
    }
}