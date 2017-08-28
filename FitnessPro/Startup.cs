using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FitnessPro.Startup))]
namespace FitnessPro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
