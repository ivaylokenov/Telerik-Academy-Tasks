namespace WebFormsTemplate.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Authors { get; set; }

        public string ISBN { get; set; }

        public string WebSite { get; set; }

        public string Description { get; set; }

        public int CategoryId {get;set;}

        public virtual Category Category { get; set; }
    }
}