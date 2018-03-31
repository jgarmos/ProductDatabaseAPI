using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductsWeb.Startup))]
namespace ProductsWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
