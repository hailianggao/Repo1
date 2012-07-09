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
    public class FunctionTypeController : Controller
    {
        //
        // GET: /Admin/FunctionType/
        public static readonly IFunctionTypeManager functiointypeComponent = (IFunctionTypeManager)SpringHelper.ApplicationContext.GetObject("functionTypeManager");
        public ActionResult Index(int? page)
        {
            var functionType = functiointypeComponent.GetFuncType();
            string str = Request["alert"];
            if (!string.IsNullOrEmpty(str))
            {
                ViewBag.alertstr = "<script type='text/javascript'>alert('" + str + "')</script>";
            }
            return View(functionType.AsPagination(page ?? 1, 20));
        }
        
        public ActionResult CreateFun()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateFun(FunctionType ft)
        {
            functiointypeComponent.Save(ft);
            return RedirectToAction("Index");
        }
        public ActionResult EditFun(int id)
        {

            return View(functiointypeComponent.Load(id));
        }
        [HttpPost]
        public ActionResult EditFun(FunctionType ft)
        {
            functiointypeComponent.Update(ft);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteFun(int id)
        {
            string alertstr = string.Empty;
            try
            {
                functiointypeComponent.Delete(id);
            }
            catch (Exception ex)
            {
                alertstr = "请先删除引用此功能的品牌!";
                // throw;
            }
            return RedirectToAction("Index", new { alert = alertstr });
        }
    }
}
