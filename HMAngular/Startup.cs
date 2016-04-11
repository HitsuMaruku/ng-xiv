using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HMAngular.Startup))]
namespace HMAngular
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
