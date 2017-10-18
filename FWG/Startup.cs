using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FWG.Startup))]
namespace FWG
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
