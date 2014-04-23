using System;
using System.Runtime.Serialization;
namespace BloggingSystem.Service.Models
{
    [DataContract]
    public class CommentModel
    {
        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "postedBy")]
        public string PostedBy { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime PostDate { get; set; }
    }
}
