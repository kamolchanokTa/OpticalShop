using OpticalShop.Infrastructure;
using OpticalShop.Service;
using System.Web;
using System.Web.Mvc;

namespace OpticalShop
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            var logger = Singleton<DependencyConfigure>.Instance.ContainerManager.Resolve<ILoggingService>();
            filters.Add(new OpticalShopHandleErrorAttribute(logger));
        }
    }
}
    