
using Microsoft.Owin;
using Spike.Web;

[assembly: OwinStartup(typeof(Startup))]
namespace Spike.Web
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
