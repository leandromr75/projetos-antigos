using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(siteUpload.Startup))]
namespace siteUpload
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
