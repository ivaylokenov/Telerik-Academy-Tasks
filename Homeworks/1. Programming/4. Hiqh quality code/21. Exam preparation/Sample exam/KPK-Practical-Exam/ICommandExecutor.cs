namespace FreeContentCatalog
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICommandExecutor
    {
        void ExecuteCommand(ICatalog contentCatalog, ICommand command, StringBuilder output);
    }
}
