using MyWpf.Commands;
using MyWpf.EF.Models;
using MyWpf.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Menu = MyWpf.EF.Models.Menu;

namespace MyWpf.ViewModels
{
    public class PermissionViewModel:ViewModelBase
    {
        ~PermissionViewModel()
        {
            //System.Windows.Forms.MessageBox.Show("PermissionViewModel被析构");
        }
        public UserService UserService { get; set; }
        public MenuService MenuService { get; set; }
        public User_MenuService User_MenuService { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Menu> Menus { get; set; }
        public ObservableCollection<Menu> CurUserMenus { get; set; }

        private DelegateCommand selectedChangedCommand;

        public DelegateCommand SelectedChangedCommand
        {
            get { return selectedChangedCommand; }
            set
            {
                selectedChangedCommand = value;
                this.RaisePropertyChanged("SelectedChangedCommand");
            }
        }

        private DelegateCommand savePermissCommand;

        public DelegateCommand SavePermissCommand
        {
            get { return savePermissCommand; }
            set
            {
                savePermissCommand = value;
                this.RaisePropertyChanged("SavePermissCommand");
            }
        }


        public PermissionViewModel()
        {
            UserService = new UserService();
            MenuService = new MenuService();
            User_MenuService = new User_MenuService();

            Users = new ObservableCollection<User>();
            Menus = new ObservableCollection<Menu>();
            CurUserMenus = new ObservableCollection<Menu>();

            MenuService.Query().ForEach(m=> {
                m.IsSelected = false;
                Menus.Add(m);
                });

            UserService.Query().ForEach(u =>
            {
                Users.Add(u);
            });

            //选择项改变
            selectedChangedCommand = new DelegateCommand();
            selectedChangedCommand.ExcuteAction = new Action<object>(o =>
              {
                  ListBox listBox = o as ListBox;
                  if (listBox != null)
                  {
                      foreach (var item in Menus)
                      {
                          item.IsSelected = false;
                      }
                      CurUserMenus.Clear();

                      var id = (listBox.SelectedItem as User).Id;
                      var menuIds = User_MenuService.QueryMenuById(id);
                      //MenuService.QueryByIds(menuIds).ForEach(m=> CurUserMenus.Add(m));
                      foreach (var mId in menuIds)
                      {
                          foreach (var item in Menus)
                          {
                              if(item.Id== mId)
                              {
                                  item.IsSelected = true;
                              }
                          }
                      }
                  }
              });

            //保存权限修改
            savePermissCommand = new DelegateCommand();
            savePermissCommand.ExcuteAction = new Action<object>(o =>
              {
                  var list = o as List<object>;
                  if (list != null)
                  {
                      var uId = (((list[0] as ListBox).SelectedItem)as User).Id;
                      List<Menu> menus = new List<Menu>();
                      var items= (list[1] as ListBox).SelectedItems;
                      foreach (var item in items)
                      {
                          menus.Add(item as Menu);
                      }
                      List<int> mIds = new List<int>();
                      menus.ForEach(m => mIds.Add(m.Id));
                      if(User_MenuService.Modify(uId, mIds))
                      {
                          ShowTip("保存成功");
                      }
                      else
                      {
                          ShowTip("保存失败");
                      }
                  }
              });
        }
    }
}
