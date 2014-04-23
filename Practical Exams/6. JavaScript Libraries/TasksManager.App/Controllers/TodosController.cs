using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using TasksManager.App.AuthenticationHeaders;
using TasksManager.App.Models;
using TasksManager.Data;

namespace TasksManager.App.Controllers
{
    public class TodosController : BaseApiController
    {
        [HttpPut]
        [ActionName("change-status")]
        public HttpResponseMessage ChangeTodoStatus(int todoId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            return this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new TasksManagerDbContext();

                var meUser = this.GetUserByAccessToken(accessToken, context);

                var todo = context.Todos.Find(todoId);
                if (todo == null)
                {
                    throw new ArgumentNullException("Wrong Todo");
                }

                if (todo.List.Owner != meUser)
                {
                    throw new InvalidOperationException("This is no your todo to check");
                }

                todo.IsDone = (todo.IsDone) ? false : true;
                context.SaveChanges();


                var responseModel = new ListCreatedModel()
                {
                    Id = todo.List.Id,
                    Owner = meUser.Username
                };
                var response = this.Request.CreateResponse(HttpStatusCode.Created, responseModel);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { listId = responseModel.Id }));
                return response;
            });
        }
    }
}