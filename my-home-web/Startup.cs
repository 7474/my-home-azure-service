using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(my_home_web.Startup))]
namespace my_home_web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
