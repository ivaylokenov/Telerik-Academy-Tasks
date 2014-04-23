namespace BloggingSystem.Service.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class CreatedPostModel
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }
    }
}