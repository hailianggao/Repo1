using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaoMeetting.Domain;
using TaoMeetting.Persistence;
using System.Collections;
namespace TaoMeetting.Business
{
    public interface IPriceRangeManager
    {
        IList<PriceRange> GetPriceRange();
        object Save(PriceRange pr);
        PriceRange Load(int id);
        void Delete(int id);
        void Update(PriceRange pr);
    }
  public  class PriceRangeComponent:CompontentHelper<PriceRange,PriceRangeDao>,IPriceRangeManager
    {
      public IList<PriceRange> GetPriceRange()
      {
          return Dao.GetPriceRange();
      }
      public void Save(PriceRange pr)
      {
          Dao.Save(pr);
      }
      public void Delete(int id)
      {
          Dao.Delete(Load(id));
      }
      public void Update(PriceRange pr)
      {
          Dao.Update(pr);
      }
      public PriceRange Load(int id)
      {
          return Dao.Load(id);
      }
    }
}
