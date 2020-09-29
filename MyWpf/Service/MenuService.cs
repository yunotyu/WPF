using MyWpf.Dal;
using MyWpf.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.Service
{
    public class MenuService
    {
        MenuDal dal = new MenuDal();

        public List<menus> QueryByIds(List<int> ids)
        {
            return dal.QueryByIds(ids);
        }
    }
}
