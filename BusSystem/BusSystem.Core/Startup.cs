using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusSystem.Core.Startup))]
namespace BusSystem.Core
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
