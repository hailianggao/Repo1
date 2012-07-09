using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace TaoMeetting.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Admin/Account/

        public ActionResult LogOn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogOn(string username,string pwd)
        {
            //if (Request.Form["username"].Trim().ToLower() == "tmadmin" && Request.Form["pwd"].Trim().ToLower() == "tmadmin")
            //{
            //    return RedirectToAction("Index", "BrandInfo");
            //}
            //else
            //{
                
            //   // Response.Write("<script type='text/javascript'>alert('用户名或密码错误');</script>");
            //    ViewBag.loginScript = "<script type='text/javascript'>alert('此用户不具备管理员权限 ！');</script>";

            //    return RedirectToAction("LogOn");
           // }
            FormsAuthentication.SetAuthCookie(username, false);
            return RedirectToAction("Index", "BrandInfo");
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogOn");
        }
    }
}
