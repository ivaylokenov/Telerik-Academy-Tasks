using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormsTemplate.Startup))]
namespace WebFormsTemplate
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
