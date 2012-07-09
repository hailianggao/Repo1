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
    public class ProductTypeController : Controller
    {
        //
        // GET: /Admin/ProductType/
        public static readonly IProductTypeManager producttypeComponent = (IProductTypeManager)SpringHelper.ApplicationContext.GetObject("productTypeManager");

        public ActionResult Index(int? page)
        {
            var productType = producttypeComponent.GetProdType();
            string str = Request["alert"];
            if (!string.IsNullOrEmpty(str))
            {
                ViewBag.alertstr = "<script type='text/javascript'>alert('" + str + "')</script>";
            }
            return View(productType.AsPagination(page??1,20));
        }
        public ActionResult EditPro(int id)
        {
            return View(producttypeComponent.Load(id));
        }
        [HttpPost]
        public ActionResult EditPro(ProductType pt)
        {
            producttypeComponent.Update(pt);
            return RedirectToAction("Index");
        }
        public ActionResult CreatePro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePro(ProductType pt)
        {
            producttypeComponent.Save(pt);
            return RedirectToAction("Index");
        }
        public ActionResult DeletePro(int id)
        {
           string alertstr=string.Empty;
            try
            {
                producttypeComponent.Delete(id);
            }
            catch (Exception ex)
            {
               alertstr= "请先删除引用此用途的品牌!";
               // throw;
            }
            return RedirectToAction("Index", new { alert =alertstr });
        }
    }
}
