using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuanLiSach.Startup))]
namespace QuanLiSach
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
