using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FL.Startup))]
namespace FL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
