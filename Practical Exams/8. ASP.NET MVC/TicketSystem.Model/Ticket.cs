namespace TicketSystem.Model
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Ticket
    {
        public Ticket()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DefaultValue(Priority.Medium)]
        public Priority Priority { get; set; }

        public string ScreenshotUrl { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
