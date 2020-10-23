using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            MouseDown += WindowBase_MouseDown;  
        }

        private void WindowBase_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //注意，要判断是否是左键，因为只有左键能触发下面的移动
            //按下其他键无法触发，会报错
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                (sender as Window).DragMove();
            }
        }
    }
}
