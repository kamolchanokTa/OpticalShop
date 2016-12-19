using OpticalShop.Models.Bill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpticalShop.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        public ActionResult BillOverView()
        {
            BillViewModel model = new BillViewModel();
            model.BillModels = new List<BillModel>();
            return View(model);
        }
    }
}