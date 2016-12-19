using OpticalShop.Models;
using OpticalShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpticalShop.Controllers
{
    public class CommonController : BaseController
    {
        private ICustomerService _customerService;

        public CommonController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }
        

        [ChildActionOnly]
        public ActionResult Header()
        {
            HeaderModel model = new HeaderModel();
            model.user = "Test";

            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }
    }
}