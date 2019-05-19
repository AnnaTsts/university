using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Util;
using Util.Ninject;


namespace Textagram
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<ApplicationProfile>());

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);

            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
        }
    }
}
