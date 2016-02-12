using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CalculatorMVC.Startup))]
namespace CalculatorMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
