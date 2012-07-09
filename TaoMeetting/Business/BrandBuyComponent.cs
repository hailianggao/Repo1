using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaoMeetting.Domain;
using TaoMeetting.Persistence;
using System.Collections;
namespace TaoMeetting.Business
{
    public interface IBrandBuyManager
    {
        IList<BrandBuy> GetBbList();
        object Save(BrandBuy bb);
        BrandBuy Load(int id);
        void Delete(int id);
        void Update(BrandBuy bb);
        IList<BrandBuy> GetBbListByBInfoId(int BInfoId);
        void DeleteByBtId(int btid);
    }
    public class BrandBuyComponent : CompontentHelper<BrandBuy, BrandBuyDao>, IBrandBuyManager
    {
        public IList<BrandBuy> GetBbList()
        {
            return Dao.GetBbList();
        }
        public object Save(BrandBuy bb)
        {
            return Dao.Save(bb);
        }
        public void Delete(int id)
        {
            Dao.Delete(Load(id));
        }
        public void Update(BrandBuy bb)
        {
            Dao.Update(bb);
        }
        public BrandBuy Load(int id)
        {
            return Dao.Load(id);
        }
        public IList<BrandBuy> GetBbListByBInfoId(int BInfoId)
        {
            return Dao.GetBbListByBInfoId(BInfoId);
        }
        public void DeleteByBtId(int btid)
        {
            Dao.DeleteByBtId(btid);
        }
    }
}
