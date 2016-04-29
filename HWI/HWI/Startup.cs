using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HWI.Startup))]
namespace HWI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
