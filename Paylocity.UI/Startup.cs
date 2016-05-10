using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Paylocity.UI.Startup))]
namespace Paylocity.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
