using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CS305_WebApp.Startup))]
namespace CS305_WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
