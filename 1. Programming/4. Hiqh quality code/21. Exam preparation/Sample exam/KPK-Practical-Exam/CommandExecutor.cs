namespace FreeContentCatalog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog catalog, ICommand command, StringBuilder stringbuilder)
        {
            switch (command.Type)
            {
                case CommandType.AddBook:

                    catalog.Add(new Content(ContentType.Book, command.Parameters));
                    stringbuilder.AppendLine("Book added");
                    break;

                case CommandType.AddMovie:
                    catalog.Add(new Content(ContentType.Movie, command.Parameters));
                    stringbuilder.AppendLine("Movie added");

                    break;

                case CommandType.AddSong:
                    catalog.Add(new Content(ContentType.Song, command.Parameters));
                    stringbuilder.AppendLine("Song added");
                    break;

                case CommandType.AddApplication:
                    catalog.Add(new Content(ContentType.Application, command.Parameters));
                    stringbuilder.AppendLine("Application added");
                    break;

                case CommandType.Update:
                    this.UpdateCommand(ref command, ref stringbuilder, ref catalog);
                    break;

                case CommandType.Find:
                    this.FindCommand(ref command, ref stringbuilder, ref catalog);
                    break;

                default:
                    {
                        throw new InvalidOperationException("Unknown command!");
                    }
            }
        }

        private void UpdateCommand(ref ICommand command, ref StringBuilder stringbuilder, ref ICatalog catalog)
        {
            if (command.Parameters.Length != 2)
            {
                throw new ArgumentOutOfRangeException("Parameters should be two!");
            }

            int itemsUpdated = catalog.UpdateContent(command.Parameters[0], command.Parameters[1]);

            stringbuilder.AppendLine(string.Format("{0} items updated", itemsUpdated));
        }

        private void FindCommand(ref ICommand command, ref StringBuilder stringbuilder, ref ICatalog catalog)
        {
            if (command.Parameters.Length != 2)
            {
                throw new Exception("Invalid number of parameters!");
            }

            int numberOfElementsToList = int.Parse(command.Parameters[1]);

            IEnumerable<IContent> foundContent = catalog.GetListContent(command.Parameters[0], numberOfElementsToList);

            if (foundContent.Count() == 0)
            {
                stringbuilder.AppendLine("No items found");
            }
            else
            {
                foreach (IContent content in foundContent)
                {
                    stringbuilder.AppendLine(content.TextRepresentation);
                }
            }
        }
    }
}
