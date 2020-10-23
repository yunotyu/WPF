using LiveCharts;
using LiveCharts.Wpf;
using MaterialDesignThemes.Wpf;
using MyWpf.Commands;
using MyWpf.Common;
using MyWpf.EF;
using MyWpf.EF.Models;
using MyWpf.Service;
using MyWpf.Views;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace MyWpf.ViewModels
{
    public class HomeViewModel: ViewModelBase
    {
        public List<MyWpf.EF.Models.Menu> Menus { get; set; }
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


        private User user;

        public User User
        {
            get { return user; }
            set
            {
                user = value;
                this.RaisePropertyChanged("User");
            }
        }

        private string currentTime;

        public string CurrentTime
        {
            get { return currentTime; }
            set
            {
                currentTime = value;
                this.RaisePropertyChanged("CurrentTime");
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

        private DelegateCommand editLoginUserCommand;

        public DelegateCommand EditLoginUserCommand
        {
            get { return editLoginUserCommand; }
            set
            {
                editLoginUserCommand = value;
                this.RaisePropertyChanged("EditLoginUserCommand");
            }
        }

      

        private DelegateCommand logOutCommand;

        public DelegateCommand LogOutCommand
        {
            get { return logOutCommand; }
            set
            {
                logOutCommand = value;
                this.RaisePropertyChanged("LogOutCommand");
            }
        }


        public HomeViewModel()
        {
            CurrentTime = DateTime.Now.ToLongTimeString();
            maxNormalKind = PackIconKind.WindowMaximize;//显示最大化按钮
          
            //moveCommand.ExcuteAction = new Action<object>((o) =>
            //{
            //    var win = o as Window;
            //    win.DragMove();
            //});

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
                  (win.DataContext as HomeViewModel).User.IsEditLogingUser = false;
                  home = win;//记录当前主窗体对象，在传递到其他页面时，可以使用
                  int index = (int)li[1];
                  if (win != null)
                  {
                      //var newModule = GetNewInstance(Modules[index]);
                      win.mainContent.Content = Modules[index].Content;
                      GC.Collect();
                  }
              });

            //编辑登录用户
            editLoginUserCommand = new DelegateCommand();
            editLoginUserCommand.ExcuteAction = new Action<object>(o =>
              {
                  var home = o as Home;
                  EditLoginingUser editLoginingUser = new EditLoginingUser();
                  var u =new UserService().QueryById((home.DataContext as HomeViewModel).User.Id);
                  (home.DataContext as HomeViewModel).User = u;
                  u.IsEditLogingUser = true;
                  u.ConfirmPwd = u.Pwd;//第一次打开，让相等
                  home.mainContent.Content =editLoginingUser.Content;
              });

            //注销
            logOutCommand = new DelegateCommand();
            logOutCommand.ExcuteAction = new Action<object>(o =>
              {
                  Window window = GetEleTopParent(o as FrameworkElement) as Window;
                  Login login = new Login();
                  login.Show();
                  window.Close();
                  home = null;
                  Modules = null;
                  window = null;
                  GC.Collect();
              });

            //获取用户对应权限菜单
            Menus = new List<MyWpf.EF.Models.Menu>();
            MenuService = new MenuService();
            Modules = new ObservableCollection<Module>();
            Menus = MenuService.QueryByIds(AppCache.Ids);
            Menus.ForEach(m =>
            {
                Modules.Add(new Module
                {
                    MenuName = m.MenuName,
                    IconCode = m.MenuName,
                    Content = (GetView(m.MenuName) as UserControl).Content
                });
            });
            user = AppCache.CurUser;

        }

        //窗体加载
        public void WindowLoaded(object sender, RoutedEventArgs e)
        {
            Home home = sender as Home;
            home.mainContent.Content = new Main().Content;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick+=new EventHandler(new Action<object,EventArgs>((sen,eve)=> 
            {
                (home.DataContext as HomeViewModel).CurrentTime = DateTime.Now.ToLongTimeString();
            }));
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
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
                case "主页":
                    {
                        return new Main();
                    }
                case "用户管理":
                    {
                        return new Users();
                    }
                case "权限管理":
                    {
                        return new EidtPermiss();
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

        private UserControl GetNewInstance(Module userControl)
        {
            var name = userControl.MenuName;
            switch (name)
            {
                case "主页":
                    {
                        return new Main();
                    }
                case "用户管理":
                    {
                        return new Users();
                    }
                case "权限管理":
                    {
                        return new EidtPermiss();
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
