using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OdevD1.Startup))]
namespace OdevD1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
