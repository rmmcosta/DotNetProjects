using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyMvcMusicStore2017.Startup))]
namespace MyMvcMusicStore2017
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
        }
    }
}
