using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MonashApp.Startup))]
namespace MonashApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
