namespace CalendarSystem
{
    using System;

    public class StartProgram
    {
        public static void Main()
        {
            // first bottleneck - it is better to use the multidictionary (EventManagerFast) since removing a lot of elements in list is slow operation
            EventsManagerFast eventsManager = new EventsManagerFast();
            CommandProcessor commandProcessor = new CommandProcessor(eventsManager);

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End" || command == null)
                {
                    break;
                }

                try
                {
                    Console.WriteLine(commandProcessor.ProcessCommand(Command.Parse(command)));
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}