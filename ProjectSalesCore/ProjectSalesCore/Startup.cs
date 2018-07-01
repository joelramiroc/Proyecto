using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectSalesCore.Startup))]
namespace ProjectSalesCore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
