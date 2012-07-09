using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaoMeetting.Domain;
using TaoMeetting.Persistence;
using System.Collections;
namespace TaoMeetting.Business
{
    public interface IBrandFunctionManager
    {
        IList<BrandFunction> GetBfList();
        object Save(BrandFunction ft);
        BrandFunction Load(int id);
        void Delete(int id);
        void Update(BrandFunction ft);
        void AddBf(int BiId, int bfid);
        IList<BrandFunction> GetBfListByBInfoId(int BInfoId);
    }
   public class BrandFunctionComponent:CompontentHelper<BrandFunction,BrandFunctionDao>,IBrandFunctionManager
    {
       public IList<BrandFunction> GetBfList()
        {

            return Dao.GetBfList();
        }
        public object Save(BrandFunction bf)
        {
            return Dao.Save(bf);
        }
        public void Delete(int id)
        {
            Dao.Delete(Load(id));
        }
        public void Update(BrandFunction bf)
        {
            Dao.Update(bf);
        }
        public BrandFunction Load(int id)
        {
            return Dao.Load(id);
        }
        public void AddBf(int BiId, int bfid)
        {
             Dao.AddBf(BiId, bfid);
        }
        public IList<BrandFunction> GetBfListByBInfoId(int BInfoId)
        {
            return Dao.GetBfListByBInfoId(BInfoId);
        }
    }
}
