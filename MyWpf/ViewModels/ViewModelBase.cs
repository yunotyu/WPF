using MyWpf.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.ViewModels
{
    public class ViewModelBase : BindableBase
    {
        protected DelegateCommand moveCommand;

        /// <summary>
        /// 窗体移动
        /// </summary>
        public DelegateCommand MoveCommand
        {
            get { return moveCommand; }
            set
            {
                moveCommand = value;
                this.RaisePropertyChanged("MoveCommand");
            }
        }

        protected DelegateCommand closeCommand;

        public DelegateCommand CloseCommand
        {
            get { return closeCommand; }
            set
            {
                closeCommand = value;
                this.RaisePropertyChanged("CloseCommand");
            }
        }

        public ViewModelBase()
        {
            moveCommand = new DelegateCommand();
            closeCommand = new DelegateCommand();
        }
    }
}
