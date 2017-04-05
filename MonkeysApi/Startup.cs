using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MonkeysApi.Startup))]

namespace MonkeysApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}