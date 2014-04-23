using System.Web.Http.Controllers;
using System.Web.Http.ValueProviders;
using TasksManager.App.AuthenticationHeaders;

namespace TasksManager.App.AuthenticationHeaders
{
    public class HeaderValueProviderFactory<T> : ValueProviderFactory where T : class
    {
        public override IValueProvider GetValueProvider(HttpActionContext actionContext)
        {
            var headers = actionContext.ControllerContext.Request.Headers;
            return new HeaderValueProvider<T>(headers);
        }
    }
}