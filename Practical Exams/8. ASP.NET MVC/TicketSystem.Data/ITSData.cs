namespace TicketSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using TicketSystem.Model;

    public interface ITSData
    {
        IRepository<Category> Categories { get; }

        IRepository<Ticket> Tickets { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Author> Authors { get; }

        int SaveChanges();
    }
}
