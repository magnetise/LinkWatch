using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LinkWatch.Startup))]
namespace LinkWatch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
