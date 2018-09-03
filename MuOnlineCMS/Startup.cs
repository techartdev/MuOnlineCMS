using Microsoft.Owin;
using MuOnlineCMS.Web;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace MuOnlineCMS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
