using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaoMeetting.Domain;
using TaoMeetting.Persistence;
using System.Collections;
namespace TaoMeetting.Business
{
    public interface IBuyTypeManager
    {
        IList<BuyType> GetBuyTypeList();
        object Save(BuyType ft);
        BuyType Load(int id);
        void Delete(int id);
        void Update(BuyType ft);
    }
   public class BuyTypeComponent:CompontentHelper<BuyType,BuyTypeDao>,IBuyTypeManager
    {
       public IList<BuyType> GetBuyTypeList()
        {

            return Dao.GetBuyTypeList();
        }
        public object Save(BuyType bt)
        {
            return Dao.Save(bt);
        }
        public void Delete(int id)
        {
            Dao.Delete(Load(id));
        }
        public void Update(BuyType bi)
        {
            Dao.Update(bi);
        }
        public BuyType Load(int id)
        {
            return Dao.Load(id);
        }
    }
}
