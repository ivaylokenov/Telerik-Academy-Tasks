namespace BloggingSystem.Model
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public int Id { get; set; }

        [MinLength(6)]
        [MaxLength(30)]
        [Required]
        public string Username { get; set; }

        [MinLength(6)]
        [MaxLength(30)]
        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string AuthCode { get; set; }

        public string SessionKey { get; set; }
    }
}
