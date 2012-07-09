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
    public class HomeController : Controller
    {
        public static readonly IProductTypeManager producttypeComponent = (IProductTypeManager)SpringHelper.ApplicationContext.GetObject("productTypeManager");
        public static readonly IPriceRangeManager pricerangeComponent = (IPriceRangeManager)SpringHelper.ApplicationContext.GetObject("pricerangeManager");
        public static readonly IFunctionTypeManager functiointypeComponent = (IFunctionTypeManager)SpringHelper.ApplicationContext.GetObject("functionTypeManager");
        public static readonly IAddressManager addressComponent = (IAddressManager)SpringHelper.ApplicationContext.GetObject("addressManager");
        public static readonly IBrandInfoManager brandinfoComponent = (IBrandInfoManager)SpringHelper.ApplicationContext.GetObject("brandInfoManager");
        public static readonly IBuyTypeManager buytypeComponent = (IBuyTypeManager)SpringHelper.ApplicationContext.GetObject("buyTypeManager");

        public ActionResult Index()
        {
            //ViewBag.Message = "Welcome to ASP.NET MVC!";\
            IList<ProductType> proList = producttypeComponent.GetProdType();
            return View(proList);
        }
        public static IList<BrandInfo> CurrentBrandInfolist = null;
        public static int totalPage=0, pagesize=10,currentPage=0,totalCount=0,prevEnable = 1, nextEnable = 1;
        public ActionResult MainPage(int id)
        {
            ViewBag.objid = id;
            IList<ProductType> proList = producttypeComponent.GetProdType();
            ProductType pt = proList.Where(p => p.id == id).SingleOrDefault(); 
            pt.haschecked=true;
            ViewData["prolist"] = proList;
            IList<PriceRange> priceList = pricerangeComponent.GetPriceRange();
            ViewData["pricelist"] = priceList;
            IList<Address> addresslist = addressComponent.GetAddressListByBrand();
            ViewData["adlist"] = addresslist;
            IList<FunctionType> basefunlist= functiointypeComponent.GetDetialFun(0);
            ViewData["basefun"] = basefunlist;
            IList<FunctionType> specfunlist = functiointypeComponent.GetDetialFun(1);
            ViewData["specfun"] = specfunlist;
            IList<BuyType> buytypelist = buytypeComponent.GetBuyTypeList();
            ViewData["buytypelist"] = buytypelist;
            IList<BrandInfo> brandlist = brandinfoComponent.GetBrandInfoListByFilter(id,0,0,0,0,"");
            FilterBrandList(brandlist);
            InitPageParam(brandlist);
            StringBuilder sb = new StringBuilder();
            sb.Append(MakeJsonString(brandlist.Take(pagesize).ToList()));
            ViewBag.datastr = sb.ToString();
            return View();  
        }
        public void FilterBrandList(IList<BrandInfo> list)
        {
            foreach (BrandInfo item in list)
            {
                item.BrandProducts = item.BrandProducts.Distinct<BrandProduct>().ToList();
                item.BrandBuys = item.BrandBuys.Distinct<BrandBuy>().ToList();
            }
        }
        public void InitPageParam(IList<BrandInfo> list)
        {
            CurrentBrandInfolist = list;
            currentPage = 1;
            totalCount = list.Count;
            totalPage = totalCount % pagesize == 0 ? totalCount / pagesize : totalCount / pagesize + 1;
            prevEnable = 0;
            if (totalPage > 1)
            {
                nextEnable = 1;
            }
            else
            {
                nextEnable = 0;
            }
           // ViewBag.prevEnable = prevEnable;
           // ViewBag.nextEnable = nextEnable;
        }
        public string Pager(int pageIndex)
        {
            List<BrandInfo> tempList = new List<BrandInfo>();
          
            //if (action == "prev")
            //{
            //    if (currentPage > 0)
            //    {
            //        currentPage--;
            //    }
            //    else
            //    {
            //        currentPage = 0;
            //    }
            //    tempList = CurrentBrandInfolist.Skip((currentPage - 1) * pagesize).Take(pagesize).ToList();
            //    prevEnable = currentPage > 1? 1 : 0;
            //    nextEnable = currentPage < totalPage ? 1 : 0;
            //}
            //else
            //{
            //    tempList = CurrentBrandInfolist.Skip(currentPage * pagesize).Take(pagesize).ToList();
            //    if (currentPage < totalPage)
            //    {
            //        currentPage++;
            //    }
            //    else
            //    {
            //        currentPage = totalPage;
            //    }
            //    prevEnable = currentPage > 1 ? 1 : 0;
            //    nextEnable = currentPage < totalPage ? 1 : 0;
            //}
            currentPage = pageIndex;
            tempList = CurrentBrandInfolist.Skip((pageIndex-1) * pagesize).Take(pagesize).ToList();
            return MakeJsonString(tempList);
        }
        public string GetSearchData(int productid, int pricerangeid, int buytypeid, int basefun, int specfunid, string address)
        {
            //basefun.sp

           // string[] basefunstr = basefun.Split(new char[] { ',' });
            // string[] buytypestr = buytypeid.Split(new char[] { ',' });
            //int[] basefunids = new int[basefunstr.Length];
            //int[] buytypeids = new int[buytypestr.Length];
            //if (basefun != null && basefunstr.Length > 0)
            //{
            //    for (int i = 0; i < basefunstr.Length; i++)
            //    {
            //        if (!string.IsNullOrEmpty(basefunstr[i]))
            //            basefunids[i] = Convert.ToInt32(basefunstr[i]);
            //    }
            //}
            //if (buytypeid != null && buytypestr.Length > 0)
            //{
            //    for (int i = 0; i < buytypestr.Length; i++)
            //    {
            //        if (!string.IsNullOrEmpty(buytypestr[i]))
            //            buytypeids[i] = Convert.ToInt32(buytypestr[i]);
            //    }
            //}
            IList<BrandInfo> brandinfolist = brandinfoComponent.GetBrandInfoListByFilter(productid, pricerangeid, buytypeid, basefun,specfunid, address);
            //Newtonsoft.Json.JsonConvert.SerializeObject(brandinfolist)
            FilterBrandList(brandinfolist);
            InitPageParam(brandinfolist);
            return MakeJsonString(brandinfolist.Take(pagesize).ToList());
        }
        public string MakeJsonString(IList<BrandInfo> brandlist)
        {
            StringBuilder datastr = new StringBuilder();
            int currentIndex = 1, totalCount = brandlist.Count;
            datastr.Append("[");
            if (brandlist.Count > 0)
            {
               datastr.Append("{'PrevEnable':'" + prevEnable.ToString() + "','NextEnable':'" + nextEnable + "','CurrentPage':'"+currentPage+"','TotalPage':'"+totalPage+"','TotalCount':'"+CurrentBrandInfolist.Count+"'},");
            }
            foreach (BrandInfo bi in brandlist)
            {
                datastr.Append("{");
                datastr.Append("'id':'" + bi.id + "',");
                datastr.Append("'BrandName':'" + bi.BrandName + "',");
                datastr.Append("'BrandPic':'" + bi.BrandPic + "',");
                datastr.Append("'Address':'" + bi.Address.Name + "',");
                datastr.Append("'Phone':'" + bi.Phone + "',");
                datastr.Append("'BaseFunScore':'" + bi.BaseFunScore + "',");
                datastr.Append("'SpecialFunScore':'" + bi.SpecialFunScore + "',");
                datastr.Append("'Url':'" + bi.Url + "',");
                datastr.Append("'Buytypes':[");
                for (int i = 0; i < bi.BrandBuys.Count; i++)
                {
                    datastr.Append("{");
                    datastr.Append("'BuyName':'" + bi.BrandBuys[i].ButT.BuyTypeName + "',");
                    datastr.Append("'Price':'" + bi.BrandBuys[i].Price + "'");
                    if (i == bi.BrandBuys.Count - 1)
                    {
                        datastr.Append("}");
                    }
                    else
                    {
                        datastr.Append("},");
                    }
                }
                datastr.Append("],");
                datastr.Append("'Products':[");
                for (int j = 0; j < bi.BrandProducts.Count; j++)
                {
                    datastr.Append("{");
                    datastr.Append("'ProName':'" + bi.BrandProducts[j].ProductT.TypeName + "'");
                    if (j == bi.BrandProducts.Count - 1)
                    {
                        datastr.Append("}");
                    }
                    else
                    {
                        datastr.Append("},");
                    }
                }
                datastr.Append("]");
                if (currentIndex != totalCount)
                {
                    datastr.Append("},");
                    currentIndex++;
                }
                else
                {
                    datastr.Append("}");
                }
            }
            datastr.Append("]");
            return datastr.ToString();
        }
        public ActionResult About()
        {
            return View();
        }
    }
}
