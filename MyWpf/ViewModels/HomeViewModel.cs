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
using System.Windows.Controls;

namespace MyWpf.ViewModels
{
    public class HomeViewModel: ViewModelBase
    {
        public List<menus> Menus { get; set; }
        public MenuService MenuService { get; set; }

       

        /// <summary>
        /// 存放各视图的集合
        /// </summary>
        public ObservableCollection<Module> Modules { get; set; }


        private Home home;

        /// <summary>
        /// 记录当前的主窗体对象
        /// </summary>
        public Home Home
        {
            get { return home; }
            set
            {
                home = value;
                this.RaisePropertyChanged("Home");
            }
        }


        private user user;

        public user User
        {
            get { return user; }
            set
            {
                user = value;
                this.RaisePropertyChanged("User");
            }
        }

        /// <summary>
        /// 最大化，正常化的代号
        /// </summary>
        private PackIconKind maxNormalKind;

        public PackIconKind MaxNormalKind
        {
            get { return maxNormalKind; }
            set
            {
                maxNormalKind = value;
                this.RaisePropertyChanged("MaxNormalKind");
            }
        }


     

        private DelegateCommand maxNormalCommand;

        public DelegateCommand MaxNormalCommand
        {
            get { return maxNormalCommand; }
            set
            {
                maxNormalCommand = value;
                this.RaisePropertyChanged("MaxNormalCommand");
            }
        }

        private DelegateCommand minCommand;

        public DelegateCommand MinCommand
        {
            get { return minCommand; }
            set
            {
                minCommand = value;
                this.RaisePropertyChanged("MinCommand");
            }
        }


        public DelegateCommand SelectChangedCommand
        {
            get;
            set;
        }


        public HomeViewModel()
        {
            maxNormalKind = PackIconKind.WindowMaximize;//显示最大化按钮
          
            moveCommand.ExcuteAction = new Action<object>((o) =>
            {
                var win = o as Window;
                win.DragMove();
            });

            closeCommand.ExcuteAction = new Action<object>(o =>
            {
                Application.Current.Shutdown();
            });

            minCommand = new DelegateCommand();
            maxNormalCommand = new DelegateCommand();

            //最小化窗体
            minCommand.ExcuteAction = new Action<object>(o =>
              {
                  Home home = o as Home;
                  home.WindowState = WindowState.Minimized;
              });

            //最大化正常化窗体
            maxNormalCommand.ExcuteAction = new Action<object>(o =>
            {
                Home home = o as Home;
                if(home.WindowState== WindowState.Maximized)
                {
                    home.WindowState = WindowState.Normal;
                    var vm = home.DataContext as HomeViewModel;
                    MaxNormalKind = PackIconKind.WindowMaximize;//显示最大化按钮
                }
                else if(home.WindowState == WindowState.Normal)
                {
                    home.WindowState = WindowState.Maximized;
                    var vm= home.DataContext as HomeViewModel;
                    MaxNormalKind = PackIconKind.WindowRestore;//正常尺寸化窗体按钮
                }
            });


            //菜单选择项改变时，触发的命令
            SelectChangedCommand = new DelegateCommand();
            SelectChangedCommand.ExcuteAction = new Action<object>(o =>
              {
                  List<object> li = new List<object>();
                  li = o as List<object>;
                  Home win = li[0] as Home;
                  home = win;//记录当前主窗体对象，在传递到其他页面时，可以使用
                  int index = (int)li[1];
                  if (win != null)
                  {
                     win.mainContent.Content = Modules[index];
                  }
              });

            //获取用户对应权限菜单
            Menus = new List<menus>();
            MenuService = new MenuService();
            Modules = new ObservableCollection<Module>();
            Menus = MenuService.QueryByIds(AppCache.Ids);
            Menus.ForEach(m =>
            {
                Modules.Add(new Module
                {
                    MenuName = m.menuName,
                    IconCode = m.menuName,
                    Content = (GetView(m.menuName) as UserControl).Content
                });
            });
            user = AppCache.CurUser;
        }

        /// <summary>
        /// 对应的菜单名，返回对应的视图对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object GetView(string name)
        {
            switch (name)
            {
                case "用户信息":
                    {
                        return new Skin();
                    }
                case "用户管理":
                    {
                        return new Users();
                    }
                case "权限管理":
                    {
                        return new Skin();
                    }
                case "皮肤":
                    {
                        return new Skin();
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
