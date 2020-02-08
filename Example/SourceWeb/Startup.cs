using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SourceWeb.Startup))]
namespace SourceWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
