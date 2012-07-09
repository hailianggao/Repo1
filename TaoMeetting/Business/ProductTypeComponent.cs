using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TaoMeetting.Domain;
using TaoMeetting.Persistence;
using System.Collections;
namespace TaoMeetting.Business
{
    public interface IProductTypeManager
    {
        IList<ProductType> GetProdType();
        void Save(ProductType ft);
        ProductType Load(int id);
        void Delete(int id);
        void Update(ProductType ft);
    }
    public class ProductTypeComponent : CompontentHelper<ProductType, ProductTypeDao>, IProductTypeManager
    {
       public IList<ProductType> GetProdType()
       {
           return Dao.GetProdType();
       }
       public void Save(ProductType ft)
       {
           Dao.Save(ft);
       }
       public void Delete(int id)
       {
           Dao.Delete(Load(id));
       }
       public void Update(ProductType ft)
       {
           Dao.Update(ft);
       }
       public ProductType Load(int id)
       {
           return Dao.Load(id);
       }
    }
}
