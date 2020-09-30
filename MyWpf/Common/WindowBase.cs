using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyWpf.Common
{
    /// <summary>
    /// 窗体基类
    /// </summary>
   public class WindowBase:Window
    {
        public WindowBase()
        {
            WindowStyle = WindowStyle.None;
            MouseDown += WindowBase_MouseDown;  
        }

        private void WindowBase_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
