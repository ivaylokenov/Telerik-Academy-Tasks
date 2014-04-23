namespace TicketSystem.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Linq;
    using TicketSystem.Model;

    public class TicketDetailsViewModel
    {
        public static Expression<Func<Ticket, TicketDetailsViewModel>> FromTicket
        {
            get
            {
                return ticket => new TicketDetailsViewModel
                {
                    Id = ticket.Id,
                    Title = ticket.Title,
                    Category = ticket.Category.Name,
                    Author = ticket.Author.UserName,
                    Description = ticket.Description,
                    Priority = ticket.Priority,
                    ScreenshotUrl = ticket.ScreenshotUrl,
                    Comments = ticket.Comments.AsQueryable().Select(CommentViewModel.FromComment)
                };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Priority Priority { get; set; }

        public string Author { get; set; }

        public string ScreenshotUrl { get; set; }

        public string Category { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}