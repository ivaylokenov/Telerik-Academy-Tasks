using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarChessConsole
{
  public class InvalidInputException : ApplicationException
    
  {
           public InvalidInputException()
            : base()
        {
        }       

        public InvalidInputException(string message)
            : base(message)
        {
        }
  }
}
