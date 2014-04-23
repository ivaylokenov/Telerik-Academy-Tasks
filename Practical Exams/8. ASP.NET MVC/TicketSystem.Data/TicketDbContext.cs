namespace TicketSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using TicketSystem.Model;

    public class TicketDbContext : IdentityDbContextWithCustomUser<Author>
    {
        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Ticket> Tickets { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        // public IDbSet<Author> Authors { get; set; }
    }
}
