using OpticalShop.App_Start;
using OpticalShop.Controllers;
using OpticalShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace OpticalShop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public MvcApplication()
        {
            this.PostAuthenticateRequest += new EventHandler(MvcApplication_PostAuthenticateRequest);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            DependencyConfigure.Initialize();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            HomeController.ValidateAuthenticatedUser();
        }
    }
}
