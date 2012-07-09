using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

using TaoMeetting.Domain;
using TaoMeetting.Business;
using TaoMeetting.Utility;
namespace TaoMeetting.Controllers
{
    public class PostController : Controller
    {
        //
        // GET: /Post/
        public static readonly IBrandInfoManager brandinfoComponent = (IBrandInfoManager)SpringHelper.ApplicationContext.GetObject("brandInfoManager");

        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult GetSearchData()
        //{

        //    return View();
        //}
      
    }
}
