using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(sa47.team8ad.SSIS.Startup))]
namespace sa47.team8ad.SSIS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // ConfigureAuth(app);
        }
    }
}
