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
    public class BrandInfoController : Controller
    {
        //
        // GET: /Admin/BrandInfo/buyTypeManager
        public static readonly IBrandInfoManager brandinfoComponent = (IBrandInfoManager)SpringHelper.ApplicationContext.GetObject("brandInfoManager");
        public static readonly IAddressManager addressComponent = (IAddressManager)SpringHelper.ApplicationContext.GetObject("addressManager");
        public static readonly IFunctionTypeManager functiointypeComponent = (IFunctionTypeManager)SpringHelper.ApplicationContext.GetObject("functionTypeManager");
        public static readonly IProductTypeManager producttypeComponent = (IProductTypeManager)SpringHelper.ApplicationContext.GetObject("productTypeManager");
        public static readonly IBuyTypeManager buytypeComponent = (IBuyTypeManager)SpringHelper.ApplicationContext.GetObject("buyTypeManager");
        public static readonly IBrandFunctionManager brandfunctionComponent = (IBrandFunctionManager)SpringHelper.ApplicationContext.GetObject("brandFunctionManager");
        public static readonly IBrandProductManager brandproductComponent = (IBrandProductManager)SpringHelper.ApplicationContext.GetObject("brandProductManager");
        public static readonly IBrandBuyManager brandbuyComponent = (IBrandBuyManager)SpringHelper.ApplicationContext.GetObject("brandBuyManager");
        
        public ActionResult Index(int? page)
        {
            var brandinfolist = brandinfoComponent.GetBrandInfoList();
            return View(brandinfolist.AsPagination(page?? 1,20));
        }
        private void InitBrandInfo()
        {
            IList<Address> adlist = addressComponent.GetAddressList();
            SelectList sl = new SelectList(adlist, "ZipCode", "Name");
            ViewData["city"] = sl;
            ViewData["ftb"] = functiointypeComponent.GetDetialFun(0);
            ViewData["fts"] = functiointypeComponent.GetDetialFun(1);
            ViewData["product"] = producttypeComponent.GetProdType();
            ViewData["buytype"] = buytypeComponent.GetBuyTypeList();
        }
        public void MakeBrandInfo(BrandInfo bi)
        {
           IList<FunctionType> basfunlist=functiointypeComponent.GetDetialFun(0);
           IList<FunctionType> specfunlist=functiointypeComponent.GetDetialFun(1);
           IList<ProductType> prolist = producttypeComponent.GetProdType();
           IList<BuyType> buylist = buytypeComponent.GetBuyTypeList();

           foreach (BrandFunction bf in bi.BrandFunctions)
           {
               FunctionType fun = basfunlist.Where(f=>f.id == bf.Funcs.id).SingleOrDefault();
               if (fun == null)
               {
                   fun = specfunlist.Where(f => f.id == bf.Funcs.id).SingleOrDefault();
               }
               fun.hascheck = true;
           }
           foreach (BrandProduct bp in bi.BrandProducts)
           {
               ProductType pro = prolist.Where(p =>p.id == bp.ProductT.id).SingleOrDefault();
               if (pro != null)
               {
                   pro.haschecked = true;
               }
           }
           foreach (BrandBuy bb in bi.BrandBuys)
           {
               BuyType bt = buylist.Where(b =>b.id == bb.ButT.id).SingleOrDefault();
               if (bt != null)
               {
                   ViewData["bt" + bt.id] = bb.Price;
                   bt.haschecked = true;
               }
           }
           ViewData["ftb"] = basfunlist;
           ViewData["fts"] = specfunlist;
           ViewData["product"] = prolist;
           ViewData["buytype"] = buylist;
           ViewData["brandpic"] = bi.BrandPic;
           ViewData["selectedcity"] = bi.Address.ZipCode;
           
            //return bi;
        }
        public ActionResult CreateBrand()
        {
            InitBrandInfo();

            return View();
        }
        [HttpPost]
        public ActionResult EditBrand(BrandInfo bi)
        {
            SaveOrUpdateBrandInfo(bi,false);
            return RedirectToAction("Index");
        }
        public ActionResult EditBrand(int id)
        {
            BrandInfo bi = brandinfoComponent.Load(id);
            IList<Address> adlist = addressComponent.GetAddressList();
            SelectList sl = new SelectList(adlist, "ZipCode", "Name");
            ViewData["city"] = sl;
            MakeBrandInfo(bi);
            return View(bi);
        }

        public ActionResult DeleteBrand(int id)
        {
            BrandInfo bi = brandinfoComponent.Load(id);
            foreach (BrandFunction bf in bi.BrandFunctions)
            {
                brandfunctionComponent.Delete(bf.id);
            }
            foreach (BrandProduct bp in bi.BrandProducts)
            {
                brandproductComponent.Delete(bp.id);
            }
            foreach (BrandBuy bb in bi.BrandBuys)
            {
                brandbuyComponent.Delete(bb.id);
            }
            brandinfoComponent.Delete(id);
            return RedirectToAction("Index");
        }
        public void SaveOrUpdateBrandInfo(BrandInfo bi,bool issave)
        {
            bi.Address = new Address();
            bi.Address.ZipCode = Request.Form["city"].ToString();
            string[] basefuns = new string[] { };
            string[] specfuns = new string[] { };
            string[] brandPro = new string[] { };
            if(!string.IsNullOrEmpty(Request.Form["BaseFuns"]))
             basefuns = (Request.Form["BaseFuns"].ToString()).Split(new char[] { ',' });
            if (!string.IsNullOrEmpty(Request.Form["SpecFuns"]))
            specfuns = (Request.Form["SpecFuns"].ToString()).Split(new char[] { ',' });
            if (!string.IsNullOrEmpty(Request.Form["BrandProducts"]))
             brandPro = (Request.Form["BrandProducts"].ToString()).Split(new char[] { ',' });
            int objid = 0;
            if (issave)
            {

                //bi.BrandFunctions = new List<BrandFunction>();
                //bi.BrandProducts = new List<BrandProduct>();
                // bi.BrandBuy = new List<BrandBuy>();
                //bi.BrandFunctions
                objid = Convert.ToInt32(brandinfoComponent.Save(bi));

            }
            else
            {
                objid = bi.id;
                brandinfoComponent.Update(bi);
                foreach (BrandFunction bf in brandfunctionComponent.GetBfListByBInfoId(bi.id))
                {
                    brandfunctionComponent.Delete(bf.id);
                }
                foreach (BrandProduct bp in brandproductComponent.GetBpListByBInfoId(bi.id))
                {
                    brandproductComponent.Delete(bp.id);
                }
                foreach (BrandBuy bb in brandbuyComponent.GetBbListByBInfoId(bi.id))
                {
                    brandbuyComponent.Delete(bb.id);
                }

                //int i=0;
                //foreach (BrandFunction bf in bi.BrandFunctions)
                //{
                //    bf.Funcs = functiointypeComponent.Load(Convert.ToInt32(basefuns[i]));
                //    brandfunctionComponent.Update(bf);
                //}

            }
            for (int i = 0; i < basefuns.Length; i++)
            {
                BrandFunction bbf = new BrandFunction();
                bbf.BfId = objid;
                //  bbf.FunctionTypeId = Convert.ToInt32(basefuns[i]);
                bbf.Funcs = functiointypeComponent.Load(Convert.ToInt32(basefuns[i]));
                //brandfunctionComponent.AddBf(objid, Convert.ToInt32(basefuns[i]));
                // bi.BrandFunctions.Add(bbf);
                brandfunctionComponent.Save(bbf);
            }
            for (int i = 0; i < specfuns.Length; i++)
            {
                BrandFunction sbf = new BrandFunction();
                sbf.BfId = objid;
                //sbf.FunctionTypeId = Convert.ToInt32(specfuns[i]);
                sbf.Funcs = functiointypeComponent.Load(Convert.ToInt32(specfuns[i]));
                brandfunctionComponent.Save(sbf);
                // bi.BrandFunctions.Add(sbf);
            }

            for (int i = 0; i < brandPro.Length; i++)
            {
                BrandProduct bp = new BrandProduct();
                bp.BpId = objid;
                //bp.ProductTypeId = Convert.ToInt32(brandPro[i]);
                bp.ProductT = producttypeComponent.Load(Convert.ToInt32(brandPro[i]));
                brandproductComponent.Save(bp);
            }
            foreach (string key in Request.Form.AllKeys)
            {
                if (key.StartsWith("ckbt"))
                {
                    BrandBuy bb = new BrandBuy();
                    bb.BbId = objid;
                    //bb.BuyTypeId = Convert.ToInt32(Request.Form[key]);
                    bb.ButT = buytypeComponent.Load(Convert.ToInt32(Request.Form[key]));
                    bb.Price = float.Parse(Request.Form["txtprice" + key.Substring(4)]);
                    brandbuyComponent.Save(bb);
                }
            }
        }
        [HttpPost]
        public ActionResult CreateBrand(BrandInfo bi)
        {
            try
            {
                SaveOrUpdateBrandInfo(bi, true);
            }
            catch (Exception ex)
            {
                //System.IO.FileStream fs = new System.IO.FileStream("E:\\taomeetting.txt", System.IO.FileAccess.ReadWrite);
                //System.IO.File.Create(
                System.IO.StreamWriter sw = new System.IO.StreamWriter("E:\\taomeetting.txt",true);
                sw.WriteLine(ex.Message);
                sw.WriteLine(ex.StackTrace);
                sw.Close();
                //Response.Write(ex.Message + " \n" + ex.StackTrace);
                //return View();
            }
            
            // bi = new BrandFunction();
            // bi.BrandFunctions.
            // int newbrandid = ((BrandInfo)brandinfoComponent.Save(bi)).id;
            return RedirectToAction("Index");
        }
    }
}
