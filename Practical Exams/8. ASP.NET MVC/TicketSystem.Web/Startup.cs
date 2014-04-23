using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TicketSystem.Web.Startup))]
namespace TicketSystem.Web
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
