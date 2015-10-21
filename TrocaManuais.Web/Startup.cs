using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrocaManuais.Web.Startup))]
namespace TrocaManuais.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
