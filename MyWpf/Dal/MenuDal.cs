using MyWpf.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.Dal
{
    public class MenuDal:BaseDal<menus>
    {
        public List<menus> QueryByIds(List<int> ids)
        {
            return Db.menus.Where(m => ids.Contains(m.id)).ToList();
        }
    }
}
