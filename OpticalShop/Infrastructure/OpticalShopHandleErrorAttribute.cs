using OpticalShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using OpticalShop.Controllers;

namespace OpticalShop.Infrastructure
{
    public class OpticalShopHandleErrorAttribute : HandleErrorAttribute
    {
        private ILoggingService _loggingService;

        public OpticalShopHandleErrorAttribute(ILoggingService loggingService)
        {
            this._loggingService = loggingService;
        }

        public override void OnException(ExceptionContext filterContext)
        {
            OpticalShopException exception = new OpticalShopException(filterContext.Exception);
            this._loggingService.Error(exception);

            HttpContext.Current.ClearError();

            RouteData routeData = new RouteData();
            routeData.Values.Add("controller", "Error");
            routeData.Values.Add("action", "Index");
            routeData.Values.Add("exception", exception);

            if (exception.GetType() == typeof(HttpException))
            {
                routeData.Values.Add("statusCode", ((HttpException)filterContext.Exception).GetHttpCode());
            }
            else
            {
                routeData.Values.Add("statusCode", 500);
            }

            IController controller = new ErrorController();
            controller.Execute(new RequestContext(new HttpContextWrapper(HttpContext.Current), routeData));

            HttpContext.Current.Response.End();
        }
    }
}