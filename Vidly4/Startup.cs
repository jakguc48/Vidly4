using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly4.Startup))]
namespace Vidly4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
