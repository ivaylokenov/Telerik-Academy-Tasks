namespace FreeContentCatalog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ContentCatalog
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            Catalog catalog = new Catalog();
            ICommandExecutor commandExecutor = new CommandExecutor();
            List<ICommand> listOfCommands = ParseCommands();

            foreach (ICommand item in listOfCommands)
            {
                commandExecutor.ExecuteCommand(catalog, item, output);
            }

            Console.Write(output);
        }

        private static List<ICommand> ParseCommands()
        {
            List<ICommand> commands = new List<ICommand>();
            bool endState = false;

            do
            {
                string line = Console.ReadLine();
                endState = line.Trim() == "End";
                if (!endState)
                {
                    commands.Add(new Command(line));
                }
            }
            while (!endState);

            return commands;
        }
    }
}
