using MyWpf.Dal;
using MyWpf.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.Service
{
    public class BaseService<T>where T:class
    {
        protected BaseDal<T> Dal { get; set; }


        public List<T> Query()
        {
            return Dal.Query() ;
        }

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <returns></returns>
        public int GetAllItemCount()
        {
            return Dal.GetAllItemCount();
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="model"></param>
        public bool Modify(T model)
        {
            return Dal.Modify(model);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(T model)
        {
            return Dal.Add(model);
        }

        public bool Del(T model)
        {
            return Dal.Del(model);
        }
    }
}
