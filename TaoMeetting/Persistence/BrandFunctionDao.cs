using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaoMeetting.Domain;
using NHibernate;
using System.Collections;
using NHibernate.Criterion;
using NHibernate.Type;
using Spring.Data.NHibernate.Generic;
namespace TaoMeetting.Persistence
{
    public interface IBrandFunctionDao : IRepository<BrandFunction>
    {
        IList<BrandFunction> GetBfList();
        void AddBf(int BiId,int bfid);
        IList<BrandFunction> GetBfListByBInfoId(int BInfoId);
    }
    public class BrandFunctionDao:Repository<BrandFunction>,IBrandFunctionDao
    {
        public IList<BrandFunction> GetBfList()
        {
            IQuery query = SessionFactory.GetCurrentSession().CreateQuery("from BrandFunction");
            return query.List<BrandFunction>();
        }
        public void AddBf(int BiId, int bfid)
        {
            IQuery query = SessionFactory.GetCurrentSession().CreateQuery("insert into BrandFunction(BfId,FunctionTypeId) values(biid,bfid)")
                           .SetInt32("biid", BiId)
                           .SetInt32("bfid", bfid);
                          //.UniqueResult();
        }
        public IList<BrandFunction> GetBfListByBInfoId(int BInfoId)
        {

            IQuery query = SessionFactory.GetCurrentSession().CreateQuery("from BrandFunction bf where BfId=:bfid")
                           .SetInt32("bfid", BInfoId);
            return query.List<BrandFunction>();
        }
    }
}
