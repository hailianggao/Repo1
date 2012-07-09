using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaoMeetting.Domain;
using TaoMeetting.Persistence;
using System.Collections;
namespace TaoMeetting.Business
{
    public interface IFunctionTypeManager
    {
         IList<FunctionType> GetFuncType();
         IList<FunctionType> GetDetialFun(int funtype);
         void Save(FunctionType ft);
         FunctionType Load(int id);
         void Delete(int id);
         void Update(FunctionType ft);
    }
   public class FunctionTypeComponent:CompontentHelper<FunctionType,FunctionTypeDao>,IFunctionTypeManager
    {
       public IList<FunctionType> GetFuncType()
       {

           return  MakeFuncTypeList(Dao.GetFuncType());
       }
       public IList<FunctionType> GetDetialFun(int funtype)
       {
           return Dao.GetDetailFunc(funtype);
       }
       public void Save(FunctionType ft)
       {
           Dao.Save(ft);
       }
       public void Delete(int id)
       {
           Dao.Delete(Load(id));
       }
       public void Update(FunctionType ft)
       {
           Dao.Update(ft);
       }
       public FunctionType Load(int id)
       {
           return Dao.Load(id);
       }
       private IList<FunctionType> MakeFuncTypeList(IList<FunctionType> lists)
       {
           foreach (FunctionType item in lists)
           {
               if (item.FunType == 0)
               {
                   item.FunTypeName = "基础功能";
               }
               else
               {
                   item.FunTypeName = "特殊功能";
               }
           }
           return lists;
       }
    }
   
}
