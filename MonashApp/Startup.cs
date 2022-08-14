using Microsoft.Owin;
using MonashApp.Models;
using Owin;
using System.Collections.Generic;

[assembly: OwinStartupAttribute(typeof(MonashApp.Startup))]
namespace MonashApp
{
    public partial class Startup
    {
        //create a global attribute for shopping cart at the beginning.
        public static List<Product> ShoppingCart { get; set; }

        public Startup()
        {
            ShoppingCart = new List<Product>();
        }
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }


    }
}
