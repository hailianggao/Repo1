using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaoMeetting.Persistence;

namespace TaoMeetting.Business
{
    public class CompontentHelper<T, U>
        where T : class
        where U : IRepository<T>
    {
        public U Dao { get; set; }
        
        public object Save(T entity)
        {
            return Dao.Save(entity);
        }

        public T Get(object id)
        {
            return Dao.Get(id);
        }

        public T Load(object id)
        {
            return Dao.Load(id);
        }

        public IList<T> LoadAll()
        {
            return Dao.LoadAll();
        }

        public void Update(T entity)
        {
            Dao.Update(entity);
        }

        public void Delete(object id)
        {
            Delete(Load(id));
        }

        public void Delete(T entity)
        {
            Dao.Delete(entity);
        }

        public void SaveOrUpdate(T entity)
        {
            Dao.SaveOrUpdate(entity);
        }
    }
}
