namespace CalendarSystem
{
    using System;
    using System.Globalization;

    public class Command
    {
        public string CommandName { get; set; }

        public string[] Parameters { get; set; }

        public static Command Parse(string command)
        {
            int separator = command.IndexOf(' ');

            if (separator == -1)
            {
                throw new InvalidOperationException("Command must be separated: " + command);
            }

            string commandName = command.Substring(0, separator);
            string[] arguments = command.Substring(separator + 1).Split('|');

            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = arguments[i].Trim();
            }

            Command resultCommand = new Command { CommandName = commandName, Parameters = arguments };

            return resultCommand;
        }
    }
}
