namespace TicketSystem.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class PostCommentViewModel
    {
        [Required]
        public int TicketId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}