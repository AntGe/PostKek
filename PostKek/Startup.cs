using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PostKek.Startup))]
namespace PostKek
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
