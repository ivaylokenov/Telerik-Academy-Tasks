namespace CalendarSystem
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class CommandProcessor
    {
        private readonly IEventsManager eventManager;

        public CommandProcessor(IEventsManager eventManager)
        {
            this.eventManager = eventManager;
        }

        public IEventsManager EventsManager
        {
            get
            {
                return this.eventManager;
            }
        }

        public string ProcessCommand(Command command)
        {
            if ((command.CommandName == "AddEvent") && (command.Parameters.Length == 2))
            {
                this.AddEventWithoutLocation(command);
                return "Event added";
            }

            if ((command.CommandName == "AddEvent") && (command.Parameters.Length == 3))
            {
                this.AddEventWithLocation(command);
                return "Event added";
            }

            if ((command.CommandName == "DeleteEvents") && (command.Parameters.Length == 1))
            {
                int count = this.DeleteEvents(command);

                if (count == 0)
                {
                    return "No events found";
                }

                return count + " events deleted";
            }

            if ((command.CommandName == "ListEvents") && (command.Parameters.Length == 2))
            {
                return this.ListEvents(command);
            }

            throw new InvalidOperationException("Unknown command: " + command.CommandName);
        }

        private void AddEventWithoutLocation(Command command)
        {
            DateTime date = DateTime.ParseExact(command.Parameters[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);

            Event currentEvent = new Event(date, command.Parameters[1]);

            this.eventManager.AddEvent(currentEvent);
        }

        private void AddEventWithLocation(Command command)
        {
            DateTime date = DateTime.ParseExact(command.Parameters[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            
            Event currentEvent = new Event(date, command.Parameters[1], command.Parameters[2]);
            
            this.eventManager.AddEvent(currentEvent);
        }

        private int DeleteEvents(Command command)
        {
            int count = this.eventManager.DeleteEventsByTitle(command.Parameters[0]);

            return count;
        }

        private string ListEvents(Command command)
        {
            DateTime date = DateTime.ParseExact(command.Parameters[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            int count = int.Parse(command.Parameters[1]);
            var events = this.eventManager.ListEvents(date, count).ToList();
            StringBuilder result = new StringBuilder();

            if (!events.Any())
            {
                return "No events found";
            }

            foreach (var currentEvent in events)
            {
                result.AppendLine(currentEvent.ToString());
            }

            return result.ToString().Trim();
        }
    }
}
