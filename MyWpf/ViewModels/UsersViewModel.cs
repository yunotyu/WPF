using MaterialDesignThemes.Wpf;
using MyWpf.Commands;
using MyWpf.Common;
using MyWpf.EF;
using MyWpf.EF.Models;
using MyWpf.Service;
using MyWpf.Validation;
using MyWpf.Views;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace MyWpf.ViewModels
{
    public class UsersViewModel:ViewModelBase
    {
        public UserService  UserService { get; set; }

        private ObservableCollection<User> users;

        /// <summary>
        /// 是否按条件查询分页
        /// </summary>
        private bool isQuery = false;

        public ObservableCollection<User> Users
        {
            get { return users; }
            set
            {
                users = value;
                this.RaisePropertyChanged("Users");
            }
        }

        private PageHelper<User> page;

        /// <summary>
        /// 分页
        /// </summary>
        public PageHelper<User> Page
        {
            get { return page; }
            set
            {
                Page = value;
                this.RaisePropertyChanged("Page");
            }
        }

        private DelegateCommand addUserDiaCommand;

        public DelegateCommand AddUserDiaCommand
        {
            get { return addUserDiaCommand; }
            set
            {
                addUserDiaCommand = value;
                this.RaisePropertyChanged("AddUserDiaCommand");
            }
        }

        private DelegateCommand saveEditCommand;
        /// <summary>
        /// 保存修改的用户信息
        /// </summary>
        public DelegateCommand SaveEditCommand
        {
            get { return saveEditCommand; }
            set
            {
                saveEditCommand = value;
                this.RaisePropertyChanged("SaveEditCommand");
            }
        }

        private DelegateCommand addUserCommand;
        /// <summary>
        /// 添加用户
        /// </summary>
        public DelegateCommand AddUserCommand
        {
            get { return addUserCommand; }
            set
            {
                addUserCommand = value;
                this.RaisePropertyChanged("AddUserCommand");
            }
        }

        private DelegateCommand updatePerPageItemCommand;

        /// <summary>
        /// 更新每页条数
        /// </summary>
        public DelegateCommand UpdatePerPageItemCommand
        {
            get { return updatePerPageItemCommand; }
            set
            {
                updatePerPageItemCommand = value;
                this.RaisePropertyChanged("UpdatePerPageItemCommand");
            }
        }


        private string searchText;
        
        /// <summary>
        /// 查询文本
        /// </summary>
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                this.RaisePropertyChanged("SearchText");
            }
        }


        public UsersViewModel()
        {
            users = new ObservableCollection<User>();
            UserService = new UserService();
            EditUserData = new User() ;
            AddUserData = new User();

            //分页数据
            page = new PageHelper<User>();

            //获取总页数和总记录数
            page.AllItemCount = UserService.GetAllItemCount();
            page.GetAllPageCount();

            //获取页面数据
            UserService.GetPage(page.CurPage, page.PerPageItem).ToList().ForEach(i=> {
                page.Items.Add(i);
            });

            var list = UserService.Query();
            list.ForEach(u =>
            {
                u.IsSelected = false;
                users.Add(u);
            }
            );

            //添加用户
            addUserDiaCommand = new DelegateCommand();
            addUserDiaCommand.ExcuteAction = new Action<object>(o =>
              {
                  List<object> objs = o as List<object>;
                  //使用{Binding} 获取到的是HomeViewModel
                  var vm = objs[0] as HomeViewModel;
                  var add = new AddUser();
                  var data = add.DataContext as UsersViewModel;
                  data.page = objs[1] as PageHelper<User>;
                  //设置当前窗体的父窗体
                  add.Owner = vm.Home;
                  add.ShowDialog();
              });

            closeCommand.ExcuteAction = new Action<object>(o =>
              {
                  Window win = o as Window;
                  win.Close();
                  FlushMemory.Flush();
              });

            //moveCommand.ExcuteAction = new Action<object>(o =>
            //  {
            //      (o as Window).DragMove();
            //  });
            
            //跳转到第几页
            gotoCommand.ExcuteAction = new Action<object>(o =>
              {
                  string gotoPage = o as string;
                  if (gotoPage != null)
                  {
                      int index = 1;
                      int.TryParse(gotoPage,out index);
                      if(index > page.AllPageCount)
                      {
                          index = page.AllPageCount;
                      }
                      UpdateDataGrid(searchText);
                  }
              });
           
            //首页
            firstCommand.ExcuteAction=new Action<object>(o =>{
                page.CurPage = 1;
                UpdateDataGrid(searchText);
            });

            //尾页
            lastCommand.ExcuteAction = new Action<object>(o =>
              {
                  page.CurPage = page.AllPageCount;
                  UpdateDataGrid(searchText);
              });

            //下一页
            nextCommand.ExcuteAction = new Action<object>(o =>
              {
                  if ((page.CurPage += 1) > page.AllPageCount)
                  {
                      page.CurPage = page.AllPageCount;
                  }
                  UpdateDataGrid(searchText);
              });

            //上一页
            prevCommand.ExcuteAction = new Action<object>(o =>
              {
                  if ((page.CurPage -= 1) < 1)
                  {
                      page.CurPage = 1;
                  }
                  UpdateDataGrid(searchText);
              });

            //双击
            dataGirdDouClickCommand.ExcuteAction = new Action<object>(o =>
              {
                 List<object> items=o as List<object>;
                  if (list != null)
                  {
                      //获取选中行的数据
                      var selectItem = items[0] as User;
                      var home = items[1] as HomeViewModel;
                      EditUser editUser = new EditUser();
                      //重新查询，防止在编辑过程中，表格的数据跟着改变
                      (editUser.DataContext as UsersViewModel).EditUserData = UserService.QueryById(selectItem.Id);
                      editUser.Owner = home.Home;
                      editUser.ShowDialog();
                  }
              });

            //保存修改
            saveEditCommand = new DelegateCommand();
            saveEditCommand.ExcuteAction = new Action<object>(o =>
              {
                  editUserData.IsEdit = true;
                  //保存前，再验证全部属性是否通过
                  var dic = ValidationHelper.ValidationObject(editUserData);
                  if (dic.Count > 0)
                  {
                      ShowTip("请输入正确的信息", o as Window);
                      return;
                  }
                  if (UserService.Modify(editUserData))
                  {
                      UpdateDataGrid();
                      ShowTip("修改成功", o as EditUser);
                      page.Items.Clear();
                      //添加成功，关闭窗体
                      CloseDialog(o as Window);
                  }
                  else
                  {
                      ShowTip("修改失败", o as EditUser);
                  }
              });

            //新增用户
            addUserCommand = new DelegateCommand();
            addUserCommand.ExcuteAction = new Action<object>(o =>
              {
                  //保存前，再验证全部属性是否通过
                  var dic= ValidationHelper.ValidationObject(addUserData);
                  if (dic.Count > 0)
                  {
                      ShowTip("请输入正确的信息", o as Window);
                      return;
                  }
                  var result= UserService.Add(addUserData);
                  if (result)
                  {
                      isQuery = false;
                      UpdateDataGrid();
                      ShowTip("添加成功", o as Window);
                      //添加成功，关闭窗体
                      CloseDialog(o as Window);
                  }
                  else
                  {
                      ShowTip("添加失败", o as Window);
                  }
              });

            //删除用户
            deleteCommand.ExcuteAction = new Action<object>(o =>
              {
                  List<User> delUser = new List<User>() ;
                  foreach (var item in page.Items)
                  {
                      if (item.IsSelected)
                      {
                          delUser.Add(item);
                      }
                  }
                  foreach (var item in delUser)
                  {
                      if (UserService.Del(item))
                      {
                          ShowTip("删除成功");
                      }
                      else
                      {
                          ShowTip("删除失败");
                      }
                  }
                  UpdateDataGrid(searchText);
              });

            //查询
            searchCommand.ExcuteAction = new Action<object>(o =>
              {
                  page.CurPage = 1;
                  if (!string.IsNullOrEmpty(searchText))
                  {
                      isQuery = true;
                      UpdateDataGrid(searchText);
                  }
                  else
                  {
                      isQuery = false;
                      UpdateDataGrid();
                  }
              });

            //更新每页条数
            updatePerPageItemCommand = new DelegateCommand();
            updatePerPageItemCommand.ExcuteAction = new Action<object>(o =>
            {
                var text = o as string;
                if (!string.IsNullOrEmpty(text))
                {
                    page.PerPageItem = Convert.ToInt32(text);
                    page.CurPage = 1;
                    UpdateDataGrid(searchText);
                }
            });

        }


        /// <summary>
        /// 更新表格数据
        /// </summary>
        private void UpdateDataGrid(string name="")
        {
         
            if (!isQuery)
            {
                //获取总页数和总记录数
                page.AllItemCount = UserService.GetAllItemCount();
                page.GetAllPageCount();
                page.Items.Clear();
                UserService.GetPage(page.CurPage, page.PerPageItem).ToList().ForEach(i => {
                    page.Items.Add(i);
                });
            }
            else
            {
                page.Items.Clear();
                var li = UserService.GetPageByName(name, page.CurPage, page.PerPageItem);
                page.AllItemCount = UserService.QueryByName(name);
                page.GetAllPageCount();
                li.ForEach(u => page.Items.Add(u));
            }
            
        }
       
        /// <summary>
        /// 修改成功，关闭窗口
        /// </summary>
        /// <param name="window"></param>
        private void CloseDialog(Window window)
        {
            window.Close();
            window.Owner.Activate();
        }

        /// <summary>
        /// 按下回车,触发修改每页条数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DownEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                page.CurPage = 1;
                UpdateDataGrid(searchText);
            }
        }

    }
}
