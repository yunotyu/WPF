using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyWpf.Commands
{
    /// <summary>
    /// 命令的基类
    /// </summary>
    public class DelegateCommand : ICommand
    {   
        /// <summary>
        /// 发生命令时执行的委托
        /// </summary>
        public Action<object> ExcuteAction { get; set; }    

        /// <summary>
        /// 确定该命令是否能执行
        /// </summary>
        public Func<object,bool> CanExcuteFunc { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (CanExcuteFunc == null)//忽略，一直可以执行
            {
                return true; 
            }
            return CanExcuteFunc(parameter);
        }

        /// <summary>
        /// 发生命令时执行的方法
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
           ExcuteAction(parameter);
        }
    }
}
