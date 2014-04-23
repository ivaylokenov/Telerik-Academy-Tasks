using System;
using System.Linq.Expressions;
using TicketSystem.Model;
namespace TicketSystem.Web.ViewModels
{
    public class CommentViewModel
    {
        public static Expression<Func<Comment, CommentViewModel>> FromComment
        {
            get
            {
                return comment => new CommentViewModel
                {
                    AuthorUsername = comment.Author.UserName,
                    Content = comment.Content
                };
            }
        }

        public string AuthorUsername { get; set; }

        public string Content { get; set; }
    }
}
