using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TasksManager.App
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "AppointmentsApiWithActions",
                routeTemplate: "api/appointments/{action}",
                defaults: new { controller = "appointments" });

            config.Routes.MapHttpRoute(
                name: "TodosApi",
                routeTemplate: "api/todos/{todoId}",
                defaults: new { controller = "todos" });

            config.Routes.MapHttpRoute(
                name: "ListsApi",
                routeTemplate: "api/lists/{listId}/todos",
                defaults: new { controller = "lists", action = "todos" });

            config.Routes.MapHttpRoute(
                name: "UserLoginApi",
                routeTemplate: "api/auth/token",
                defaults: new { controller = "users", action = "token" });
            
            config.Routes.MapHttpRoute(
                name: "UserApi",
                routeTemplate: "api/users/{action}",
                defaults: new { controller = "users" });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}