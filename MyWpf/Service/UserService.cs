using MyWpf.Dal;
using MyWpf.EF;
using MyWpf.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.Service
{
    public class UserService:BaseService<User>
    {
        public UserService()
        {
            Dal = new UserDal();
        }

        public User QueryById(int id)
        {
            return (Dal as UserDal).QueryById(id);
        }

        public User QueryByNameAndPwd(string name, string pwd)
        {
            return (Dal as UserDal).QueryByNameAndPwd(name, pwd);
        }

        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="curPage"></param>
        /// <param name="perPageItem"></param>
        /// <returns></returns>
        public IQueryable<User> GetPage(int curPage, int perPageItem)
        {
            return Dal.GetPage().OrderBy(u=>u.Id).Skip((curPage-1)* perPageItem).Take(perPageItem);
        }

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="name"></param>
        /// <param name="curPage"></param>
        /// <param name="perPageItem"></param>
        /// <returns></returns>
        public List<User> GetPageByName(string name, int curPage, int perPageItem)
        {
            return (Dal as UserDal).GetPageByName(name,curPage,perPageItem);
        }

        public int QueryByName(string name)
        {
            return (Dal as UserDal).QueryByName(name);
        }

        public bool ModifyToken(string userName, string token)
        {
            return (Dal as UserDal).ModifyToken(userName, token);
        }

        public string GetPwdByTokenAndName(string name, string token)
        {
            return (Dal as UserDal).GetPwdByTokenAndName(name, token);
        }
    }

}
