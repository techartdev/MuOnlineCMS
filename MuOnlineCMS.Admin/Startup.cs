using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MuOnlineCMS.Admin.Startup))]
namespace MuOnlineCMS.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
