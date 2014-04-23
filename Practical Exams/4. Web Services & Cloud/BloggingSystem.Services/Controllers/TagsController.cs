namespace BloggingSystem.Service.Controllers
{
    using BloggingSystem.Model;
    using BloggingSystem.Repository;
    using BloggingSystem.Service.Attributes;
    using BloggingSystem.Service.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http.ValueProviders;
    using System.Web.Mvc;

    public class TagsController : BaseApiController
    {
        private IRepository<Tag> Data;

        public TagsController()
        {
            this.Data = new Repository<Tag>();
        }

        [HttpGet]
        [ActionName("Index")]
        public IQueryable<TagModel> GetAll([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var user = this.UserData.All().FirstOrDefault(x => x.SessionKey == sessionKey);

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid username");
                    }

                    var tags = this.Data.All()
                        .OrderBy(x => x.Name)
                        .Select(x => new TagModel
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Posts = x.Posts.Count
                        });

                    return tags;
                });

            return responseMessage;
        }

        // TODO:  Your mother does not support GET method... The attribute below is HttpGet!!!!
        [HttpGet]
        [ActionName("getposts")]
        public IQueryable<PostModel> GetPosts(string tagId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var user = this.UserData.All().FirstOrDefault(x => x.SessionKey == sessionKey);

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid username");
                    }

                    var tag = this.Data.All().Where(x => x.Name == tagId).FirstOrDefault();

                    if (tag == null)
                    {
                        throw new InvalidOperationException("Invalid tag");
                    }

                    var posts = tag.Posts
                        .OrderByDescending(x => x.PostedOn)
                        .Select(x => new PostModel
                        {
                            Id = x.Id,
                            Title = x.Title,
                            Text = x.Text,
                            PostedBy = x.User.DisplayName,
                            PostDate = x.PostedOn,
                            Tags = x.Tags.Select(t => t.Name),
                            Comments = x.Comments.Select(c => new CommentModel
                            {
                                Text = c.Text,
                                PostedBy = c.User.DisplayName,
                                PostDate = c.CommentedOn
                            })
                        });

                    return posts.AsQueryable();
                });

            return responseMessage;
        }
    }
}
