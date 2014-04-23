using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using TicketSystem.Model;
namespace TicketSystem.Web.ViewModels
{
    public class ListTicketViewModel
    {
        public static Expression<Func<Ticket, ListTicketViewModel>> FromTicket
        {
            get
            {
                return ticket => new ListTicketViewModel
                {
                    Id = ticket.Id,
                    Title = ticket.Title,
                    Author = ticket.Author.UserName,
                    Category = ticket.Category.Name,
                    Priority = ticket.Priority
                };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public Priority Priority { get; set; }
    }
}