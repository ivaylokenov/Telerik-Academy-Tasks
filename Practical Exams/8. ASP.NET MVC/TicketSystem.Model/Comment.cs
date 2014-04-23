using System.ComponentModel.DataAnnotations;
namespace TicketSystem.Model
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public Author Author { get; set; }

        public int TicketId { get; set; }

        public Ticket Ticket { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
