namespace BloggingSystem.Service.Controllers
{
    using BloggingSystem.Model;
    using BloggingSystem.Repository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class BaseApiController : ApiController
    {
        protected IRepository<User> UserData;

        public BaseApiController()
        {
            this.UserData = new Repository<User>();
        }

        protected T PerformOperationAndHandleExceptions<T>(Func<T> operation)
        {
            try
            {
                return operation();
            }
            catch (Exception ex)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errResponse);
            }
        }
    }
}
