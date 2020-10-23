using MyWpf.Commands;
using MyWpf.Common;
using MyWpf.EF.Models;
using MyWpf.Service;
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
    public class LoginViewModel : ViewModelBase //这个是Prism.Wpf里的类,用于属性修改消息通知
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

        private List<string> userNames;

        public List<string> UserNames
        {
            get { return userNames; }
            set
            {
                userNames = value;
                this.RaisePropertyChanged("UserNames");
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

        private DelegateCommand loadNameAndPwdCommand;

        /// <summary>
        /// 加载时，显示登录过的账号和记录的密码
        /// </summary>
        public DelegateCommand LoadNameAndPwdCommand
        {
            get { return loadNameAndPwdCommand; }
            set
            {
                loadNameAndPwdCommand = value;
                this.RaisePropertyChanged("LoadNameAndPwdCommand");
            }
        }

        private DelegateCommand selectChangeCommand;
        
        public DelegateCommand SelectChangeCommand
        {
            get { return selectChangeCommand; }
            set
            {
                selectChangeCommand = value;
                this.RaisePropertyChanged("SelectChangeCommand");
            }
        }


        public LoginViewModel()
        {
            UserService = new UserService();
            User_MenuService = new User_MenuService();
            userNames = new List<string>();

            loginCommand = new DelegateCommand();
            loginCommand.ExcuteAction = new Action<object>(Login);

            //moveCommand.ExcuteAction = new Action<object>((o) => 
            //{
            //    var win = o as Window;
            //    win.DragMove();
            //});

            closeCommand.ExcuteAction = new Action<object>(o =>
              {
                  Application.Current.Shutdown();
              });

            loadNameAndPwdCommand = new DelegateCommand();
            //加载用户名列表和加载上次登录用户的密码
            loadNameAndPwdCommand.ExcuteAction = new Action<object>(o =>
              {
                  var config = JsonHelper.ReadJsonFileToStr<Configs>(AppDomain.CurrentDomain.BaseDirectory + @"config/configs.json");
                  if (config != null)
                  {
                      if (config.UserConfig.Count > 0)
                      {
                          UserName = config.UserConfig[0].UserName;
                          config.UserConfig.ForEach(u =>
                          {
                              //添加到用户名列表
                              UserNames.Add(u.UserName);
                          });
                          if (!string.IsNullOrEmpty(config.UserConfig[0].Token))
                          {
                              //根据用户名和token获取密码
                              Pwd=UserService.GetPwdByTokenAndName(UserName, config.UserConfig[0].Token);
                          }
                      }
                  }
              });

            //选择项改变
            selectChangeCommand = new DelegateCommand();
            selectChangeCommand.ExcuteAction = new Action<object>(o =>
              {
                  var combox = o as ComboBox;

                  var config = JsonHelper.ReadJsonFileToStr<Configs>(AppDomain.CurrentDomain.BaseDirectory + @"config/configs.json");
                  foreach (var item in config.UserConfig)
                  {
                      if (item.UserName == combox.SelectedItem as string)
                      {
                          if (!string.IsNullOrEmpty(item.Token))
                          {
                              //根据用户名和token获取密码
                              Pwd = UserService.GetPwdByTokenAndName(item.UserName, item.Token);
                              return;
                          }
                      }
                  }
                  Pwd = "";
              });

        }

        //登录
        public void Login(object param)
        {
            var user = UserService.QueryByNameAndPwd(userName, pwd);

            Login loginWindow = param as Login;

            if (user != null)
            {
                AppCache.CurUser = user;
                AppCache.Ids = User_MenuService.QueryMenuById(user.Id);
                Home home = new Home();
                home.Show();
                loginWindow.Close();
            }
            else
            {
                ShowTip("账户或密码错误");
                return;
            }

            //先登录成功，再进行记录
            CheckRemeberPwd((bool)loginWindow.rememberPwd.IsChecked);
            loginWindow = null;

        }

        /// <summary>
        /// 是否勾选记住密码
        /// </summary>
        /// <param name="isCheck"></param>
        private void CheckRemeberPwd(bool isCheck)
        {
            //勾选记住密码
            if (isCheck)
            {
                #region 读取json文件，获取密码
                // 随机token
                var token = Guid.NewGuid().ToString() + new Random().Next(0, 100000).ToString();
                GetAndSetConfig(token);
                #endregion
            }
            else//未勾选记住密码
            {
                GetAndSetConfig();//没有勾选，不传入token
            }
        }

        /// <summary>
        /// 获取和设置配置文件
        /// </summary>
        private void GetAndSetConfig(string token="")
        {
            bool isContain = false;
            UserConfig userConfig = new UserConfig();

            //获取json文件内容
            string path = AppDomain.CurrentDomain.BaseDirectory + @"/config/configs.json";
            Configs config = JsonHelper.ReadJsonFileToStr<Configs>(path);

            if (config != null)
            {
                foreach (var item in config.UserConfig)
                {
                    if (item.UserName == userName)
                    {
                        userConfig = item;
                        //包含这个用户
                        isContain = true;
                        item.Token = token;
                    }
                }
                if (isContain)
                {
                    //放到第一个位置
                    config.UserConfig.Remove(userConfig);
                    config.UserConfig.Insert(0, userConfig);
                }
            }
            else
            {
                config = new Configs();
            }

            //不包含，添加
            if (!isContain)
            {
                config.UserConfig.Insert(0, new UserConfig { UserName = userName, Token = token });
            }

            //保存信息到配置文件
            JsonHelper.SaveToJson<Configs>(path, config);

            //更新当前用户的token到数据库
            UserService.ModifyToken(userName, token);
        }
    }
}
