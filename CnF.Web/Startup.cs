using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CnF.Web.Startup))]
namespace CnF.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
