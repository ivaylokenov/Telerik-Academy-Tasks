namespace TicketSystem.Web.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using TicketSystem.Model;

    public class AdminCommentViewModel
    {
        public static Expression<Func<Comment, AdminCommentViewModel>> FromComment
        {
            get
            {
                return comment => new AdminCommentViewModel
                {
                    Id = comment.Id,
                    TicketTitle = comment.Ticket.Title,
                    AuthorUsername = comment.Author.UserName,
                    Content = comment.Content
                };
            }
        }

        public int Id { get; set; }

        [DisplayName("Ticket")]
        public string TicketTitle { get; set; }

        [DisplayName("Author")]
        public string AuthorUsername { get; set; }

        [Required]
        [DisplayName("Content")]
        public string Content { get; set; }
    }
}