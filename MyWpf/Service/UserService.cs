using MyWpf.Dal;
using MyWpf.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.Service
{
    public class UserService
    {
        UserDal dal = new UserDal();

        public user QueryById(int id)
        {
            return dal.QueryById(id);
        }

        public List<user> Query()
        {
            return dal.Query();
        }

        public user QueryByNameAndPwd(string name, string pwd)
        {
            return dal.QueryByNameAndPwd(name, pwd);
        }
    }

}
