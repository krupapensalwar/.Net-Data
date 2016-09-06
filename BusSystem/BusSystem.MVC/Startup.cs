using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusSystem.MVC.Startup))]
namespace BusSystem.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
