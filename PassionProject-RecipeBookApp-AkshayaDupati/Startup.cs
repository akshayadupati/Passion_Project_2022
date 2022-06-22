using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PassionProject_RecipeBookApp_AkshayaDupati.Startup))]
namespace PassionProject_RecipeBookApp_AkshayaDupati
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
