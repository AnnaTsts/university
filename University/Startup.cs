using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http.Cors;
using System.Threading.Tasks;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(University.Startup))]

namespace University
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            app.UseCors(CorsOptions.AllowAll);
            ConfigureAuth(app);
            
        }
    }
}
