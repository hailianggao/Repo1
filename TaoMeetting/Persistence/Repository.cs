using System.Collections.Generic;
using Spring.Data.NHibernate.Generic.Support;
using Spring.Data.NHibernate.Generic;
using NHibernate;
using System.Reflection;
using System.Collections;
using NHibernate.Search;
using NHibernate.Search.Attributes;

namespace TaoMeetting.Persistence
{
    public interface IRepository<T>
    {
        void Delete(T entity);
        T Get(object id);
        T Load(object id);
        IList<T> LoadAll();
        object Save(T entity);
        void Update(T entity);
        void SaveOrUpdate(T entity);
　　 // IList<T>　FullTextSearch(string　query);
    }

    public class Repository<T> : HibernateDaoSupport, IRepository<T> 
        where T : class
    {
        public T Load(object id)
        {
            return HibernateTemplate.Load<T>(id);
        }

        public T Get(object id)
        {
            return HibernateTemplate.Get<T>(id);
        }

        public IList<T> LoadAll()
        {
            return HibernateTemplate.LoadAll<T>();
        }

        public object Save(T entity)
        {
            return HibernateTemplate.Save(entity);
        }

        public void Update(T entity)
        {
            HibernateTemplate.Update(entity);
        }

        public void Delete(T entity)
        {
            HibernateTemplate.Delete(entity);
        }

        public void SaveOrUpdate(T entity)
        {
            HibernateTemplate.SaveOrUpdate(entity);
        }

        public void Lock(T entity)
        {
            HibernateTemplate.Lock(entity, LockMode.None);
        }

        ///　<summary>
　　  ///　全文检索
　　  ///　</summary>
　　  ///　<typeparam　name="T">类型</typeparam>
　　  ///　<param　name="query">关键词</param>
　　  ///　<returns></returns>
        //public IList<T> FullTextSearch(string query)
        //{
        //    //生成字段列表
        //    object objTarget = Assembly.GetAssembly(typeof(T)).CreateInstance(typeof(T).ToString());
        //    PropertyInfo[] pps = objTarget.GetType().GetProperties();
        //    string fs = "";
        //    foreach (PropertyInfo p in pps)
        //    {
        //        var fieldAttr = p.GetCustomAttributes
        //            (typeof(FieldAttribute), false);
        //        if (fieldAttr != null && fieldAttr.Length > 0)
        //        {
        //            fs += p.Name + ",";
        //        }
        //    }
        //    string[] fields = fs.TrimEnd(',').Split(',');
        //    //中文拆词　　　　　　　　　　　　
        //    ChineseAnalyzer cnAnalyzer = new ChineseAnalyzer();
        //    MultiFieldQueryParser parser = new MultiFieldQueryParser(fields, cnAnalyzer);

        //    Query queryObj;
        //    try
        //    {
        //        queryObj = parser.Parse(query);
        //    }
        //    catch (ParseException)
        //    {
        //        return null;
        //    }
        //    //使用当前Session　　　　　　　　　　　　
        //    IFullTextSession fullTextSession = (IFullTextSession)NHibernate.Search.Search.CreateFullTextSession(Session);
        //    IQuery nhQuery = fullTextSession.CreateFullTextQuery(queryObj, typeof(T));

        //    //结果
        //    IList<T> results = nhQuery.List<T>();
        //    return results;
        //}
    }
}
