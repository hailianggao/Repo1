using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaoMeetting.Domain;
using TaoMeetting.Business;
using TaoMeetting.Utility;

using MvcContrib.Pagination;
using MvcContrib.UI.Pager;

namespace TaoMeetting.Areas.Admin.Controllers
{
    public class PriceRangeController : Controller
    {
        //
        // GET: /Admin/PriceRange/
        public static readonly IPriceRangeManager pricerangeComponent = (IPriceRangeManager)SpringHelper.ApplicationContext.GetObject("pricerangeManager");

        public ActionResult Index(int? page)
        {
            var pricerangelist = pricerangeComponent.GetPriceRange();
            return View(pricerangelist.AsPagination(page??1,20));
        }
        public ActionResult CreatePriceRange()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePriceRange(PriceRange pr)
        {
            pricerangeComponent.Save(pr);
            return RedirectToAction("Index");
        }
        public ActionResult EditPriceRange(int id)
        {
            return View(pricerangeComponent.Load(id));
        }
        [HttpPost]
        public ActionResult EditPriceRange(PriceRange pr)
        {
            pricerangeComponent.Update(pr);
            return RedirectToAction("Index");
        }
        public ActionResult DeletePriceRange(int id)
        {
            pricerangeComponent.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
