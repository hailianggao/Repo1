using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TaoMeetting.Domain;
using TaoMeetting.Persistence;
using System.Collections;
namespace TaoMeetting.Business
{
    public interface IAddressManager
    {
        IList<Address> GetAddressList();
        IList<Address> GetAddressListByBrand();
        //void Save(Address ft);
        //Address Load(int id);
        //void Delete(int id);
        //void Update(Address ft);
    }
    public class AddressComponent:CompontentHelper<Address,AddressDao>,IAddressManager
    {
        public IList<Address> GetAddressList()
        {
            return Dao.GetAddressList();
        }
        public IList<Address> GetAddressListByBrand()
        {
            return Dao.GetAddressListByBrand();
        }
    }
}
