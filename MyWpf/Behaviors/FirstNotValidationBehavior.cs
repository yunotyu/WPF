using MyWpf.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;

namespace MyWpf.Behaviors
{
    /// <summary>
    /// 让控件第一次打开时，不进行验证的行为
    /// </summary>
    public class FirstNotValidationBehavior:Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
            AssociatedObject.LostFocus += AssociatedObject_LostFocus;
        }

        private void AssociatedObject_LostFocus(object sender, RoutedEventArgs e)
        {
            //重新绑定文本框的失去焦点事件后，第一次进来后，就删除这个自定义的事件
            AssociatedObject.LostFocus -= AssociatedObject_LostFocus;

            bool isPasswordBox = AssociatedObject.GetType() == typeof(PasswordBox);

            //第一次进来后，下面才绑定验证器,这样第一次看到控件就不会触发验证

            BindingExpression bindingExpression = null;

            //如果不是密码框
            if (!isPasswordBox)
            {
                //获取绑定在textbox的text属性上的binding表达式
                bindingExpression = AssociatedObject.GetBindingExpression(TextBox.TextProperty);
                if (bindingExpression == null)
                {
                    //没有绑定
                    return;
                }
            }
            else
            {
                //获取绑定在passwordbox的附加属性上的binding表达式
                bindingExpression = AssociatedObject.GetBindingExpression(PasswordBoxHelper.PasswordProperty);
                if (bindingExpression == null)
                {
                    //没有绑定
                    return;
                }
            }
         

            //获取这个binding表达式的binding对象
            Binding bindingParent = bindingExpression.ParentBinding;

            //创建一个新的binding对象,注意这里Mode和UpdateSourceTrigger等全部值都要重新设定
            //因为这是一个新的对象
            Binding newBinding = new Binding(bindingParent.Path.Path);
            //启用验证器
            newBinding.ValidatesOnDataErrors = true;
            newBinding.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;
            newBinding.Mode = BindingMode.TwoWay;

            //如果是密码框
            if(AssociatedObject.GetType() ==typeof(PasswordBox))
            {
                //为附加属性绑定新的绑定
                AssociatedObject.SetBinding(PasswordBoxHelper.PasswordProperty, newBinding);
            }
            else//如果是文本框
            {
                AssociatedObject.SetBinding(TextBox.TextProperty, newBinding);
            }
        }


        protected override void OnDetaching()
        {
            base.OnDetaching();
        }
    }
}
