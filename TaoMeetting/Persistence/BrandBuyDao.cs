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
    public interface IBrandBuyDao : IRepository<BrandBuy>
    {
        IList<BrandBuy> GetBbList();
        IList<BrandBuy> GetBbListByBInfoId(int BInfoId);
        void DeleteByBtId(int btid);
    }
    public class BrandBuyDao : Repository<BrandBuy>, IBrandBuyDao
    {
        public IList<BrandBuy> GetBbList()
        {
            IQuery query = SessionFactory.GetCurrentSession().CreateQuery("from BrandBuy");
            return query.List<BrandBuy>();
        }
        public IList<BrandBuy> GetBbListByBInfoId(int BInfoId)
        {
            IQuery query = SessionFactory.GetCurrentSession().CreateQuery("from BrandBuy bf where BbId=:bbid")
                          .SetInt32("bbid", BInfoId);
            return query.List<BrandBuy>();
        }
        public void DeleteByBtId(int btid)
        {
           BrandBuy bb= SessionFactory.GetCurrentSession().CreateQuery("from BrandBuy bb where bb.ButT.id=:btid")
                                               .SetInt32("btid", btid)
                                               .UniqueResult<BrandBuy>();
           this.Delete(bb);
            //SessionFactory.GetCurrentSession().CreateQuery("delete from BrandBuy bb where bb.ButT.id=:btid")
            //                                   .SetInt32("btid", btid)
            //                                   .UniqueResult();
        }
    }
}
