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
using TasksManager.Models;

namespace TasksManager.App.Controllers
{
    public class ListsController : BaseApiController
    {
        [HttpPost]
        [ActionName("new")]
        public HttpResponseMessage CreateList(TodolistModel model,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            return this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new TasksManagerDbContext();
                var meUser = this.GetUserByAccessToken(accessToken, context);
                this.ValidateList(model);

                var listEntity = model.ToEntity();
                listEntity.Owner = meUser;
                meUser.TodoLists.Add(listEntity);
                context.SaveChanges();

                var responseModel = new ListCreatedModel()
                {
                    Id = listEntity.Id,
                    Owner = meUser.Username
                };
                var response = this.Request.CreateResponse(HttpStatusCode.Created, responseModel);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { listId = listEntity.Id }));
                return response;
            });
        }

        [HttpGet]
        [ActionName("all")]
        public IQueryable<TodolistModel> GetAll(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            return this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new TasksManagerDbContext();
                var user = this.GetUserByAccessToken(accessToken, context);
                var lists = user.TodoLists.AsQueryable().OrderBy(tl => tl.Title)
                        .Select(TodolistModel.FromTodoList);
                return lists;
            });
        }

        [HttpGet]
        [ActionName("single")]
        public TodolistModel GetSingleList(int id,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            return this.GetAll(accessToken)
                    .FirstOrDefault(tl => tl.Id == id);
        }

        [HttpPost]
        [ActionName("todos")]
        public HttpResponseMessage CreateTodoForList(int listId, TodoModel model,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            return this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new TasksManagerDbContext();
                var meUser = this.GetUserByAccessToken(accessToken, context);
                var list = context.TodoLists.Find(listId);
                if (list == null)
                {
                    throw new ArgumentNullException("Wrong TODO list");
                }

                if (string.IsNullOrEmpty(model.Text))
                {
                    throw new ArgumentNullException("Invalid TODO properties");
                }
                
                var todoEntity = new Todo()
                {
                    Text = model.Text,
                    IsDone = false
                };

                list.Todos.Add(todoEntity);
                context.SaveChanges();

                var responseModel = new ListCreatedModel()
                {
                    Id = listId,
                    Owner = meUser.Username
                };
                var response = this.Request.CreateResponse(HttpStatusCode.Created, responseModel);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { listId = responseModel.Id }));
                return response;
            });
        }

        private void ValidateList(TodolistModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Title))
            {
                throw new ArgumentNullException("Invalid TODO list title");
            }
        }
    }
}