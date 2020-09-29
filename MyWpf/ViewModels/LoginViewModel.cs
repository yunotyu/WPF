using MyWpf.Commands;
using MyWpf.Service;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyWpf.ViewModels
{
    public class LoginViewModel:BindableBase //这个是Prism.Wpf里的类,用于属性修改消息通知
    {
        public UserService UserService { get; set; }
        public User_MenuService User_MenuService { get; set; }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                //prism里面的方法，通知前端，属性值发生修改
                this.RaisePropertyChanged("UserName");
            }
        }

        private string pwd;

        public string Pwd
        {
            get { return pwd; }
            set
            {
                pwd = value;
                this.RaisePropertyChanged("Pwd");
            }
        }


        private DelegateCommand loginCommand;

        /// <summary>
        /// 登录命令
        /// </summary>
        public DelegateCommand LoginCommand
        {
            get { return loginCommand; }
            set 
            {
                loginCommand = value;
                this.RaisePropertyChanged("LoginCommand");
            }
        }

        private DelegateCommand moveCommand;

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

        private DelegateCommand closeCommand;

        public DelegateCommand CloseCommand
        {
            get { return closeCommand; }
            set
            {
                closeCommand = value;
                this.RaisePropertyChanged("CloseCommand");
            }
        }


        public LoginViewModel()
        {
            UserService = new UserService();
            User_MenuService = new User_MenuService();

            loginCommand = new DelegateCommand();
            loginCommand.ExcuteAction = new Action<object>(Login);

            moveCommand = new DelegateCommand();
            moveCommand.ExcuteAction = new Action<object>((o) => 
            {
                var win = o as Window;
                win.DragMove();
            });

            closeCommand = new DelegateCommand();
            closeCommand.ExcuteAction=new Action<object>(o=>
            {
                Application.Current.Shutdown();
            });
        }

        public void Login(object param)
        {
            var user = UserService.QueryByNameAndPwd(userName, pwd);

            Login loginWindow = param as Login;

            if (user != null)
            {
                AppCache.CurUser = user;
                AppCache.Ids = User_MenuService.QueryMenuById(user.id);
                Home home = new Home();
                home.Show();
                loginWindow.Hide();
            }
            else
            {
                MessageBox.Show("密码或账号错误!");
            }
        }
    }   
}
