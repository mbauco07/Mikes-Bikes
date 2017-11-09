using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mikes_Bikes.Startup))]
namespace Mikes_Bikes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
