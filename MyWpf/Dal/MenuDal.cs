using MyWpf.EF;
using MyWpf.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.Dal
{
    public class MenuDal:BaseDal<Menu>
    {
        public List<Menu> QueryByIds(List<int> ids)
        {
            return Db.Menu.Where(m => ids.Contains(m.Id)).ToList();
        }
    }
}
