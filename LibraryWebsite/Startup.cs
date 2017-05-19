using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibraryWebsite.Startup))]
namespace LibraryWebsite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
