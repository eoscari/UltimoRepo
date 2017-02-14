using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Trabajo_final.Startup))]
namespace Trabajo_final
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
