using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusSystem.WebAPI.Startup))]
namespace BusSystem.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
