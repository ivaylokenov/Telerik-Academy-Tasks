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
    public class RegisterServiceTest
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
        public void RegisterServiceShouldReturnOkStatusWhenDataIsValid()
        {
            var userModel = new UserModel
            {
                Username = "GeorgiDonchov",
                DisplayName = "GeorgiIvaylov",
                AuthCode = "1234567890123456789012345678901234567890"
            };

            var response = httpServer.Post("api/users/register", userModel);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public void RegisterServiceShouldReturnDisplayNameAndSessionKey()
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

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.AreEqual(userModel.DisplayName, responseObject.DisplayName);
            Assert.IsNotNull(responseObject.SessionKey);
        }

        [TestMethod]
        public void RegisterServiceShouldReturnErrorResponseIfuserAlreadyExists()
        {
            var userModel = new UserModel
            {
                Username = "GeorgiDonchov",
                DisplayName = "GeorgiIvaylov",
                AuthCode = "1234567890123456789012345678901234567890"
            };

            var response = httpServer.Post("api/users/register", userModel);
            response = httpServer.Post("api/users/register", userModel);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void RegisterServiceShouldReturnErrorResponseIfUsernameIsLessThanNeededSymbols()
        {
            var userModel = new UserModel
            {
                Username = "Geo",
                DisplayName = "GeorgiIvaylov",
                AuthCode = "1234567890123456789012345678901234567890"
            };

            var response = httpServer.Post("api/users/register", userModel);
            response = httpServer.Post("api/users/register", userModel);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void RegisterServiceShouldReturnErrorResponseIfUsernameIsMoreThanNeededSymbols()
        {
            var userModel = new UserModel
            {
                Username = "Geogafdfdssfdsfdsfdfdsfdsffgfdgdhghgfhgfhgfhgfhgfhgfhgfhgf",
                DisplayName = "GeorgiIvaylov",
                AuthCode = "1234567890123456789012345678901234567890"
            };

            var response = httpServer.Post("api/users/register", userModel);
            response = httpServer.Post("api/users/register", userModel);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void RegisterServiceShouldReturnErrorResponseIfUsernameHasInvalidSymbols()
        {
            var userModel = new UserModel
            {
                Username = "Geoga%^&",
                DisplayName = "GeorgiIvaylov",
                AuthCode = "1234567890123456789012345678901234567890"
            };

            var response = httpServer.Post("api/users/register", userModel);
            response = httpServer.Post("api/users/register", userModel);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }


        [TestMethod]
        public void RegisterServiceShouldReturnErrorResponseIfDisplayNameIsLessThanNeededSymbols()
        {
            var userModel = new UserModel
            {
                Username = "GeorgiIvaylov",
                DisplayName = "Ge",
                AuthCode = "1234567890123456789012345678901234567890"
            };

            var response = httpServer.Post("api/users/register", userModel);
            response = httpServer.Post("api/users/register", userModel);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void RegisterServiceShouldReturnErrorResponseIfDisplayNameIsMoreThanNeededSymbols()
        {
            var userModel = new UserModel
            {
                Username = "Geogafdfgdsf",
                DisplayName = "GeorgiIvaylovhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh",
                AuthCode = "1234567890123456789012345678901234567890"
            };

            var response = httpServer.Post("api/users/register", userModel);
            response = httpServer.Post("api/users/register", userModel);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void RegisterServiceShouldReturnErrorResponseIfDisplayNameHasInvalidSymbols()
        {
            var userModel = new UserModel
            {
                Username = "Geogahghgf",
                DisplayName = "GeorgiIv%^&aylov",
                AuthCode = "1234567890123456789012345678901234567890"
            };

            var response = httpServer.Post("api/users/register", userModel);
            response = httpServer.Post("api/users/register", userModel);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void RegisterServiceShouldReturnErrorResponseIfAuthCodeHasInvalidSymbols()
        {
            var userModel = new UserModel
            {
                Username = "Geogahghgf",
                DisplayName = "Georgaylov",
                AuthCode = "12345678901234%^56789012345678901234567890"
            };

            var response = httpServer.Post("api/users/register", userModel);
            response = httpServer.Post("api/users/register", userModel);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void RegisterServiceShouldReturnErrorResponseIfAuthCodeHasLessSymbols()
        {
            var userModel = new UserModel
            {
                Username = "Geogahghgf",
                DisplayName = "Georgaylov",
                AuthCode = "1234567890123456789012345678901234567"
            };

            var response = httpServer.Post("api/users/register", userModel);
            response = httpServer.Post("api/users/register", userModel);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void RegisterServiceShouldReturnErrorResponseIfAuthCodeHasMoreSymbols()
        {
            var userModel = new UserModel
            {
                Username = "Geogahghgf",
                DisplayName = "Georgaylov",
                AuthCode = "12345678901234567890123456789012345671212132431123121"
            };

            var response = httpServer.Post("api/users/register", userModel);
            response = httpServer.Post("api/users/register", userModel);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void RegisterServiceShouldReturnErrorResponseIfUsernameIsNull()
        {
            var userModel = new UserModel
            {
                Username = null,
                DisplayName = "Georgaylov",
                AuthCode = "1234567890123456789012345678901234567890"
            };

            var response = httpServer.Post("api/users/register", userModel);
            response = httpServer.Post("api/users/register", userModel);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void RegisterServiceShouldReturnErrorResponseIfDisplayNameIsNull()
        {
            var userModel = new UserModel
            {
                Username = "Georgaylov",
                DisplayName = null,
                AuthCode = "1234567890123456789012345678901234567890"
            };

            var response = httpServer.Post("api/users/register", userModel);
            response = httpServer.Post("api/users/register", userModel);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void RegisterServiceShouldReturnErrorResponseIfAuthCodeIsNull()
        {
            var userModel = new UserModel
            {
                Username = "Georgaylov",
                DisplayName = "Georgaylov",
                AuthCode = null
            };

            var response = httpServer.Post("api/users/register", userModel);
            response = httpServer.Post("api/users/register", userModel);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void RegisterServiceShouldNotAllowLoginIfRegisterFails()
        {
            var userModel = new UserModel
            {
                Username = "Georgaylov",
                DisplayName = "Geo",
                AuthCode = "1234567890123456789012345678901234567890"
            };

            var response = httpServer.Post("api/users/register", userModel);
            response = httpServer.Post("api/users/register", userModel);

            response = httpServer.Post("api/users/login", userModel);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
