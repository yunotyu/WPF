using MyWpf.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.Dal
{
    public class BaseDal<T> where T : class
    {
        public static AppDbContext Db = new AppDbContext();

        public List<T> Query()
        {
           return Db.Set<T>().AsNoTracking().Where((t) =>true).ToList();
        }

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <returns></returns>
        public int GetAllItemCount()
        {
            return Db.Set<T>().AsNoTracking().Count();
        }

        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="curPage"></param>
        /// <param name="perPageItem"></param>
        /// <returns></returns>
        public IQueryable<T> GetPage()
        {
            return Db.Set<T>().AsNoTracking().Where(u => true);
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="model"></param>
        public bool Modify(T model)
        {
            Db.Entry<T>(model).State = System.Data.Entity.EntityState.Modified;
            return Db.SaveChanges()>0;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(T model)
        {
            Db.Set<T>().Add(model);
            return Db.SaveChanges()>0;
        }

        public bool Del(T model)
        {
            Db.Entry<T>(model).State = System.Data.Entity.EntityState.Deleted;
            return Db.SaveChanges()>0;
        }
    }
}
