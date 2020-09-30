using MaterialDesignThemes.Wpf;
using MyWpf.Commands;
using MyWpf.EF;
using MyWpf.Service;
using MyWpf.Views;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyWpf.ViewModels
{
    public class UsersViewModel:ViewModelBase
    {
        public UserService  UserService { get; set; }
        private ObservableCollection<user> users;   

        public ObservableCollection<user> Users
        {
            get { return users; }
            set
            {
                users = value;
                this.RaisePropertyChanged("Users");
            }
        }

        private DelegateCommand addUserCommand;

        public DelegateCommand AddUserCommand
        {
            get { return addUserCommand; }
            set
            {
                addUserCommand = value;
                this.RaisePropertyChanged("AddUserCommand");
            }
        }


        public UsersViewModel()
        {
            users = new ObservableCollection<user>();
            UserService = new UserService();
            var list = UserService.Query();
            list.ForEach(u =>
            {
                u.IsSelected = false;
                users.Add(u);
            }
            );

            //添加用户
            addUserCommand = new DelegateCommand();
            addUserCommand.ExcuteAction = new Action<object>(o =>
              {
                  //使用{Binding} 获取到的是HomeViewModel
                  var vm = o as HomeViewModel;
                  var add = new AddUser();
                  //设置当前窗体的父窗体
                  add.Owner = vm.Home;
                  add.ShowDialog();
              });

            closeCommand.ExcuteAction = new Action<object>(o =>
              {
                  Window win = o as Window;
                  win.Close();
                  win = null;
              });

            moveCommand.ExcuteAction = new Action<object>(o =>
              {
                  (o as Window).DragMove();
              });
        }

    }
}
