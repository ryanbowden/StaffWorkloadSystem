using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StaffWorkloadSystem.Startup))]
namespace StaffWorkloadSystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
