using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Strado.InVento.Startup))]
namespace Strado.InVento
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
