using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaoMeetting.Domain;
using TaoMeetting.Persistence;
using System.Collections;
namespace TaoMeetting.Business
{
    public interface IBrandProductManager
    {
        IList<BrandProduct> GetBpList();
        object Save(BrandProduct bp);
        BrandProduct Load(int id);
        void Delete(int id);
        void Update(BrandProduct bp);
        IList<BrandProduct> GetBpListByBInfoId(int BInfoId);
    }
    public class BrandProductComponent : CompontentHelper<BrandProduct, BrandProductDao>, IBrandProductManager
    {
        public IList<BrandProduct> GetBpList()
        {

            return Dao.GetBpList();
        }
        public object Save(BrandProduct bf)
        {
            return Dao.Save(bf);
        }
        public void Delete(int id)
        {
            Dao.Delete(Load(id));
        }
        public void Update(BrandProduct bf)
        {
            Dao.Update(bf);
        }
        public BrandProduct Load(int id)
        {
            return Dao.Load(id);
        }
        public IList<BrandProduct> GetBpListByBInfoId(int BInfoId)
        {
            return Dao.GetBpListByBInfoId(BInfoId);
        }
    }
}
