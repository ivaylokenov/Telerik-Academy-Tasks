namespace BloggingSystem.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Transactions;
    using BloggingSystem.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Net;
    using Newtonsoft.Json;
    using BloggingSystem.Service;
    using BloggingSystem.Service.Controllers;
    using System.Web.Http;
    using BloggingSystem.Service.Models;

    [TestClass]
    public class PostsByTagsServiceTest
    {
        static TransactionScope tran;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInit()
        {
            var type = typeof(PostsController);
            tran = new TransactionScope();

            var routes = new List<Route>
            {
                new Route(
                    "UsersApi",
                    "api/users/{action}",
                    new { controller = "users" }),
                new Route(
                    "DefaultApi",
                    "api/{controller}/{id}",
                    new { id = RouteParameter.Optional }),
            };
            this.httpServer = new InMemoryHttpServer("http://localhost/", routes);
        }

        [TestCleanup]
        public void TearDown()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void PostsByTagsServiceShouldReturnTwoPostsWhenDataIsValidWithOneTag()
        {
            var userModel = new UserModel
            {
                Username = "GeorgiDonchov",
                DisplayName = "GeorgiIvaylov",
                AuthCode = "1234567890123456789012345678901234567890"
            };

            var response = httpServer.Post("api/users/register", userModel);

            var content = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<LoggedUserModel>(content);

            var sessionKey = responseObject.SessionKey;

            var headers = new Dictionary<string, string>();
            headers.Add("X-sessionKey", sessionKey);

            var postModel = new PostModel
            {
                Title = "SomePost",
                Text = "SomeText",
                Tags = new List<string>() { "kef", "dva kefa", "tri kefa" }
            };

            response = httpServer.Post("api/posts", postModel, headers);

            postModel = new PostModel
            {
                Title = "SomePost2",
                Text = "SomeText1",
                Tags = new List<string>() { "kef", "tri kefa" }
            };

            response = httpServer.Post("api/posts", postModel, headers);

            postModel = new PostModel
            {
                Title = "SomePost2",
                Text = "SomeText1",
                Tags = new List<string>() { "dva kefa", "tri kefa" }
            };

            response = httpServer.Post("api/posts", postModel, headers);

            response = httpServer.Get("api/posts?tags=dva%20kefa", headers);

            content = response.Content.ReadAsStringAsync().Result;
            var resultPosts = JsonConvert.DeserializeObject<IEnumerable<PostModel>>(content);

            Assert.AreEqual(2, resultPosts.Count());
        }

        [TestMethod]
        public void PostsByTagsServiceShouldReturnOnePostWhenDataIsValidWithMoreTags()
        {
            var userModel = new UserModel
            {
                Username = "GeorgiDonchov",
                DisplayName = "GeorgiIvaylov",
                AuthCode = "1234567890123456789012345678901234567890"
            };

            var response = httpServer.Post("api/users/register", userModel);

            var content = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<LoggedUserModel>(content);

            var sessionKey = responseObject.SessionKey;

            var headers = new Dictionary<string, string>();
            headers.Add("X-sessionKey", sessionKey);

            var postModel = new PostModel
            {
                Title = "SomePost",
                Text = "SomeText",
                Tags = new List<string>() { "kef", "dva kefa", "tri kefa" }
            };

            response = httpServer.Post("api/posts", postModel, headers);

            postModel = new PostModel
            {
                Title = "SomePost2",
                Text = "SomeText1",
                Tags = new List<string>() { "kef", "tri kefa" }
            };

            response = httpServer.Post("api/posts", postModel, headers);

            postModel = new PostModel
            {
                Title = "SomePost2",
                Text = "SomeText1",
                Tags = new List<string>() { "dva kefa", "tri kefa" }
            };

            response = httpServer.Post("api/posts", postModel, headers);

            response = httpServer.Get("api/posts?tags=dva%20kefa,kef,tri%20kefa", headers);

            content = response.Content.ReadAsStringAsync().Result;
            var resultPosts = JsonConvert.DeserializeObject<IEnumerable<PostModel>>(content);

            Assert.AreEqual(1, resultPosts.Count());
        }

        [TestMethod]
        public void PostsByTagsServiceShouldReturnZeroResultsWhenNonCorrectTagsEntered()
        {
            var userModel = new UserModel
            {
                Username = "GeorgiDonchov",
                DisplayName = "GeorgiIvaylov",
                AuthCode = "1234567890123456789012345678901234567890"
            };

            var response = httpServer.Post("api/users/register", userModel);

            var content = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<LoggedUserModel>(content);

            var sessionKey = responseObject.SessionKey;

            var headers = new Dictionary<string, string>();
            headers.Add("X-sessionKey", sessionKey);

            var postModel = new PostModel
            {
                Title = "SomePost",
                Text = "SomeText",
                Tags = new List<string>() { "kef", "dva kefa", "tri kefa" }
            };

            response = httpServer.Post("api/posts", postModel, headers);

            postModel = new PostModel
            {
                Title = "SomePost2",
                Text = "SomeText1",
                Tags = new List<string>() { "kef", "tri kefa" }
            };

            response = httpServer.Post("api/posts", postModel, headers);

            postModel = new PostModel
            {
                Title = "SomePost2",
                Text = "SomeText1",
                Tags = new List<string>() { "dva kefa", "tri kefa" }
            };

            response = httpServer.Post("api/posts", postModel, headers);

            response = httpServer.Get("api/posts?tags=NikavKef", headers);

            content = response.Content.ReadAsStringAsync().Result;
            var resultPosts = JsonConvert.DeserializeObject<IEnumerable<PostModel>>(content);

            Assert.AreEqual(0, resultPosts.Count());
        }
    }
}
