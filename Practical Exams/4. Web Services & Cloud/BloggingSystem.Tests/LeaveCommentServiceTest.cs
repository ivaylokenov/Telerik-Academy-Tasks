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
    public class LeaveCommentServiceTest
    {
        static TransactionScope tran;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInit()
        {
            var type = typeof(UsersController);
            tran = new TransactionScope();

            var routes = new List<Route>
            {
                new Route(
                    "CommentApi",
                    "api/posts/{postId}/comment",
                    new
                    {
                        controller = "posts",
                        action = "comment"
                    }
                    ),
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
        public void LeaveCommentServiceShouldReturnOKStatusWhenDataIsValid()
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

            content = response.Content.ReadAsStringAsync().Result;
            var responseObjectCreatedPost = JsonConvert.DeserializeObject<CreatedPostModel>(content);

            var commentModel = new CommentModel
            {
                Text = "Komentiram!",
            };

            var uri = string.Format("api/posts/{0}/comment", responseObjectCreatedPost.Id);

            response = httpServer.Post(uri, commentModel, headers);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void LeaveCommentServiceShouldReturnBadRequestStatusWhenSessionKeyIsNotValid()
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
            headers.Add("X-sessionKey", "0234567890123456789012345678901234567890");

            var postModel = new PostModel
            {
                Title = "SomePost",
                Text = "SomeText",
                Tags = new List<string>() { "kef", "dva kefa", "tri kefa" }
            };

            response = httpServer.Post("api/posts", postModel, headers);

            content = response.Content.ReadAsStringAsync().Result;
            var responseObjectCreatedPost = JsonConvert.DeserializeObject<CreatedPostModel>(content);

            var commentModel = new CommentModel
            {
                Text = "Komentiram!",
            };

            var uri = string.Format("api/posts/{0}/comment", responseObjectCreatedPost.Id);

            response = httpServer.Post(uri, commentModel, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void LeaveCommentServiceShouldReturnBadRequestStatusWhenPostIdIsNotValid()
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

            content = response.Content.ReadAsStringAsync().Result;
            var responseObjectCreatedPost = JsonConvert.DeserializeObject<CreatedPostModel>(content);

            var commentModel = new CommentModel
            {
                Text = "Komentiram!",
            };

            var uri = string.Format("api/posts/{0}/comment", 99999999);

            response = httpServer.Post(uri, commentModel, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void LeaveCommentServiceShouldReturnBadRequestStatucIfTextIsNull()
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

            content = response.Content.ReadAsStringAsync().Result;
            var responseObjectCreatedPost = JsonConvert.DeserializeObject<CreatedPostModel>(content);

            var commentModel = new CommentModel
            {
                Text = null,
            };

            var uri = string.Format("api/posts/{0}/comment", 99999999);

            response = httpServer.Post(uri, commentModel, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
