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
    public class BuyTypeController : Controller
    {
        //
        // GET: /Admin/BuyType/
        public static readonly IBuyTypeManager buytypeComponent = (IBuyTypeManager)SpringHelper.ApplicationContext.GetObject("buyTypeManager");
        public static readonly IBrandBuyManager brandbuyComponent = (IBrandBuyManager)SpringHelper.ApplicationContext.GetObject("brandBuyManager");

        public ActionResult Index(int? page)
        {
            var buytypes = buytypeComponent.GetBuyTypeList();
            string str = Request["alert"];
            if (!string.IsNullOrEmpty(str))
            {
                ViewBag.alertstr = "<script type='text/javascript'>alert('" + str + "')</script>";
            }
            return View(buytypes.AsPagination(page??1,20));
        }
        public ActionResult EditBuytype(int id)
        {
            return View(buytypeComponent.Load(id));
        }
        [HttpPost]
        public ActionResult EditBuytype(BuyType bt)
        {
            buytypeComponent.Update(bt);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBuytype(int id)
        {
            string alertstr = string.Empty;
            try
            {
                buytypeComponent.Delete(id);
            }
            catch (Exception ex)
            {
                alertstr = "请先删除引用此购买方式的品牌!";
                // throw;
            }
            return RedirectToAction("Index", new { alert = alertstr });
        }
        public ActionResult CreateBuytype()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBuytype(BuyType bt)
        {
            buytypeComponent.Save(bt);
            return RedirectToAction("Index");
        }
    }
}
