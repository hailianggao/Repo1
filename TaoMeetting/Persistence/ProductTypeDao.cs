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

    public interface IProductTypeDao : IRepository<ProductType>
    {
        IList<ProductType> GetProdType();
    }
  public  class ProductTypeDao:Repository<ProductType>,IProductTypeDao
    {
      public IList<ProductType> GetProdType()
      {
          IQuery query = SessionFactory.GetCurrentSession().CreateQuery("from ProductType pt order by pt.id");
          return query.List<ProductType>();
      }
    }
}
