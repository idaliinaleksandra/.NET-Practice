using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(pelimaailma.Startup))]
namespace pelimaailma
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
