namespace BloggingSystem.Service.Controllers
{
    using BloggingSystem.Data;
    using BloggingSystem.Model;
    using BloggingSystem.Repository;
    using BloggingSystem.Service.Attributes;
    using BloggingSystem.Service.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http.ValueProviders;
    using System.Web.Mvc;

    public class PostsController : BaseApiController
    {
        private IRepository<Post> PostsData;
        private IRepository<Tag> TagsData;

        public PostsController()
        {
            this.PostsData = new Repository<Post>();
            this.TagsData = new Repository<Tag>();
        }

        [HttpGet]
        [ActionName("Index")]
        public IQueryable<PostModel> GetAll([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var user = this.UserData.All().FirstOrDefault(x => x.SessionKey == sessionKey);

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid username");
                    }

                    var posts = this.PostsData.All()
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

                    return posts;
                });

            return responseMessage;
        }

        [HttpGet]
        [ActionName("Index")]
        public IQueryable<PostModel> GetByPage(int page, int count,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var posts = this.GetAll(sessionKey)
                        .Skip(page * count)
                        .Take(count);

                    return posts;
                });

            return responseMessage;
        }

        [HttpGet]
        [ActionName("Index")]
        public IQueryable<PostModel> GetByKeyword(string keyword,
             [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var posts = this.GetAll(sessionKey)
                        .Where(x => x.Title.Contains(keyword));

                    return posts;
                });

            return responseMessage;
        }

        [HttpGet]
        [ActionName("Index")]
        public IQueryable<PostModel> GetByTags(string tags,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var allTags = tags.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    var posts = this.GetAll(sessionKey);

                    for (int i = 0; i < allTags.Length; i++)
                    {
                        var currentTag = allTags[i];
                        posts = posts.Where(x => x.Tags.Any(t => t == currentTag));
                    }

                    return posts;
                });

            return responseMessage;
        }

        [HttpPost]
        [ActionName("Index")]
        public HttpResponseMessage PostCreate(PostModel postModel,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMessage = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    //Fuck repository pattern -> it's buggy! I'ma use context here...

                    var context = new BlogEntities();

                    using (context)
                    {
                        var user = context.Users.FirstOrDefault(x => x.SessionKey == sessionKey);

                        if (user == null)
                        {
                            throw new InvalidOperationException("Invalid username");
                        }

                        var post = new Post
                        {
                            Title = postModel.Title,
                            Text = postModel.Text,
                            User = user,
                            PostedOn = DateTime.Now,
                        };

                        context.Posts.Add(post);
                        context.SaveChanges();

                        foreach (var tag in postModel.Tags)
                        {
                            var existingTag = context.Tags.Where(x => x.Name == tag).FirstOrDefault();

                            if (existingTag == null)
                            {
                                existingTag = new Tag
                                {
                                    Name = tag
                                };
                            }

                            post.Tags.Add(existingTag);
                        }

                        context.SaveChanges();

                        var createdPost = new CreatedPostModel
                        {
                            Title = post.Title,
                            Id = post.Id
                        };

                        var response = this.Request.CreateResponse(HttpStatusCode.Created, createdPost);

                        return response;
                    }
                });

            return responseMessage;
        }

        // TODO: PUT is not working here again, but POST is working o.O
        [HttpPut]
        [ActionName("comment")]
        public HttpResponseMessage Comment(int postId, CommentModel commentModel,
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

                    var post = this.PostsData.All().FirstOrDefault(x => x.Id == postId);

                    if (post == null)
                    {
                        throw new InvalidOperationException("Invalid post");
                    }

                    post.Comments.Add(new Comment
                    {
                        Text = commentModel.Text,
                        CommentedOn = DateTime.Now,
                        User = user
                    });

                    this.PostsData.SaveChanges();

                    var response = this.Request.CreateResponse(HttpStatusCode.OK);

                    return response;
                });

            return responseMessage;
        }

    }
}
