using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StaffWokrloadSystem.Startup))]
namespace StaffWokrloadSystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
