using MyWpf.EF;
using MyWpf.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf
{
    /// <summary>
    /// 全局信息
    /// </summary>
    internal class AppCache
    {
        /// <summary>
        /// 当前登录的用户信息
        /// </summary>
        public static User CurUser;

        /// <summary>
        /// 菜单id集合
        /// </summary>
        public static List<int> Ids;

        static  AppCache()
        {
            CurUser = new User();
            Ids = new List<int>();
        }
    }
}
