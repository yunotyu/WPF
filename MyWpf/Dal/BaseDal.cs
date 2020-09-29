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
        public static ConnectStr Db = new ConnectStr();

        public List<T> Query()
        {
           return Db.Set<T>().Where((t) =>true).ToList();
        }
    }
}
