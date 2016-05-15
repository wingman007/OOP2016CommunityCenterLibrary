using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CommunityCenterLibrary.Startup))]
namespace CommunityCenterLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
