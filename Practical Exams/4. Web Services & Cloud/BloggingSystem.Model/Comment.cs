namespace BloggingSystem.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime CommentedOn {get;set;}

        [Required]
        public virtual User User { get; set; }
    }
}
