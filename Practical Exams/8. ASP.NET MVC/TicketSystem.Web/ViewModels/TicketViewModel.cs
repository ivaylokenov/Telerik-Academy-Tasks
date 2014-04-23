namespace TicketSystem.Web.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using TicketSystem.Model;

    public class TicketViewModel
    {
        public static Expression<Func<Ticket, TicketViewModel>> FromTicket
        {
            get
            {
                return ticket => new TicketViewModel
                {
                    Id = ticket.Id,
                    Title = ticket.Title,
                    Author = ticket.Author.UserName,
                    Category = ticket.Category.Name,
                    CommentsCount = ticket.Comments.Count
                };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public int CommentsCount { get; set; }
    }
}