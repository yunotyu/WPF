using MyWpf.EF;
using MyWpf.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.Dal
{
    public class UserDal:BaseDal<User>
    {
        public User QueryById(int id)
        {
            return Db.User.AsNoTracking().Where(u => u.Id == id).FirstOrDefault();
        }

        public User QueryByNameAndPwd(string name,string pwd)
        {
            return Db.User.AsNoTracking().Where(u => u.Name == name && u.Pwd == pwd).FirstOrDefault();
        }

        /// <summary>
        /// 修改token
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool ModifyToken(string userName,string token)
        {
            //以EF不跟踪状态获取对象
            var user= Db.User.AsNoTracking().Where(u => u.Name == userName).FirstOrDefault();
            user.Token = token;

            //判断该实体是否EF里的未跟踪状态
            if (Db.Entry<User>(user).State == System.Data.Entity.EntityState.Detached)
            {
                //获取DbContext的对象上下文
                ObjectContext objectContext = ((IObjectContextAdapter)Db).ObjectContext;

                //获取一个DbSet对象，用于操作该表
                ObjectSet<User> entitySet = objectContext.CreateObjectSet<User>();

                //获取当前要到数据库修改的对象的标识
                EntityKey entityKey = objectContext.CreateEntityKey(entitySet.EntitySet.Name, user);

                //检查EF是否有跟这个主键相同的对象
                object foundSet;
                bool exists = objectContext.TryGetObjectByKey(entityKey, out foundSet);

                //如果有，移除这个对象
                if (exists)
                {
                    objectContext.Detach(foundSet); //从上下文中移除
                }
            }
            //将新的对象添加进行
            Db.User.Attach(user);
            Db.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;
            return Db.SaveChanges()>0;

        }

        /// <summary>
        /// 获取密码通过token和用户名
        /// </summary>
        /// <returns></returns>
        public string GetPwdByTokenAndName(string name, string token)
        {
            var us = Db.User.AsNoTracking().Where(u => u.Name == name && u.Token == token);
            if (us.Count()>0)
            {
                return us.FirstOrDefault().Pwd;
            }
            return "";
        }

        public int QueryByName(string name)
        {
            return Db.User.AsNoTracking().Where(u => u.Name.Contains(name)).Count();
        }

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="name"></param>
        /// <param name="curPage"></param>
        /// <param name="perPageItem"></param>
        /// <param name="perPageItem"></param>
        /// <returns></returns>
        public List<User> GetPageByName(string name,int curPage,int perPageItem)
        {
            return Db.User.AsNoTracking().Where(u => u.Name.Contains(name)).OrderBy(u => u.Id).Skip((curPage - 1) * perPageItem).Take(perPageItem).ToList(); 
        }   
    }
}
