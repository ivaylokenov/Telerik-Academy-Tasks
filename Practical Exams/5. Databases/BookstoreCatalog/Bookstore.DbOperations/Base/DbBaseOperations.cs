namespace Bookstore.DbOperations.Base
{
    using System;
    using Bookstore.Data;
    using Bookstore.Logs;

    public class DbBaseOperations
    {
        private BookstoreEntities dbContext;
        private LogsContext logContext;

        public DbBaseOperations()
        {
            dbContext = new BookstoreEntities();
            logContext = new LogsContext();
        }

        public BookstoreEntities DBContext
        {
            get 
            {
                return this.dbContext;
            }
        }

        public LogsContext LogContext
        {
            get
            {
                return this.logContext;
            }
        }

        public virtual void SaveChanges()
        {
            this.dbContext.SaveChanges();
            this.logContext.SaveChanges();
        }
    }
}
