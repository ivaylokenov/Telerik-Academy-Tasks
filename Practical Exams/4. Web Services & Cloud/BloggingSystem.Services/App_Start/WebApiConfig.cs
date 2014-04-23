using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BloggingSystem.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "TagsApi",
                routeTemplate: "api/tags/{tagId}/posts",
                defaults: new
                {
                    controller = "tags",
                    action = "getposts"
                }
            );

            config.Routes.MapHttpRoute(
                name: "CommentApi",
                routeTemplate: "api/posts/{postId}/comment",
                defaults: new
                {
                    controller = "posts",
                    action = "comment"
                }
            );

            config.Routes.MapHttpRoute(
                name: "UsersApi",
                routeTemplate: "api/users/{action}",
                defaults: new
                {
                    controller = "users"
                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
