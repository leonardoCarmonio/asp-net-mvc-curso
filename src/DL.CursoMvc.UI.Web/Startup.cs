using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DL.CursoMvc.UI.Web.Startup))]
namespace DL.CursoMvc.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
