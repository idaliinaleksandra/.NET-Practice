using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PelimaailmaAdmin.Startup))]
namespace PelimaailmaAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
