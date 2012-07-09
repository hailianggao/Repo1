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

    public interface IBuyTypeDao : IRepository<BuyType>
    {
        IList<BuyType> GetBuyTypeList();
    }
    public class BuyTypeDao:Repository<BuyType>,IBuyTypeDao
    {
        public IList<BuyType> GetBuyTypeList()
        {
            IQuery query = SessionFactory.GetCurrentSession().CreateQuery("from BuyType");
            return query.List<BuyType>();
        }
    }
}
