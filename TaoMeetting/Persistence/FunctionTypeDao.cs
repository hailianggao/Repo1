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

    public interface IFunctionTypeDao : IRepository<FunctionType>
    {
         IList<FunctionType> GetFuncType();
         IList<FunctionType> GetDetailFunc(int funtype);
         
    }
    public class FunctionTypeDao:Repository<FunctionType>,IFunctionTypeDao
    {
        public IList<FunctionType> GetFuncType()
        {
            IQuery query = SessionFactory.GetCurrentSession().CreateQuery("from FunctionType ft order by ft.id");
            return query.List<FunctionType>();
        }
        public IList<FunctionType> GetDetailFunc(int funtype)
        {
            IQuery query = SessionFactory.GetCurrentSession().CreateQuery("from FunctionType ft where ft.FunType=:funtype").SetInt32("funtype", funtype);
            return query.List<FunctionType>();
        }
    }
}
