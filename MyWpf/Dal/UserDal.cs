using MyWpf.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.Dal
{
    public class UserDal:BaseDal<user>
    {
        public user QueryById(int id)
        {
            return Db.user.Where(u => u.id == id).FirstOrDefault();
        }

        public user QueryByNameAndPwd(string name,string pwd)
        {
            return Db.user.Where(u => u.name == name && u.pwd == pwd).FirstOrDefault();
        }
    }
}
