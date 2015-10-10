using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Persona.Startup))]
namespace Persona
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
