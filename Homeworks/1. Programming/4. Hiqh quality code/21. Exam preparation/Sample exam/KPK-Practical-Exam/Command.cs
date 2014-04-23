namespace FreeContentCatalog
{
    using System;
    using System.Linq;
    using System.Text;

    public class Command : ICommand
    {
        private readonly char[] paramsSeparators = { ';' };
        private readonly char commandEnd = ':';

        private int commandNameEndIndex;

        public Command(string input)
        {
            this.OriginalForm = input.Trim();
            this.Parse();
        }

        public CommandType Type { get; set; }

        public string OriginalForm { get; set; }

        public string Name { get; set; }

        public string[] Parameters { get; set; }

        public CommandType ParseCommandType(string commandName)
        {
            CommandType type;

            if (commandName.Contains(':') || commandName.Contains(';'))
            {
                throw new FormatException("Command is not in valid format!");
            }

            switch (commandName.Trim())
            {
                case "Add book":
                    type = CommandType.AddBook;
                    break;

                case "Add movie":
                    type = CommandType.AddMovie;
                    break;

                case "Add song":
                    type = CommandType.AddSong;
                    break;

                case "Add application":
                    type = CommandType.AddApplication;
                    break;

                case "Update":
                    type = CommandType.Update;
                    break;

                case "Find":
                    type = CommandType.Find;
                    break;

                default:
                    throw new InvalidOperationException("Invalid command name!");
            }

            return type;
        }

        public string ParseName()
        {
            return this.OriginalForm.Substring(0, this.commandNameEndIndex);
        }

        public string[] ParseParameters()
        {
            int paramsLength = this.OriginalForm.Length - (this.commandNameEndIndex + 2);

            string paramsOriginalForm = this.OriginalForm.Substring(this.commandNameEndIndex + 2, paramsLength);

            string[] parameters = paramsOriginalForm.Split(this.paramsSeparators, StringSplitOptions.RemoveEmptyEntries);

            return parameters;
        }

        public int GetCommandNameEndIndex()
        {
            return this.OriginalForm.IndexOf(this.commandEnd);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(this.Name + " ");

            foreach (string param in this.Parameters)
            {
                result.Append(param + " ");
            }

            return result.ToString();
        }

        private void Parse()
        {
            this.commandNameEndIndex = this.GetCommandNameEndIndex();
            this.Name = this.ParseName();
            this.Parameters = this.ParseParameters();
            this.TrimParams();
            this.Type = this.ParseCommandType(this.Name);
        }

        private void TrimParams()
        {
            for (int i = 0; i < this.Parameters.Length; i++)
            {
                this.Parameters[i] = this.Parameters[i].Trim();
            }
        }
    }
}
