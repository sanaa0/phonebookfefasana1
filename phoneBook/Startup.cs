using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(phoneBook.Startup))]
namespace phoneBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
