using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Atenda.Startup))]
namespace Atenda
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
