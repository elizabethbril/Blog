using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;


[assembly: OwinStartup(typeof(Blog.Startup))]

namespace Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}