using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TaoMeetting.Domain;
using NHibernate;
using System.Collections;
using NHibernate.Criterion;
namespace TaoMeetting.Persistence
{

    public interface IBrandInfoDao : IRepository<BrandInfo>
    {
        IList<BrandInfo> GetBrandInfoList();
        IList<BrandInfo> GetBrandInfoListByFilter(int proid,int priceid,int buytypeid,int basefunid,int specfunid,string addressid);
    }
   public class BrandInfoDao:Repository<BrandInfo>,IBrandInfoDao
    {
       public IList<BrandInfo> GetBrandInfoList()
       {
           IQuery query = SessionFactory.GetCurrentSession().CreateQuery("from BrandInfo bi order by bi.Weight desc");
           return query.List<BrandInfo>();
       }
       public IList<BrandInfo> GetBrandInfoListByFilter(int proid, int priceid, int buytypeid, int basefunid,int specfunid, string addressid)
       {
           string sqlquery = "select distinct bi from BrandInfo bi";
           string filterstr = " where 1=1";
           bool haspro = false, hasprice = false, hasbasefun = false,hasspecfun=false, hasbuytype = false, hasadd = false;
           if (proid> 0)
           {
               sqlquery += " join fetch  bi.BrandProducts bp";
               filterstr += " and bp.ProductT.id=:proid";
               haspro = true;
           }
           sqlquery += " join fetch bi.BrandBuys bbs";

           if (priceid > 0)
           {
               filterstr += " and (bbs.Price>=(select pr.lowprice from PriceRange pr where pr.id=:priceid) and bbs.Price <=(select pr.highprice from PriceRange pr where pr.id=:priceid))";
               hasprice = true;
           }
           int bcount =0;
           //if (checkArray(buytypeid))
           //{
           //    bcount = buytypeid.Length;
           //    filterstr += " and (";
           //    //string innerfilter=null;
           //    for (int i = 0; i < bcount; i++)
           //    {
           //        
           //        if (i != bcount-1)
           //        {
           //            filterstr += " or ";
           //        }
           //    }
           //    //filterstr += innerfilter;
           //      filterstr += ")";
           //    hasbuytype = true;
           //}
           if (buytypeid > 0)
           {
               filterstr += " and bbs.ButT.id =:buytypeid";
               hasbuytype = true;
           }
           sqlquery += " join fetch bi.BrandFunctions bfs";
           #region basefun||speffun
           //if (basefunid > 0)
           //{
           //    hasbasefun = true;
           //    filterstr += " and ((bfs.Funcs.id=:basefunid and bfs.Funcs.FunType=0) ";
           //}
           //if (specfunid > 0)
           //{
           //    if (hasbasefun)
           //    {
           //        filterstr += " or (bfs.Funcs.id=:specfunid and bfs.Funcs.FunType=1))";
           //    }
           //    else
           //    {
           //        hasbasefun = true;
           //        filterstr += " and bfs.Funcs.id=:specfunid and bfs.Funcs.FunType=1 ";
           //    }
           //}
           //else
           //{
           //    if (hasbasefun)
           //    {
           //        filterstr += ")";
           //    }
           //}
           #endregion
           //if (basefunid > 0)
           //{
           //    hasbasefun = true;
           //    filterstr += " and bfs.Funcs.id=:basefunid and bfs.Funcs.FunType=0";
           //}
           //else
           //{
           //    if (specfunid > 0)
           //    {
           //        filterstr += " and bfs.Funcs.id=:specfunid and bfs.Funcs.FunType=1";
           //        hasspecfun = true;
           //    }
           //}

           if (!string.IsNullOrEmpty(addressid) && addressid.Length > 0&&Convert.ToInt32(addressid)!=0)
           {
               filterstr += " and bi.Address.ZipCode =:address";
               hasadd = true;
           }
           filterstr += " order by bi.Weight desc";
           sqlquery += filterstr;
           IQuery query =null;
           try
           {
               query = SessionFactory.GetCurrentSession().CreateQuery(sqlquery);
           }
           catch (Exception ex)
           {
               string errmes = ex.Message;
           }

           if (haspro)
           {
               query.SetInt32("proid", proid);
           }
           if (hasprice)
               query.SetInt32("priceid", priceid);
           if (hasbuytype)
           {
               //query.SetParameter("buytypeid", buytypeid);
              // for (int i = 0; i < bcount; i++)
               //{
                   query.SetInt32("buytypeid", buytypeid);
               //}
           }
           //if (hasbasefun)
           //{
           //    if (basefunid > 0)
           //        query.SetInt32("basefunid", basefunid);
           //}
           //else
           //{
           //    if (hasspecfun)
           //    {
           //        if (specfunid > 0)
           //            query.SetInt32("specfunid", specfunid);
           //    }
           //}
           //if (hasspecfun)
           //    query.SetParameter("specfunid", specfunid);
           if (hasadd)
               query.SetString("address", addressid);
           IList<BrandInfo> tempbrandInfolist = query.List<BrandInfo>();
           IList<BrandInfo> filterbrandInfolist = new List<BrandInfo>();

           if (basefunid > 0 && specfunid > 0)
           {
               foreach (BrandInfo item in tempbrandInfolist)
               {
                   if (item.BrandFunctions.Where(basef => (basef.Funcs.id == basefunid && basef.Funcs.FunType == 0)).ToList().Count > 0 &&
                       item.BrandFunctions.Where(specf => (specf.Funcs.id == specfunid && specf.Funcs.FunType == 1)).ToList().Count > 0)
                   {
                       filterbrandInfolist.Add(item);
                   }
               }
           }
           else
           {
               if (basefunid > 0)
               {
                   foreach (BrandInfo item in tempbrandInfolist)
                   {
                       if (item.BrandFunctions.Where(basef => (basef.Funcs.id == basefunid && basef.Funcs.FunType == 0)).ToList().Count > 0)
                       {
                           filterbrandInfolist.Add(item);
                       }
                   }
               }
               else if(specfunid>0)
               {
                   foreach (BrandInfo item in tempbrandInfolist)
                   {
                       if (item.BrandFunctions.Where(specf => (specf.Funcs.id == specfunid && specf.Funcs.FunType == 1)).ToList().Count > 0)
                       {
                           filterbrandInfolist.Add(item);
                       }
                   }
               }
            }
           return filterbrandInfolist.Count > 0 ? filterbrandInfolist : tempbrandInfolist;
       }
       private bool checkArray(int[] tarArray)
       {
           if (tarArray != null && tarArray.Length > 0)
           {
               if ((tarArray.Length == 1 && tarArray[0] == 0) || (tarArray.Length == 2 && tarArray[0] == 0 && tarArray[1] == 0))
               {
                   return false;
               }
               else
               {
                   return true;
               }
           }
           else
           {
               return false;
           }
       }
    }
}
