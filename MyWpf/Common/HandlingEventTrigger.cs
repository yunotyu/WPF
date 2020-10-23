using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyWpf.Common
{
    /// <summary>
    /// 自定义的interactivity触发的事件处理
    /// </summary>
    public class HandlingEventTrigger:System.Windows.Interactivity.EventTrigger
    {
        protected override void OnEvent(EventArgs eventArgs)
        {
            //是否是路由事件参数,如果是路由事件会传递
            var routedEventArgs = eventArgs as RoutedEventArgs;
            if (routedEventArgs != null)
            {
                routedEventArgs.Handled = true;//标记为已处理
            }
            base.OnEvent(eventArgs);
        }
    }
}
