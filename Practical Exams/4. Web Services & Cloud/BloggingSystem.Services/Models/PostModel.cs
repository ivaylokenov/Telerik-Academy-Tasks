namespace BloggingSystem.Service.Controllers
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using BloggingSystem.Service.Models;
    using System;

    [DataContract]
    public class PostModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "postedBy")]
        public string PostedBy { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "postDate")]
        public DateTime PostDate { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "tags")]
        public IEnumerable<string> Tags { get; set; }

        [DataMember(Name = "comments")]
        public IEnumerable<CommentModel> Comments { get; set; }

        public PostModel()
        {
            this.Tags = new HashSet<string>();
            this.Comments = new HashSet<CommentModel>();
        }
    }
}
