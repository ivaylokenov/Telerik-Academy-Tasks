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
    public class LogoutServicesTest
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
        public void LogoutServiceShouldReturnOkStatusCode()
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

            //using post because PUT does not work for unknown to mankind reasons
            response = httpServer.Post("api/users/logout", null, headers);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void LogoutServiceShouldReturnErrorIfSessionKeyIsNotValid()
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

            var sessionKey = responseObject.SessionKey + "1";

            var headers = new Dictionary<string, string>();
            headers.Add("X-sessionKey", sessionKey);

            //using post because PUT does not work for unknown to mankind reasons
            response = httpServer.Post("api/users/logout", null, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void LogoutServiceShouldReturnErrorIfLogoutIsDoneTwice()
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

            //using post because PUT does not work for unknown to mankind reasons
            response = httpServer.Post("api/users/logout", null, headers);
            response = httpServer.Post("api/users/logout", null, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
