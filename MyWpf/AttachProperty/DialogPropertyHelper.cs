using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyWpf.AttachProperty
{
    public static class DialogPropertyHelper
    {


        public static bool GetIsCloseParent(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsCloseParentProperty);
        }

        public static void SetIsCloseParent(DependencyObject obj, bool value)
        {
            obj.SetValue(IsCloseParentProperty, value);
        }

        /// <summary>
        /// 关闭子窗体时，是否关闭父窗体的附加属性
        /// </summary>
        public static readonly DependencyProperty IsCloseParentProperty =
            DependencyProperty.RegisterAttached("IsCloseParent", typeof(bool), typeof(FrameworkElement), new PropertyMetadata(false));


    }
}
