using MyWpf.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.Dal
{
    public class User_MenuDal:BaseDal<user_menu>
    {
        public List<int> QueryMenuId(int userId)
        {
           return Db.user_menu.Where(um => um.userId == userId).Select(um=>um.menuId).ToList();
        }
    }
}
