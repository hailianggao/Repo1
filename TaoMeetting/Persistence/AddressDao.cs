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

    public interface IAddressDao : IRepository<Address>
    {
        IList<Address> GetAddressList();
        IList<Address> GetAddressListByBrand();
    }
  public class AddressDao:Repository<Address>,IAddressDao
    {
      public IList<Address> GetAddressList()
      {
          IQuery query = SessionFactory.GetCurrentSession().CreateQuery("from Address ad  where substring(ad.ZipCode,5,2)='00'");
          return query.List<Address>();
      }
      public IList<Address> GetAddressListByBrand()
      {
          IQuery query = SessionFactory.GetCurrentSession().CreateQuery("from Address ad  where ad.ZipCode in (select bi.Address.ZipCode from  BrandInfo bi)");
          return query.List<Address>();
      }
    }
}
