using MyWpf.EF;
using MyWpf.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.Dal
{
    public class User_MenuDal:BaseDal<User_Menu>
    {
        public List<int> QueryMenuId(int userId)
        {
           return Db.User_Menu.Where(um => um.UserId == userId).Select(um=>um.MenuId).ToList();
        }

        public bool Modify(int uId,List<int>mIds)
        {
            Db.User_Menu.RemoveRange(Db.User_Menu.Where(um => um.UserId==uId));
            foreach (var item in mIds)
            {
                Db.User_Menu.Add(new User_Menu { UserId = uId, MenuId = item });
            }
            return Db.SaveChanges()>0;
        }
    }
}
