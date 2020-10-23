using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.EF.Models
{
    public partial class User_Menu:BindableBase
    {
        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                this.RaisePropertyChanged("Id");
            }
        }

        private int userId;

        public int UserId
        {
            get { return userId; }
            set
            {
                userId = value;
                this.RaisePropertyChanged("UserId");
            }
        }

        private int menuId;

        public int MenuId
        {
            get { return menuId; }
            set
            {
                menuId = value;
                this.RaisePropertyChanged("MenuId");
            }
        }


        public virtual Menu Menu { get; set; }
        public virtual User User { get; set; }
            
    }
}
