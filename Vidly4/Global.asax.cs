using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Vidly4.App_Start;

namespace Vidly4
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //180817_4_20:35 dodajemy lambda z parametrem do addprofile
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
            //180817_0_14:35 dodanie metody potrzebnej do API
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
