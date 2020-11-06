using MaterialDesignColors;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MyWpf
{
    /// <summary>
    /// 菜单栏的子项
    /// </summary>
    public class Module:UserControl
    {
        private string iconCode;
        public string MenuName { get; set; }

        /// <summary>
        /// MD的图标代号
        /// </summary>
        public string IconCode {
            get { return this.iconCode; }
            set 
            {
                switch (value)
                {
                    case "主页":
                        {
                            iconCode = "../../Image/home.png";
                            break;
                        }
                    case "用户管理":
                        {
                            iconCode = "../../Image/users.png";
                            break;
                        }
                    case "权限管理":
                        {
                            iconCode = "../../Image/permiss.png";
                            break;
                        }
                    case "皮肤":
                        {
                            iconCode = "../../Image/theme.png";
                            break;
                        }
                }
            } 
        }

    }   
}
