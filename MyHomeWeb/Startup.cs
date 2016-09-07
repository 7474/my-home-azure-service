using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyHomeWeb.Startup))]
namespace MyHomeWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
