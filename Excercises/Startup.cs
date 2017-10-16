using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Excercises.Startup))]
namespace Excercises
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
