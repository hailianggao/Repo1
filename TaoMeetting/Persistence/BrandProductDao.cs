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
    public interface IBrandProductDao : IRepository<BrandProduct>
    {
        IList<BrandProduct> GetBpList();
        IList<BrandProduct> GetBpListByBInfoId(int BInfoId);
    }
    public class BrandProductDao : Repository<BrandProduct>, IBrandProductDao
    {
        public IList<BrandProduct> GetBpList()
        {
            IQuery query = SessionFactory.GetCurrentSession().CreateQuery("from BrandProduct");
            return query.List<BrandProduct>();
        }
        public IList<BrandProduct> GetBpListByBInfoId(int BInfoId)
        {
            IQuery query = SessionFactory.GetCurrentSession().CreateQuery("from BrandProduct bf where BpId=:bpid")
                           .SetInt32("bpid", BInfoId);
            return query.List<BrandProduct>();
        }
    }
}
