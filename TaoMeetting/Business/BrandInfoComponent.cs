using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaoMeetting.Domain;
using TaoMeetting.Persistence;
using System.Collections;
namespace TaoMeetting.Business
{
    public interface IBrandInfoManager
    {
        IList<BrandInfo> GetBrandInfoList();
        object Save(BrandInfo ft);
        BrandInfo Load(int id);
        void Delete(int id);
        void Update(BrandInfo ft);
        IList<BrandInfo> GetBrandInfoListByFilter(int proid, int priceid, int buytypeid, int basefunid,int specfunid, string addressid);
    }
   public class BrandInfoComponent:CompontentHelper<BrandInfo,BrandInfoDao>,IBrandInfoManager
    {
       public IList<BrandInfo> GetBrandInfoList()
        {

            return MakeBrandInfoList(Dao.GetBrandInfoList());
        }
       public object Save(BrandInfo bi)
        {
           return Dao.Save(bi);
        }
        public void Delete(int id)
        {
            Dao.Delete(Load(id));
        }
        public void Update(BrandInfo bi)
        {
            Dao.Update(bi);
        }
        public BrandInfo Load(int id)
        {
            return Dao.Load(id);
        }
        public IList<BrandInfo> MakeBrandInfoList(IList<BrandInfo> bdlist)
        {
            foreach (BrandInfo item in bdlist)
            {
                if (item.BrandProducts != null && item.BrandProducts.Count != 0)
                {
                    foreach (BrandProduct bp in item.BrandProducts)
                    {
                        item.Products += bp.ProductT.TypeName+"\n";
                       // item.Products+= "/";
                    }
                   // item.Products=item.Products.Substring(0, item.Products.Length - 1);
                }
                if (item.BrandBuys != null)
                {
                   // item.Buytypes += "<table>";
                    foreach (BrandBuy bb in item.BrandBuys)
                    {
                        item.Buytypes += bb.ButT.BuyTypeName + ":" + bb.Price + "元/点/月";
                    }
                    //item.Buytypes += "</table>";
                }
                if (item.BrandFunctions != null)
                {
                    foreach (BrandFunction bf in item.BrandFunctions)
                    {
                        if (bf.Funcs.FunType == 0)
                        {
                            item.BFunctions += bf.Funcs.FunName+",";
                        }
                        else if (bf.Funcs.FunType == 1)
                        {
                            item.SFunctions += bf.Funcs.FunName + ",";
                        }
                    }
                }
                if(!string.IsNullOrEmpty(item.BFunctions))
                item.BFunctions = item.BFunctions.Substring(0, item.BFunctions.Length - 1);
                if(!string.IsNullOrEmpty(item.SFunctions))
                item.SFunctions = item.SFunctions.Substring(0, item.SFunctions.Length - 1);
               // item.Buytypes = item.Buytypes.Substring(0, item.Buytypes.Length - 1);
            }
            return bdlist;
        }
        public IList<BrandInfo> GetBrandInfoListByFilter(int proid, int priceid, int buytypeid, int basefunid,int specfunid, string addressid)
        {
            return Dao.GetBrandInfoListByFilter(proid, priceid,buytypeid, basefunid,specfunid, addressid);
        }
    }
}
