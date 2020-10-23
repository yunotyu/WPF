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
    public class User_MenuService:BaseService<User_Menu>
    {

        public User_MenuService()
        {
            Dal = new User_MenuDal();
        }

        public List<int> QueryMenuById(int userId)
        {
            return (Dal as User_MenuDal).QueryMenuId(userId);
        }

        public bool Modify(int uId, List<int> mIds)
        {
            return (Dal as User_MenuDal).Modify(uId, mIds);
        }

    }
}
