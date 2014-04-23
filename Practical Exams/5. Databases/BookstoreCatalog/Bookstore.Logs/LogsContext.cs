using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Logs
{
    public class LogsContext : DbContext
    {
        public LogsContext()
            : base("Logs")
        {
        }

        public DbSet<Log> Logs { get; set; }
    }
}
