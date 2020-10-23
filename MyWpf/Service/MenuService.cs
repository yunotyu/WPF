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
    public class MenuService:BaseService<Menu>
    {
        public MenuService()
        {
            Dal = new MenuDal();
        }

        public List<Menu> QueryByIds(List<int> ids)
        {
            return (Dal as MenuDal).QueryByIds(ids);
        }
    }
}
