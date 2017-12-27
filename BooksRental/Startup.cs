using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BooksRental.Startup))]
namespace BooksRental
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
