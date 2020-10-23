using MyWpf.Dal;
using MyWpf.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.Service
{
   public class StoreService:BaseService<Store>
    {
        public StoreService()
        {
            Dal = new StoreDal();
        }
    }
}
