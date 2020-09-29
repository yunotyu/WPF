using MyWpf.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.Service
{
    public class User_MenuService
    {
        User_MenuDal dal = new User_MenuDal();
        
        public List<int> QueryMenuById(int userId)
        {
            return dal.QueryMenuId(userId);
        }
    }
}
