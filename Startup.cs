using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eLearning.Startup))]
namespace eLearning
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
