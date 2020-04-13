using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeWildLearn.Startup))]
namespace HomeWildLearn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
