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
    public class CreatePostServiceTest
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
        public void CreatePostServiceShouldReturnCreatedStatusWhenDataIsValid()
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

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public void CreatePostServiceShouldReturnBadRequestStatusWhenSessionKeyIsNotFound()
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
                Tags = new List<string>()
            };

            response = httpServer.Post("api/posts", postModel, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void CreatePostServiceShouldReturnBadRequestStatusWhenTitleIsNull()
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
            headers.Add("X-sessionKey", "1234567890123456789012345678901234567890");

            var postModel = new PostModel
            {
                Title = null,
                Text = "SomeText",
                Tags = new List<string>()
            };

            response = httpServer.Post("api/posts", postModel, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void CreatePostServiceShouldReturnBadRequestStatusWhenTextIsNull()
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
            headers.Add("X-sessionKey", "1234567890123456789012345678901234567890");

            var postModel = new PostModel
            {
                Title = "Humpty dumpty",
                Text = null,
                Tags = new List<string>()
            };

            response = httpServer.Post("api/posts", postModel, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void CreatePostServiceShouldReturnBadRequestStatusWhenTagsAreNull()
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
            headers.Add("X-sessionKey", "1234567890123456789012345678901234567890");

            var postModel = new PostModel
            {
                Title = "Humpty dumpty",
                Text = "Humpty dumpty",
                Tags = null
            };

            response = httpServer.Post("api/posts", postModel, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
