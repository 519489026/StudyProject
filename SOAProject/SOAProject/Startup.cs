using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SOAProject.Startup))]
namespace SOAProject
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
