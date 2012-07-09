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
    public interface IPriceRangeDao : IRepository<PriceRange>
    {
        IList<PriceRange> GetPriceRange();
    }
    public class PriceRangeDao : Repository<PriceRange>, IPriceRangeDao
    {
        public IList<PriceRange> GetPriceRange()
        {
            IQuery query = SessionFactory.GetCurrentSession().CreateQuery("from PriceRange pr");
            return query.List<PriceRange>();
        }
    }
}
